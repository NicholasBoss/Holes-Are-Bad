using System;

namespace HolesAreBad
{
    /// <summary>
    /// This is a set of program wide constants to be used in other classes.
    /// </summary>
    public static class Constants
    {
        public const int MAX_X = 800;
        public const int MAX_Y = 600;
        public const int FRAME_RATE = 50;

        public const int DEFAULT_SQUARE_SIZE = 20;
        public const int DEFAULT_FONT_SIZE = 20;
        public const int DEFAULT_TEXT_OFFSET = 4;

        public const int NUM_BUSHES = 20;
        public const string DEFAULT_BILLBOARD_MESSAGE = "Default Message At top of screen.";

        // Images for the game will be initialized here
        // Primative Graphics
        // public const string IMAGE_CHARACTER = "./Assets/bluebox.png";
        // public const string IMAGE_BUSH = "./Assets/graybox.png";
        // public const string IMAGE_PENDANT = "./Assets/yellowbox.png";
        // public const string IMAGE_PENDANT1 = "./Assets/yellowbox.png";
        // public const string IMAGE_PENDANT2 = "./Assets/yellowbox.png";
        // public const string IMAGE_CHEST = "./Assets/brownbox.png";

        // Fancy Graphics
        public const string IMAGE_CHARACTER = "./Assets/player.png";
        // public const string IMAGE_BUSH = "./Assets/bush.png";
        // public const string IMAGE_PENDANT = "./Assets/pendant.png";
        // public const string IMAGE_PENDANT1 = "./Assets/pendant1.png";
        // public const string IMAGE_PENDANT2 = "./Assets/pendant2.png";
        // public const string IMAGE_CHEST = "./Assets/chest.png";


        // Sounds for the game will be initialized here
        // public const string SOUND_LEAF = "./Assets/leaf.mp3";
        // public const string SOUND_PENDANTFOUND = "./Assets/PendantFound.wav";
        // public const string SOUND_WIN = "./Assets/Win.wav";
        // public const string SOUND_START = "./Assets/Start.wav";
        // public const string SOUND_LOSE = "./Assets/Lose.wav";

        
        //Speed and position of the actors will be initialized here
        public const int CHARACTER_X = MAX_X / 2;
        public const int CHARACTER_Y = MAX_Y - 125;

        public const int CHARACTER_WIDTH = 1;
        public const int CHARACTER_HEIGHT = 1;

        public const int BUSH_WIDTH = 20;
        public const int BUSH_HEIGHT = 20;

        public const int CHARACTER_SPEED = 5;

        public const string MESSAGE_FILE = "messages.txt";
    }

}