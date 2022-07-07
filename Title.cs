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
            
            _outputService.DrawImage(0,0, "./Assets/Backgrounds/Icon.png");
            _outputService.DrawImage(1600, 900, "./Assets/Backgrounds/Start.png");
            _outputService.DrawParallax(_parallax);

            _outputService.DrawText(100, 100, "Holes are bad", true);

            _outputService.EndDrawing();
            
            return true;
        }

        //create the cast
        
        //environment objects
        // _cast["Tenvironment"] = new List<Actor>();
        // private TitleImage _background = new TitleImage();
        // _cast["Tenvironment"].Add(_background);

        //physics objects
        // _cast["buttons"] = new List<Actor>();
        // private Button _startButton = new Button();
        // _cast["buttons"].Add(_startButton);
        // private Button _creditButton = new Button();
        // _cast["buttons"].Add(_creditButton);
        // private Button _icon = new Button();
        // _cast["buttons"].Add(_icon);
        
    }}