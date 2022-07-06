using System.Collections.Generic;
using HolesAreBad.Casting;
using HolesAreBad.Services;
using Raylib_cs;

namespace HolesAreBad
{
    /// <summary>
    /// The TitleScreen class is responsible for handling the title screen of the game.
    /// </summary>
    public class Title : Action

    {
        private OutputService _outputService;

        public Title(OutputService outputService)
        {
            _outputService = outputService;
        }

        public override bool Execute(Dictionary<string, List<Actor>> cast)
        {
            _outputService.StartDrawing();
            
            _outputService.DrawImage(0,0, "./Assets/Backgrounds/Icon.png");
            _outputService.DrawImage(800,450, "./Assets/Backgrounds/Start.png");

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