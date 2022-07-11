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
            cast["environment"] = new List<Actor>(); // Create the environment cast
            Background background = new Background(); // The background
            cast["environment"].Add(background); // Add the background to the cast

            Billboard billboard = new Billboard(); // Create the billboard
            
            cast["environment"].Add(billboard); // Add the billboard to the cast
            
            Lives lives = new Lives(); // Create the lives
            cast["environment"].Add(lives); // Add the lives to the cast

            Collectableenv collectableenv = new Collectableenv(); // Create the collectableenv
            cast["environment"].Add(collectableenv); // Add the collectableenv to the cast

            // Physics Objects
            cast["enemies"] = new List<Actor>();            // Create the enemies cast
            cast["physical_objects"] = new List<Actor>();   // Create the physical objects cast
            cast["movable_objects"] = new List<Actor>();    // Create the movable objects cast
            cast["holes"] = new List<Actor>();              // Create the holes cast
            cast["platforms"] = new List<Actor>();          // Create the platforms cast
            cast["ghost_block"] = new List<Actor>();        // Create the ghost block cast
            cast["spikes"] = new List<Actor>();             // Create the spikes cast
            cast["collectables"] = new List<Actor>();       // Create the collectables cast
            cast["flying_enemies"] = new List<Actor>();     // Create the flying enemies cast


            FileGenerator fgenerator = new FileGenerator(); // Create the file generator


            Actor marker = new Actor();                 // Create the marker
            marker.SetPosition(new Point(0, 0));        // Set the marker's position
            cast["map_gen_marker"] = new List<Actor>(); // Create the map gen marker cast
            cast["map_gen_marker"].Add(marker);         // Add the marker to the map gen marker cast

            Actor back_marker = new Actor();           // Create the back marker
            marker.SetPosition(new Point(0, 0));       // Set the back marker's position
            cast["back_marker"] = new List<Actor>();   // Create the back marker cast
            cast["back_marker"].Add(back_marker);      // Add the back marker to the back marker cast


            // The player
            cast["character"] = new List<Actor>(); // Create the character cast

            Character character = new Character();  // Create the character
            character.SetUseGravity(true);          // Set the character to use gravity
            cast["character"].Add(character);       // Add the character to the character cast
            cast["physical_objects"].Add(character); // Add the character to the physical objects cast
            cast["movable_objects"].Add(character); // Add the character to the movable objects cast

            cast["last_known_location"] = new List<Actor>(); // Create the last known location cast
            cast["last_known_location"].Add(new Actor());    // Add the last known location to the last known location cast
 
            // Create the action list
            List<Action> actions = new List<Action>(); // Create the action list

            OutputService outputService = new OutputService(); // Create the output service
            InputService inputService = new InputService(); // Create the input service
            PhysicsService physicsService = new PhysicsService(); // Create the physics service
            AudioService audioService = new AudioService(); // Create the audio service
 

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService); // Create the draw actors action
            actions.Add(drawActorsAction); // Add the draw actors action to the action list

            // The actions here are to handle the input, move the actors, handle collisions, etc.
            MoveActorsAction moveActorsAction = new MoveActorsAction(); // Create the move actors action
            actions.Add(moveActorsAction); // Add the move actors action to the action list

            ControlActorsAction controlActorsAction = new ControlActorsAction(inputService); // Create the control actors action
            actions.Add(controlActorsAction); // Add the control actors action to the action list

            HandleCollisionsAction handleCollisionsAction = new HandleCollisionsAction(physicsService, audioService); // Create the handle collisions action
            actions.Add(handleCollisionsAction); // Add the handle collisions action to the action list

            MapGenerateAction mapGenerateAction = new MapGenerateAction(fgenerator); // Create the map generate action
            actions.Add(mapGenerateAction); // Add the map generate action to the action list

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Holes Are Bad", Constants.FRAME_RATE); // Open the window
            audioService.StartAudio(); // Start the audio
            audioService.PlaySound(Constants.SOUND_START); // Play the start sound

            Director theDirector = new Director(cast, actions, outputService, inputService); // Create the director
            theDirector.Direct(); // Direct the director

            audioService.StopAudio(); // Stop the audio
        }
    }
}

