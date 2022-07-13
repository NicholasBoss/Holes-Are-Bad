using System;
using System.Diagnostics;
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
        private InputService _inputService;
        private ParallaxEffect _parallax; 
        private bool play = false;
        private bool end = false;
        private bool restart = true;


        public Director(Dictionary<string, List<Actor>> cast, List<Action> actions, OutputService outputService, InputService inputService)
        {
            _cast = cast;
            _actions = actions;
            _outputService = outputService;
            _inputService = inputService;
        }

        /// <summary>
        /// This method starts the game and continues running until it is finished.
        /// </summary>
     
        public void Direct()
        {
            while (restart)
            {
            // Display Title Screen
            _parallax = new ParallaxEffect(Constants.LVL_1_FOREGROUND, Constants.LVL_1_MIDGROUND, Constants.LVL_1_BACKGROUND);
                var title = new Title(_outputService, _parallax);
                while (play != true) //, don't go beyond title screen
                // for (int i = 0; i < 250; i++)
                {
                    _outputService.DrawParallax(_parallax, Constants.LVL_1_FOREGROUND, Constants.LVL_1_MIDGROUND, Constants.LVL_1_BACKGROUND, 1);
                    CueAction(title);
                    if (_inputService.IsSpacePressed())
                    {
                        play = true;
                    }
                }

                while (_keepPlaying)
                {
                    Character temp = (Character)_cast["character"][0];
                    _outputService.DrawParallax(_parallax, Constants.LVL_1_FOREGROUND, Constants.LVL_1_MIDGROUND, Constants.LVL_1_BACKGROUND, temp.getScrollingDir());
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
                        restart = false;
                        play = false;
                    }
                }
                var creditScreen = new CreditScreen(_outputService, _parallax);
                // Display Credit Screen
                while (restart != true || end != true) //, don't go beyond credit screen
                {
                    
                    CueAction(creditScreen);
                    if (_inputService.IsSpacePressed())
                    {
                        end = true;
                        Environment.Exit(0);
                    }
                    else if (_inputService.IsKeyRPressed())
                    {
                        restart = true;
                        _keepPlaying = true;
                    }
                }

                Console.WriteLine("Game over!");
            }
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
