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

        public override bool Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor billboard = cast["environment"][1];
            Actor lives = cast["environment"][2];
            Actor character = cast["character"][0];
            Actor enemy = cast["enemies"][0];
            List<Actor> holes = cast["holes"];
            // Actor chest = cast["chest"][0];
            
            // List<Actor> bushes = cast["bushes"];
            // List<Actor> pendants = cast["pendants"];
            List<Actor> holesToRemove = new List<Actor>();
            
            

            billboard.SetText(Constants.DEFAULT_BILLBOARD_MESSAGE);

            // This checks to see if the player collides with a bush
            foreach(Actor actor in holes)
            {
                Hole hole = (Hole)actor;
                if(_physicsService.IsCollision(character, hole))
                {
                    // _audioService.PlaySound(Constants.SOUND_LEAF);
                    // string bushText = bush.GetDescription();
                    // billboard.SetText(bushText);
                    holesToRemove.Add(hole);
                }
            }

            while(delay > 5)
            {
                delay -= 1;
            }

            if (delay == 5)
            {
                // _audioService.PlaySound(Constants.SOUND_LOSE);
                System.Threading.Thread.Sleep(2000);
                return false;
            }

            // This will be a lose condition
            if(holes.Count == Constants.NUM_HOLES-15)
            {
                billboard.SetText("Sorry, you lose. Better luck next time");
                System.Threading.Thread.Sleep(200);
                delay = 5;
            }


            // This removes the bushes from the game once they've been searched.
            foreach(Actor hole in holesToRemove)
            {
                cast["holes"].Remove(hole);
                lives.SetText($"Lives left: {Lives.lives -= 1}");
            }

            // This checks to see if the player collides with a pendant hiding spot
            // foreach (Actor actor in pendants)
            // {
            //     Bush pendant1 = (Bush)pendants[0];
            //     Bush pendant2 = (Bush)pendants[1];
            //     Bush pendant3 = (Bush)pendants[2];
                
            //     if(_physicsService.IsCollision(character,pendant1))
            //     {
            //         _audioService.PlaySound(Constants.SOUND_PENDANTFOUND);
            //         string pendantText = pendant1.GetDescription();
            //         billboard.SetText(pendantText);
            //         pendant1.SetImage(Constants.IMAGE_PENDANT);
            //         pendant1.IsFound();
                    
            //     }
            //     else if(_physicsService.IsCollision(character,pendant2))
            //     {
            //         _audioService.PlaySound(Constants.SOUND_PENDANTFOUND);
            //         string pendantText1 = pendant2.GetDescription();
            //         billboard.SetText(pendantText1);
            //         pendant2.SetImage(Constants.IMAGE_PENDANT1);
            //         pendant2.IsFound();
                    
            //     }
            //     else if(_physicsService.IsCollision(character,pendant3))
            //     {
            //         _audioService.PlaySound(Constants.SOUND_PENDANTFOUND);
            //         string pendantText2 = pendant3.GetDescription();
            //         billboard.SetText(pendantText2);
            //         pendant3.SetImage(Constants.IMAGE_PENDANT2);
            //         pendant3.IsFound();
                    
            //     }

                
            // }
            
            // This loop is to check for images to handle the win condition
            // foreach(Actor actor in pendants)
            // {
            //     Actor pendant1 = pendants[0];
            //     Actor pendant2 = pendants[1];
            //     Actor pendant3 = pendants[2];

            //     if(pendant1.GetImage() == Constants.IMAGE_PENDANT && pendant2.GetImage() == Constants.IMAGE_PENDANT1 && pendant3.GetImage() == Constants.IMAGE_PENDANT2)
            //     {
            //         billboard.SetText("You have found all three pendants. Open the chest to Win! \n Press 'ESC' to leave the game");
            //         chest.SetImage(Constants.IMAGE_CHEST);
            //         chest.SetHeight(10);
            //         chest.SetWidth(10);
            //         foreach(Actor bush in bushes)
            //         {
            //             bush.SetHeight(0);
            //             bush.SetWidth(0);
            //         }
            //     }
            // }
            // if(_physicsService.IsCollision(character,chest))
            // {
            //     _audioService.PlaySound(Constants.SOUND_WIN);
            //     System.Threading.Thread.Sleep(2000);
            //     Director._keepPlaying = false;
            // }
            
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
                        if (actor2.GetRightEdge() < cast["back_marker"][0].GetX()) {
                            delListPhy.Add(actor2);

                        }
                        if (actor1.GetRightEdge() < cast["back_marker"][0].GetX()) {
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