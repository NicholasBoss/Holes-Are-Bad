using System;
using System.Collections.Generic;
using HolesAreBad.Casting;
using HolesAreBad.Services;
using HolesAreBad.Scripting;
using System.Linq;

namespace HolesAreBad
{
    /// <summary>
    /// The director is responsible to direct the game, including to keep track of all
    /// the actors and to control the sequence of play.
    /// 
    /// Stereotype:
    ///     Controller
    /// </summary>
    public class Director
    {
        public static bool _keepPlaying = true;
        private Dictionary<string, List<Actor>> _cast;
        private List<Action> _actions;
        private OutputService _outputService;

        public Director(Dictionary<string, List<Actor>> cast, List<Action> actions, OutputService outputService)
        {
            _cast = cast;
            _actions = actions;
            _outputService = outputService;
        }

        /// <summary>
        /// This method starts the game and continues running until it is finished.
        /// </summary>
        public void Direct()
        {
            // Display Title Screen
            var title = new Title(_outputService);
            // while play != true, don't go beyond title screen
            for (int i = 0; i < 250; i++)
            {
                CueAction(title);
            }

            while (_keepPlaying)
            {
                if (!CueAction(_actions.OfType<InputAction>().ToArray()))
                {
                    break;
                }
                if(!CueAction(_actions.OfType<UpdateAction>().ToArray()))
                {
                    break;
                }
                if(!CueAction(_actions.OfType<OutputAction>().ToArray()))
                {
                    break;
                }

                if (Raylib_cs.Raylib.WindowShouldClose())
                {
                    _keepPlaying = false;
                }
            }
            var creditScreen = new CreditScreen(_outputService);
            // Display Credit Screen
            for (int i = 0; i < 250; i++)
            {
                CueAction(creditScreen);
            }

            Console.WriteLine("Game over!");
        }

        /// <summary>
        /// Executes all of the actions for the provided phase.
        /// </summary>
        /// <param name="phase"></param>
        private bool CueAction(params Action[] actions)
        {
            foreach (Action action in actions)
            {
                if (!action.Execute(_cast))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
