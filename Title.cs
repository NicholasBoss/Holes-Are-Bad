using System.Collections.Generic;
using HolesAreBad.Casting;
using HolesAreBad.Services;
using HolesAreBad.Scripting;
using Raylib_cs;

namespace HolesAreBad
{
    /// <summary>
    /// The TitleScreen class is responsible for handling the title screen of the game.
    /// </summary>
    public class Title : Action

    {
        private OutputService _outputService;
        private ParallaxEffect _parallax; 

        public Title(OutputService outputService, ParallaxEffect parallax)
        {
            _outputService = outputService;
            _parallax = parallax; 
        }

        public override bool Execute(Dictionary<string, List<Actor>> cast)
        {
            _outputService.StartDrawing();
            
            _outputService.DrawParallax(_parallax, Constants.LVL_1_BACKGROUND, Constants.LVL_1_FOREGROUND, Constants.LVL_1_MIDGROUND);

            _outputService.DrawText(100, 100, "Holes Are Bad");

            _outputService.EndDrawing();
            
            return true;
        }

        
    }}