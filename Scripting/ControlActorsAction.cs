using System.Collections.Generic;
using HolesAreBad.Casting;
using HolesAreBad.Services;

namespace HolesAreBad
{
    ///<summary>
    /// This class will control how each actor will recieve input from the user
    ///<summary>
    public class ControlActorsAction : UpdateAction
    {
        InputService _inputService;

        public ControlActorsAction(InputService inputService)
        {
            _inputService = inputService;
        }

        public override bool Execute(Dictionary<string, List<Actor>> cast)
        {
            Point direction = _inputService.GetDirection();
            
            Actor player = cast["character"][0];

            player.SetJump(direction.GetY() != 0);

            double dx = direction.GetX() * Constants.CHARACTER_SPEED;
            Pointf velocity = new Pointf(dx, player.GetVelocity().GetY());
            if ((dx > 0 && player.GetPosition().GetX() > Constants.MAX_X * Constants.SCROLL_THRESHOLD_FORWARD) ||
                (dx < 0 && player.GetPosition().GetX() > cast["back_marker"][0].GetX() + Constants.MAX_X * Constants.SCROLL_THRESHOLD_BACKWARD && player.GetPosition().GetX() < Constants.MAX_X * Constants.SCROLL_THRESHOLD_BACKWARD)) {
                ScrollAllActors(cast, dx);
            }
            player.SetVelocity(velocity);
            if (player.GetLeftEdge() < 0) {
                player.SetPosition(new Point(0, player.GetY()));
            }
            return true;
        }

        private void ScrollAllActors(Dictionary<string, List<Actor>> cast, double dx) {
            List<Actor> checklist = new List<Actor>();
            Actor player = cast["character"][0];
            Actor backMarker = cast["back_marker"][0];
            foreach (List<Actor> group in cast.Values)
            {
                foreach (Actor actor in group)
                {
                    if (!checklist.Contains(actor)){
                        int x = actor.GetX();
                        //int y = actor.GetY();

                        double newX = (x - dx);
                        //double newY = (y + dy) % Constants.MAX_Y;

                        actor.SetPosition(new Point((int)newX, actor.GetPosition().GetY()));
                        checklist.Add(actor);
                    }
                }
            }
            if (player.GetPosition().GetX() - backMarker.GetX() > Constants.MAX_X * 2) {
                backMarker.SetPosition(new Point((int)(backMarker.GetX() + dx), 0));
            }
            foreach (Actor actor in cast["environment"])
            {
                actor.SetPosition(new Point((int)(actor.GetX() + dx), 0));
            }
        }
    }
}