using HolesAreBad.Services;
using HolesAreBad.Casting;
using HolesAreBad.Scripting;
using System.Collections.Generic;

namespace HolesAreBad
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            //Environment Objects
            cast["environment"] = new List<Actor>();
            Background background = new Background();
            cast["environment"].Add(background);

            Billboard billboard = new Billboard();
            
            cast["environment"].Add(billboard);
            
            Lives lives = new Lives();
            cast["environment"].Add(lives);

            // Physics Objects
            cast["enemies"] = new List<Actor>();
            cast["physical_objects"] = new List<Actor>();
            cast["movable_objects"] = new List<Actor>();
            cast["holes"] = new List<Actor>();
            cast["platforms"] = new List<Actor>();
            cast["spikes"] = new List<Actor>();
            cast["collectables"] = new List<Actor>();


            FileGenerator fgenerator = new FileGenerator();


            Actor marker = new Actor();
            marker.SetPosition(new Point(0, 0));
            cast["map_gen_marker"] = new List<Actor>();
            cast["map_gen_marker"].Add(marker);

            Actor back_marker = new Actor();
            marker.SetPosition(new Point(0, 0));
            cast["back_marker"] = new List<Actor>();
            cast["back_marker"].Add(back_marker);


            // The player
            cast["character"] = new List<Actor>();

            Character character = new Character();
            character.SetUseGravity(true);
            cast["character"].Add(character);
            cast["physical_objects"].Add(character);
            cast["movable_objects"].Add(character);

            cast["last_known_location"] = new List<Actor>();
            cast["last_known_location"].Add(new Actor());

            // Create the action list
            List<Action> actions = new List<Action>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();


            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            actions.Add(drawActorsAction);

            // The actions here are to handle the input, move the actors, handle collisions, etc.
            MoveActorsAction moveActorsAction = new MoveActorsAction();
            actions.Add(moveActorsAction);

            ControlActorsAction controlActorsAction = new ControlActorsAction(inputService);
            actions.Add(controlActorsAction);

            HandleCollisionsAction handleCollisionsAction = new HandleCollisionsAction(physicsService, audioService);
            actions.Add(handleCollisionsAction);

            MapGenerateAction mapGenerateAction = new MapGenerateAction(fgenerator);
            actions.Add(mapGenerateAction);

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Holes Are Bad", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, actions, outputService, inputService);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}

