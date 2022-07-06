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

            // cast["pendants"] = new List<Actor>();
            // cast["chest"] = new List<Actor>();

            HolesGenerator hgenerator = new HolesGenerator();
            EnemyGenerator generator = new EnemyGenerator();
            FileGenerator fgenerator = new FileGenerator();

            for (int i = 0; i < Constants.NUM_ENEMIES; i++)
            {
                Enemy enemy = generator.Generate();
                cast["enemies"].Add(enemy);
                cast["physical_objects"].Add(enemy);
                // leaving this line commented out until we have non-moveable objects (platforms) to interact with the moveable objects.
                //cast["movable_objects"].Add(enemy);
            }
            for (int i = 0; i < Constants.NUM_HOLES; i++)
            {
                Hole hole = hgenerator.hGenerate();
                cast["holes"].Add(hole);
            }

            Actor marker = new Actor();
            marker.SetPosition(new Point(0, 0));
            cast["map_gen_marker"] = new List<Actor>();
            cast["map_gen_marker"].Add(marker);

            Actor back_marker = new Actor();
            marker.SetPosition(new Point(0, 0));
            cast["back_marker"] = new List<Actor>();
            cast["back_marker"].Add(back_marker);

            // Bush pendant1 = generator.Generate();
            // pendant1.SetDescription("You have found the first pendant");
            // cast["pendants"].Add(pendant1);
            // Bush pendant2 = generator.Generate();
            // pendant2.SetDescription("You have found the second pendant");
            // cast["pendants"].Add(pendant2);
            // Bush pendant3 = generator.Generate();
            // pendant3.SetDescription("You have found the third pendant");
            // cast["pendants"].Add(pendant3);

            
            
            // Chest chest = new Chest();
            // cast["chest"].Add(chest);

            // The player
            cast["character"] = new List<Actor>();

            Character character = new Character();
            character.SetUseGravity(true);
            cast["character"].Add(character);
            cast["physical_objects"].Add(character);
            cast["movable_objects"].Add(character);

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

