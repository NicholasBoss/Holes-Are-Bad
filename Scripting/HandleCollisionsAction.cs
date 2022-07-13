using System.Collections.Generic;
using HolesAreBad.Casting;
using HolesAreBad.Services;
using System.Linq;
using System;

namespace HolesAreBad.Scripting
{
    ///<summary>
    /// This class will control how each actor will act when collided with.
    ///<summary>
    public class HandleCollisionsAction : UpdateAction
    {
        PhysicsService _physicsService;
        AudioService _audioService;
        private int delay = 0;
        private bool _lose = false;

        public HandleCollisionsAction(PhysicsService physicsService, AudioService audioService)
        {
            _physicsService = physicsService;
            _audioService = audioService;
        }
        //changed billboard to 0 lives to 1 collectables to 2
        public override bool Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor billboard = cast["environment"][0];
            Actor lives = cast["environment"][1];
            Actor collectableenv = cast["environment"][2];
            Actor character = cast["character"][0];
            List<Actor> spikes = cast["spikes"];
            List<Actor> collectables = cast["collectables"];
            // Actor chest = cast["chest"][0];
            
            // List<Actor> bushes = cast["bushes"];
            // List<Actor> pendants = cast["pendants"];
            List<Actor> spikesToRemove = new List<Actor>();
            List<Actor> collectablesToRemove = new List<Actor>();
            
            

            billboard.SetText(Constants.DEFAULT_BILLBOARD_MESSAGE);

            // This checks to see if the player collides with a spike or collectable.
            foreach(Actor actor in spikes)
            {
                Spike spike = (Spike)actor;
                if(_physicsService.IsCollision(character, spike))
                {
                    spikesToRemove.Add(spike);
                }
            }

            foreach(Actor actor in collectables)
            {
                Collectable collectable = (Collectable)actor;
                if(_physicsService.IsCollision(character, collectable))
                {
                    collectablesToRemove.Add(collectable);
                }
            }

            while(delay > 5)
            {
                delay -= 1;
            }

            if (delay == 5)
            {
                System.Threading.Thread.Sleep(2000);
                return false;
            }

            // This will be a Win condition
            if(Collectableenv.collectable == 10)
            {
                billboard.SetText("You Win!");
                System.Threading.Thread.Sleep(200);
                delay = 5;
            }


            // This removes the bushes from the game once they've been searched.
            foreach(Actor spike in spikesToRemove)
            {
                cast["spikes"].Remove(spike);
                lives.SetText($"Lives left: {Lives.lives += 1}");
            }

            foreach (Actor collectable in collectablesToRemove)
            {
                cast["collectables"].Remove(collectable);
                collectableenv.SetText($"Collectables: {Collectableenv.collectable += 1}/10");
            }

            
            
        
            
            Dictionary<Actor, string> collision_num = new Dictionary<Actor, string>();
            List<Actor> delListPhy = new List<Actor>();
            List<Actor> delListMov = new List<Actor>();
            foreach (Actor c in cast["character"])
            {
                c.SetJumpReady(false);
            }
            foreach (Actor actor1 in cast["movable_objects"])
            {
                foreach (Actor actor2 in cast["physical_objects"])
                {
                    if (actor1 != actor2)
                    {
                        if (actor2.GetX() < cast["back_marker"][0].GetX() - Constants.MAX_X) {
                            delListPhy.Add(actor2);
                        }
                        if (actor1.GetX() < cast["back_marker"][0].GetX() - Constants.MAX_X) {
                            delListMov.Add(actor1);
                        }
                        if (_physicsService.IsCollision(actor1, actor2) && actor1.HasBox() && actor2.HasBox()) 
                        {
                            // Measure all possible shifts that resolve the collision
                            int leftShift = actor1.GetRightEdge() - actor2.GetLeftEdge();
                            int rightShift = actor2.GetRightEdge() - actor1.GetLeftEdge();
                            int upShift = actor1.GetBottomEdge() - actor2.GetTopEdge();
                            int downShift = actor2.GetBottomEdge() - actor1.GetTopEdge();
                            
                            int shift = new int[] {leftShift, rightShift, upShift, downShift}.Min(); // Choose the smallest shift
                            if (shift == int.MaxValue) shift = 0;
                            string shiftType = "none";
                            double dy = actor1.GetVelocity().GetY();
                            if (shift == upShift)
                            {
                                shiftType = "up";
                            }
                            else if (shift == leftShift)
                            {
                                shiftType = "left";
                            }
                            else if (shift == rightShift)
                            {
                                shiftType = "right";
                            }
                            else if (shift == downShift)
                            {
                                shiftType = "down";
                            }
                            if (shiftType == "down" && actor2.GetBottomEdge() >= Constants.MAX_Y) {
                                shiftType = "up";
                            }
                            if (shiftType == "up" && actor1.GetTopEdge() >= Constants.MAX_Y -5) {
                                shiftType = "down";
                            }
                            if (shiftType == "down" && dy > 0) {
                                shift = new int[] {leftShift, rightShift, upShift}.Min();
                            }
                            if (shiftType == "up" && dy < 0) {
                                shift = new int[] {leftShift, rightShift, downShift}.Min();
                            }
                            if (collision_num.ContainsKey(actor1))
                            {
                                if (shiftType == "left" && collision_num[actor1] == "right" ||
                                    shiftType == "right" && collision_num[actor1] == "left" ||
                                    shiftType == "up" && collision_num[actor1] == "down" ||
                                    shiftType == "down" && collision_num[actor1] == "up")
                                {
                                    actor1.SetVelocity(new Pointf(actor1.GetVelocity().GetX(), 0));
                                    actor1.SetPosition(new Point(actor1.GetPosition().GetX(), actor1.GetPosition().GetY() - upShift));
                                    actor1.SetJumpReady(true);
                                }
                            }
                            if (shiftType != "none") 
                            {
                                int leftRightOffset = Math.Abs(dy) > 3 ? 3 : 0;
                                collision_num[actor1] = shiftType;
                                if (shiftType == "up") // This will be by far the most common case (standing on platform) so it goes first
                                {
                                    actor1.SetVelocity(new Pointf(actor1.GetVelocity().GetX(), 0));
                                    actor1.SetPosition(new Point(actor1.GetPosition().GetX(), actor1.GetPosition().GetY() - upShift));
                                    actor1.SetJumpReady(true);
                                    if (actor1 == cast["character"][0] && cast["platforms"].Contains(actor2)) {
                                        cast["last_known_location"][0] = actor2;
                                    }
                                }
                                else if (shiftType == "left")
                                {
                                    actor1.SetPosition(new Point(actor1.GetPosition().GetX() - leftShift - leftRightOffset, actor1.GetPosition().GetY()));
                                }
                                else if (shiftType == "right")
                                {
                                    actor1.SetPosition(new Point(actor1.GetPosition().GetX() + rightShift + leftRightOffset, actor1.GetPosition().GetY()));
                                }
                                else if (shiftType == "down")
                                {
                                    actor1.SetVelocity(new Pointf(actor1.GetVelocity().GetX(), 0));
                                    actor1.SetPosition(new Point(actor1.GetPosition().GetX(), actor1.GetPosition().GetY() + downShift));
                                }
                            }
                        }
                    }
                }
            }
            foreach (Actor c in delListPhy) {
                cast["physical_objects"].Remove(c);
            }
            foreach (Actor c in delListMov) {
                cast["movable_objects"].Remove(c);
            }
            return true;
        }
    }
}