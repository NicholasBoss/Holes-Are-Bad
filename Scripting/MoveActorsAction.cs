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
        
        private void MoveActor(Actor actor)
        {
            int x = actor.GetX();
            int y = actor.GetY();

            int dx = actor.GetVelocity().GetX();
            int dy = actor.GetVelocity().GetY();

            int newX = (x + dx) % Constants.MAX_X;
            int newY = (y + dy) % Constants.MAX_Y;

            if (newX < 0)
            {
                newX = Constants.MAX_X;
            }

            if (newY < 0)
            {
                newY = Constants.MAX_Y;
            }

            actor.SetPosition(new Point(newX, newY));
        }

    }
}