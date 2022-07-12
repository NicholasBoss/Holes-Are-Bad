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

        public HandleCollisionsAction(PhysicsService physicsService, AudioService audioService)
        {
            _physicsService = physicsService;
            _audioService = audioService;
        }

        public override bool Execute(Dictionary<string, List<Actor>> cast)
        {
            // retrieves the cast variables from the cast dictionary
            Actor billboard = cast["environment"][1];
            Actor lives = cast["environment"][2];
            Actor collectableenv = cast["environment"][3];
            Actor character = cast["character"][0];
            List<Actor> spikes = cast["spikes"];
            List<Actor> collectables = cast["collectables"];
            List<Actor> holes = cast["holes"];
            List<Actor> enemies = cast["enemies"];
            List<Actor> flying_enemies = cast["flying_enemies"];
            List<Actor> jumping_enemies = cast["jumping_enemies"];
       
            // create a list of all actors that are gaing to be removed from the cast and thus the game
            List<Actor> spikesToRemove = new List<Actor>();
            List<Actor> collectablesToRemove = new List<Actor>();
            List<Actor> holesToRemove = new List<Actor>();
            List<Actor> enemiesToRemove = new List<Actor>();
            List<Actor> flyingEnemiesToRemove = new List<Actor>();
            List<Actor> jumpingEnemiesToRemove = new List<Actor>();

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

            foreach(Actor actor in holes)
            {
                Hole hole = (Hole)actor;
                if(_physicsService.IsCollision(character, hole))
                {
                    holesToRemove.Add(hole);
                }
            }

            foreach(Actor actor in enemies)
            {
                Enemy enemy = (Enemy)actor;
                if(_physicsService.IsCollision(character, enemy))
                {
                    enemiesToRemove.Add(enemy);
                }
            }

            foreach(Actor actor in flying_enemies)
            {
                FlyingEnemy flying_enemy = (FlyingEnemy)actor;
                if(_physicsService.IsCollision(character, flying_enemy))
                {
                    flyingEnemiesToRemove.Add(flying_enemy);
                }
            }

            foreach(Actor actor in jumping_enemies)
            {
                JumpingEnemy jumping_enemy = (JumpingEnemy)actor;
                if(_physicsService.IsCollision(character, jumping_enemy))
                {
                    jumpingEnemiesToRemove.Add(jumping_enemy);
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

            // This removes the actors from the cast.
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

            foreach (Actor hole in holesToRemove)
            {
                cast["holes"].Remove(hole);
                lives.SetText($"Lives left: {Lives.lives -= 5}");
                if (Lives.lives < 0)
                {
                    lives.SetText($"Lives left: {Lives.lives = 0}");
                }
            }

            foreach (Actor enemy in enemiesToRemove)
            {
                cast["enemies"].Remove(enemy);
                cast["movable_objects"].Remove(enemy);
                lives.SetText($"Lives left: {Lives.lives -= 2}");
                if (Lives.lives < 0)
                {
                    lives.SetText($"Lives left: {Lives.lives = 0}");
                }
            }

            foreach (Actor enemy in flyingEnemiesToRemove)
            {
                cast["flying_enemies"].Remove(enemy);
                cast["movable_objects"].Remove(enemy);
                lives.SetText($"Lives left: {Lives.lives -= 2}");
                if (Lives.lives < 0)
                {
                    lives.SetText($"Lives left: {Lives.lives = 0}");
                }
            }

            foreach (Actor enemy in jumpingEnemiesToRemove)
            {
                cast["jumping_enemies"].Remove(enemy);
                cast["movable_objects"].Remove(enemy);
                lives.SetText($"Lives left: {Lives.lives -= 3}");
                if (Lives.lives < 0)
                {
                    lives.SetText($"Lives left: {Lives.lives = 0}");
                }
            }

            // This will be a Win condition
            while(delay > 5)
            {
                delay -= 1;
            }

            if (delay == 5)
            {
                System.Threading.Thread.Sleep(2000);
                return false;
            }
            if(Collectableenv.collectable == 10)
            {
                billboard.SetText("You Win!");
                System.Threading.Thread.Sleep(200);
                delay = 5;
            }

            

            // This will be a Lose condition
            if (Lives.lives <= 0)
            {
                billboard.SetText("You Lose!");
                System.Threading.Thread.Sleep(200);
                delay = 5;
            }
        
            // This is the physics engine that will check for collisions.
            Dictionary<Actor, string> collision_num = new Dictionary<Actor, string>();
            Dictionary<Actor, bool> jump_ready = new Dictionary<Actor, bool>();
            List<Actor> delListPhy = new List<Actor>();
            List<Actor> delListMov = new List<Actor>();
            bool isEnemy = false;
            bool isFlyingEnemy = false;
            bool isJumpingEnemy = false;
            /*foreach (Actor c in cast["character"])
            {
                c.SetJumpReady(false);
            }*/
            foreach (Actor actor1 in cast["movable_objects"])
            {
                jump_ready.Add(actor1, false);
                isEnemy = cast["enemies"].Contains(actor1);
                isFlyingEnemy = cast["flying_enemies"].Contains(actor1);
                isJumpingEnemy = cast["jumping_enemies"].Contains(actor1);
                if (isEnemy) {
                    Enemy e = (Enemy)actor1;
                    e.addYPos(actor1.GetVelocity().GetY());
                    if (e.isYDifferent(actor1.GetVelocity().GetY())) {
                        double first = actor1.GetVelocity().GetX();
                        actor1.SetPosition(new Point(actor1.GetPosition().GetX() - Constants.ENEMY_WIDTH * Math.Sign(actor1.GetVelocity().GetX()), actor1.GetPosition().GetY()/* - (int)(actor1.GetVelocity().GetY()*1.55)*/));
                        actor1.SetVelocity(new Pointf(-actor1.GetVelocity().GetX(), 0));
                        jump_ready[actor1] = true;
                    }
                }
                if (isJumpingEnemy) {
                    if (cast["character"][0].GetX() < actor1.GetX()) {
                        actor1.SetVelocity(new Pointf(-Math.Abs(actor1.GetVelocity().GetX()), actor1.GetVelocity().GetY()));
                    }
                    else {
                        actor1.SetVelocity(new Pointf(Math.Abs(actor1.GetVelocity().GetX()), actor1.GetVelocity().GetY()));
                    }

                    if (cast["character"][0].GetBottomEdge() < actor1.GetBottomEdge() - 5) {
                        actor1.SetJump(true);
                    }
                    else {
                        actor1.SetJump(false);
                        //actor1.SetVelocity(new Pointf(Math.Abs(actor1.GetVelocity().GetX()), actor1.GetVelocity().GetY()));
                    }
                }
                if (actor1.GetX() < cast["back_marker"][0].GetX() - Constants.MAX_X) {
                    delListMov.Add(actor1);
                }
                foreach (Actor actor2 in cast["physical_objects"])
                {
                    if (actor1 != actor2)
                    {
                        if (actor2.GetX() < cast["back_marker"][0].GetX() - Constants.MAX_X) {
                            delListPhy.Add(actor2);
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
                                    jump_ready[actor1] = true;
                                }
                            }
                            if (shiftType != "none") 
                            {
                                int leftRightOffset = Math.Abs(dy) > 3 * Constants.GRAVITY ? 3 : 0;
                                collision_num[actor1] = shiftType;
                                if (shiftType == "up") // This will be by far the most common case (standing on platform) so it goes first
                                {
                                    actor1.SetVelocity(new Pointf(actor1.GetVelocity().GetX(), 0));
                                    actor1.SetPosition(new Point(actor1.GetPosition().GetX(), actor1.GetPosition().GetY() - upShift));
                                    jump_ready[actor1] = true;
                                    if (actor1 == cast["character"][0] && cast["platforms"].Contains(actor2)) {
                                        cast["last_known_location"][0] = actor2;
                                    }
                                }
                                else if (shiftType == "left")
                                {
                                    if (isEnemy || isFlyingEnemy) {
                                        actor1.SetVelocity(new Pointf(-actor1.GetVelocity().GetX(), actor1.GetVelocity().GetY()));
                                    }
                                    actor1.SetPosition(new Point(actor1.GetPosition().GetX() - leftShift - leftRightOffset, actor1.GetPosition().GetY()));
                                }
                                else if (shiftType == "right")
                                {
                                    if (isEnemy || isFlyingEnemy) {
                                        actor1.SetVelocity(new Pointf(-actor1.GetVelocity().GetX(), actor1.GetVelocity().GetY()));
                                    }
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
                if (cast["platforms"].Contains(c)) {
                    cast["platforms"].Remove(c);
                }
            }
            foreach (Actor c in delListMov) {
                if (cast["enemies"].Contains(c)) {
                    cast["enemies"].Remove(c);
                }
                if (cast["flying_enemies"].Contains(c)) {
                    cast["flying_enemies"].Remove(c);
                }
                if (cast["jumping_enemies"].Contains(c)) {
                    cast["jumping_enemies"].Remove(c);
                }
                cast["movable_objects"].Remove(c);
            }
            foreach (var actor in jump_ready) {
                actor.Key.SetJumpReady(actor.Value);
            }
            return true;
        }
    }
}