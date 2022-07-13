using System.Collections.Generic;
using HolesAreBad.Casting;
using HolesAreBad.Services;
using System;
namespace HolesAreBad.Scripting
{
    ///<summary>
    /// This class will control how each actor will move on the screen
    ///<summary>
    public class MoveActorsAction : UpdateAction
    {
        public MoveActorsAction()
        {
        }

        public override bool Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor player = cast["character"][0];
            Actor lives = cast["environment"][2];
            List<Actor> checklist = new List<Actor>();
            foreach (List<Actor> group in cast.Values)
            {
                foreach (Actor actor in group)
                {
                    if (!checklist.Contains(actor)){
                        MoveActor(actor);
                        if (actor == player && actor.GetBottomEdge() > Constants.MAX_Y) {
                            Actor restorePoint = cast["last_known_location"][0];
                            actor.SetPosition(new Point(restorePoint.GetLeftEdge() + restorePoint.GetWidth() / 2 - actor.GetWidth() / 2, restorePoint.GetTopEdge() - actor.GetHeight()));
                            lives.SetText($"Lives left: {Lives.lives -= 1}");
                        }
                        checklist.Add(actor);
                    }
                }
            }
            return true;
        }

        private double HandleGravity(Actor actor, double velocityY)
        {
            if (actor.GetUseGravity())
            {   
                double newVY = Math.Min(Constants.TERMINAL_VELOCITY, velocityY + Constants.GRAVITY);
                actor.SetVelocity(new Pointf(actor.GetVelocity().GetX(), newVY));
                return newVY;
            }
            return velocityY;
        }

        private double HandleJump(Actor actor, double velocityY)
        {
            if (actor.GetJump() && actor.GetJumpReady())
            {   
                double newVY = -Constants.JUMP_POWER*actor.UseJumpMultiplier();
                actor.SetJumpReady(false);
                actor.SetVelocity(new Pointf(actor.GetVelocity().GetX(), newVY));
                return newVY;
            }
            return velocityY;
        }
        
        private void MoveActor(Actor actor)
        {
            int x = actor.GetX();
            int y = actor.GetY();

            double dx = actor.GetVelocity().GetX();
            double dy = actor.GetVelocity().GetY();

            dy = HandleGravity(actor, dy);
            dy = HandleJump(actor, dy);

            double newX = (x + dx) /*% Constants.MAX_X*/;
            double newY = (y + dy) /*% Constants.MAX_Y*/;

            /*if (newX < 0)
            {
                newX = Constants.MAX_X;
            }

            if (newY < 0)
            {
                newY = Constants.MAX_Y;
            }*/

            actor.SetPosition(new Point((int)newX, (int)newY));
        }

    }
}