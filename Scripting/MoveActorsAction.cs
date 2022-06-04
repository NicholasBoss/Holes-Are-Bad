using System.Collections.Generic;
using HolesAreBad.Casting;
using HolesAreBad.Services;
namespace HolesAreBad.Scripting
{
    ///<summary>
    /// This class will control how each actor will move on the screen
    ///<summary>
    public class MoveActorsAction : Action
    {
        public MoveActorsAction()
        {
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach (List<Actor> group in cast.Values)
            {
                foreach (Actor actor in group)
                {
                    MoveActor(actor);
                }
            }
        }

        private double HandleGravity(Actor actor, double velocityY)
        {
            if (actor.GetUseGravity())
            {   
                double newVY = velocityY + Constants.GRAVITY;
                actor.SetVelocity(new Pointf(actor.GetVelocity().GetX(), newVY));
                return newVY;
            }
            return velocityY;
        }

        private double HandleJump(Actor actor, double velocityY)
        {
            if (actor.GetJump() && actor.GetJumpReady())
            {   
                double newVY = -Constants.JUMP_POWER;
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

            double newX = (x + dx) % Constants.MAX_X;
            double newY = (y + dy) % Constants.MAX_Y;

            if (newX < 0)
            {
                newX = Constants.MAX_X;
            }

            if (newY < 0)
            {
                newY = Constants.MAX_Y;
            }

            actor.SetPosition(new Point((int)newX, (int)newY));
        }

    }
}