using System.Collections.Generic;
using HolesAreBad.Casting;
using HolesAreBad.Services;

namespace HolesAreBad.Scripting
{
    ///<summary>
    /// This class will control how each actor will act when collided with.
    ///<summary>
    public class HandleCollisionsAction : Action
    {
        PhysicsService _physicsService;
        AudioService _audioService;
        private int delay = 0;
        private bool _lose = false;

        public HandleCollisionsAction(PhysicsService physicsService, AudioService audioService)
        {
            _physicsService = physicsService;
            _audioService = audioService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor billboard = cast["environment"][0];
            // Actor tries = cast["environment"][1];
            // Actor character = cast["character"][0];
            // Actor chest = cast["chest"][0];
            
            // List<Actor> bushes = cast["bushes"];
            // List<Actor> pendants = cast["pendants"];
            // List<Actor> bushesToRemove = new List<Actor>();
            
            

            billboard.SetText(Constants.DEFAULT_BILLBOARD_MESSAGE);

            // // This checks to see if the player collides with a bush
            // foreach(Actor actor in bushes)
            // {
            //     Bush bush = (Bush)actor;
            //     if(_physicsService.IsCollision(character, bush))
            //     {
            //         _audioService.PlaySound(Constants.SOUND_LEAF);
            //         string bushText = bush.GetDescription();
            //         billboard.SetText(bushText);
            //         bushesToRemove.Add(bush);
            //     }
            // }

            // while(delay > 5)
            // {
            //     delay -= 1;
            // }

            // if (delay == 5)
            // {
            //     _audioService.PlaySound(Constants.SOUND_LOSE);
            //     System.Threading.Thread.Sleep(2000);
            //     Director._keepPlaying = false;
            // }

            // This will be a lose condition
            // if(bushes.Count == Constants.NUM_BUSHES-15)
            // {
            //     billboard.SetText("Sorry, you lose. Better luck next time");
            //     System.Threading.Thread.Sleep(2000);
            //     delay = 7;
            // }


            // This removes the bushes from the game once they've been searched.
            // foreach(Actor bush in bushesToRemove)
            // {
            //     cast["bushes"].Remove(bush);
            //     tries.SetText($"Tries left: {Tries.tries -= 1}");
            // }

            // This checks to see if the player collides with a pendant hiding spot
            // foreach (Actor actor in pendants)
            // {
            //     Bush pendant1 = (Bush)pendants[0];
            //     Bush pendant2 = (Bush)pendants[1];
            //     Bush pendant3 = (Bush)pendants[2];
                
            //     if(_physicsService.IsCollision(character,pendant1))
            //     {
            //         _audioService.PlaySound(Constants.SOUND_PENDANTFOUND);
            //         string pendantText = pendant1.GetDescription();
            //         billboard.SetText(pendantText);
            //         pendant1.SetImage(Constants.IMAGE_PENDANT);
            //         pendant1.IsFound();
                    
            //     }
            //     else if(_physicsService.IsCollision(character,pendant2))
            //     {
            //         _audioService.PlaySound(Constants.SOUND_PENDANTFOUND);
            //         string pendantText1 = pendant2.GetDescription();
            //         billboard.SetText(pendantText1);
            //         pendant2.SetImage(Constants.IMAGE_PENDANT1);
            //         pendant2.IsFound();
                    
            //     }
            //     else if(_physicsService.IsCollision(character,pendant3))
            //     {
            //         _audioService.PlaySound(Constants.SOUND_PENDANTFOUND);
            //         string pendantText2 = pendant3.GetDescription();
            //         billboard.SetText(pendantText2);
            //         pendant3.SetImage(Constants.IMAGE_PENDANT2);
            //         pendant3.IsFound();
                    
            //     }

                
            // }
            
            // This loop is to check for images to handle the win condition
            // foreach(Actor actor in pendants)
            // {
            //     Actor pendant1 = pendants[0];
            //     Actor pendant2 = pendants[1];
            //     Actor pendant3 = pendants[2];

            //     if(pendant1.GetImage() == Constants.IMAGE_PENDANT && pendant2.GetImage() == Constants.IMAGE_PENDANT1 && pendant3.GetImage() == Constants.IMAGE_PENDANT2)
            //     {
            //         billboard.SetText("You have found all three pendants. Open the chest to Win! \n Press 'ESC' to leave the game");
            //         chest.SetImage(Constants.IMAGE_CHEST);
            //         chest.SetHeight(10);
            //         chest.SetWidth(10);
            //         foreach(Actor bush in bushes)
            //         {
            //             bush.SetHeight(0);
            //             bush.SetWidth(0);
            //         }
            //     }
            // }
            // if(_physicsService.IsCollision(character,chest))
            // {
            //     _audioService.PlaySound(Constants.SOUND_WIN);
            //     System.Threading.Thread.Sleep(2000);
            //     Director._keepPlaying = false;
            // }

        }
    }
}