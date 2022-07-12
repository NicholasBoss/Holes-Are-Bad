using System.Collections.Generic;
using HolesAreBad.Casting;
using HolesAreBad.Services;
using Raylib_cs;

namespace HolesAreBad
{
    /// <summary>
    /// The TitleScreen class is responsible for handling the title screen of the game.
    /// </summary>
    public class CreditScreen : Action
    {
        private OutputService _outputService;

        public CreditScreen(OutputService outputService)
        {
            _outputService = outputService;
        }

        public override bool Execute(Dictionary<string, List<Actor>> cast)
        {
            _outputService.StartDrawing();

            _outputService.DrawImage(0, 0, Constants.IMAGE_CREDIT);

            _outputService.DrawText(100, 100, "Thanks for Playing. Press [spacebar] to quit game.");
            

            _outputService.EndDrawing();
            return true;
        }

    }
    }