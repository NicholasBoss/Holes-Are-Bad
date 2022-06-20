using System.Collections.Generic;
using HolesAreBad.Casting;
using HolesAreBad.Services;
using System.Linq;

namespace HolesAreBad.Scripting
{
    ///<summary>
    /// This class will control how each actor will act when collided with.
    ///<summary>
    public class HandleCollisionsAction : UpdateAction
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
            Actor billboard = cast["environment"][1];
            Actor lives = cast["environment"][2];
            Actor character = cast["character"][0];
            Actor enemy = cast["enemies"][0];
            List<Actor> holes = cast["holes"];
            // Actor chest = cast["chest"][0];
            
            // List<Actor> bushes = cast["bushes"];
            // List<Actor> pendants = cast["pendants"];
            List<Actor> holesToRemove = new List<Actor>();
            
            

            billboard.SetText(Constants.DEFAULT_BILLBOARD_MESSAGE);

            // This checks to see if the player collides with a bush
            foreach(Actor actor in holes)
            {
                Hole hole = (Hole)actor;
                if(_physicsService.IsCollision(character, hole))
                {
                    // _audioService.PlaySound(Constants.SOUND_LEAF);
                    // string bushText = bush.GetDescription();
                    // billboard.SetText(bushText);
                    holesToRemove.Add(hole);
                }
            }

            while(delay > 5)
            {
                delay -= 1;
            }

            if (delay == 5)
            {
                // _audioService.PlaySound(Constants.SOUND_LOSE);
                System.Threading.Thread.Sleep(2000);
                Director._keepPlaying = false;
            }

            // This will be a lose condition
            if(holes.Count == Constants.NUM_HOLES-15)
            {
                billboard.SetText("Sorry, you lose. Better luck next time");
                System.Threading.Thread.Sleep(200);
                delay = 5;
            }


            // This removes the bushes from the game once they've been searched.
            foreach(Actor hole in holesToRemove)
            {
                cast["holes"].Remove(hole);
                lives.SetText($"Lives left: {Lives.lives -= 1}");
            }

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

            foreach (Actor c in cast["character"])
            {
                c.SetJumpReady(false);
            }
            foreach (Actor actor1 in cast["movable_objects"])
            {
                foreach (Actor actor2 in cast["physical_objects"])
                {
                    if (actor1 != actor2) {
                        if (_physicsService.IsCollision(actor1, actor2) && actor1.HasBox() && actor2.HasBox()) 
                        {
                            int leftShift = actor1.GetRightEdge() - actor2.GetLeftEdge(); // how much actor1 needs to shift to the left to avoid collision
                            int rightShift = actor2.GetRightEdge() - actor1.GetLeftEdge();// how much actor2 needs to shift to the right to avoid collision
                            int upShift = actor1.GetBottomEdge() - actor2.GetTopEdge();// how much actor1 needs to shift up to avoid collision
                            int downShift = actor2.GetBottomEdge() - actor1.GetTopEdge();// how much actor2 needs to shift down to avoid collision

                            int shift = new int[] {leftShift, rightShift, upShift, downShift}.Min();// which shift is the smallest?
                            if (shift == int.MaxValue) shift = 0;// if all shifts are infinite, don't shift anything
                            if (shift == upShift) // This will be by far the most common case so it goes first
                            {
                                actor1.SetVelocity(new Pointf(actor1.GetVelocity().GetX(), 0));
                                actor1.SetPosition(new Point(actor1.GetPosition().GetX(), actor1.GetPosition().GetY() - upShift));
                                actor1.SetJumpReady(true);
                            }
                            else if (shift == leftShift)
                            {
                                actor1.SetPosition(new Point(actor1.GetPosition().GetX() - leftShift, actor1.GetPosition().GetY()));
                            }
                            else if (shift == rightShift){
                                actor1.SetPosition(new Point(actor1.GetPosition().GetX() + rightShift, actor1.GetPosition().GetY()));
                            }
                            else if (shift == downShift) {
                                actor1.SetVelocity(new Pointf(actor1.GetVelocity().GetX(), 0));
                                actor1.SetPosition(new Point(actor1.GetPosition().GetX(), actor1.GetPosition().GetY() + downShift));
                            }
                        }
                    }
                }
            }
        }
    }
}