using System.Collections.Generic;
using THETHREEPENDANTS.Casting;
using THETHREEPENDANTS.Services;

namespace THETHREEPENDANTS
{
    ///<summary>
    /// This class will control how each actor will recieve input from the user
    ///<summary>
    public class ControlActorsAction : Action
    {
        InputService _inputService;

        public ControlActorsAction(InputService inputService)
        {
            _inputService = inputService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Point direction = _inputService.GetDirection();
            
            Actor paddle = cast["character"][0];

            Point velocity = direction.Scale(Constants.CHARACTER_SPEED);
            paddle.SetVelocity(velocity);
        }
    }
}