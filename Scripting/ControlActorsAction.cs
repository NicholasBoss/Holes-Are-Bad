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

            Pointf velocity = new Pointf(direction.GetX() * Constants.CHARACTER_SPEED, player.GetVelocity().GetY());
            player.SetVelocity(velocity);
            return true;
        }
    }
}