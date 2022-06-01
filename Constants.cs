using System;

namespace HolesAreBad
{
    /// <summary>
    /// This is a set of program wide constants to be used in other classes.
    /// </summary>
    public static class Constants
    {
        public const int MAX_X = 1600;
        public const int MAX_Y = 900;
        public const int FRAME_RATE = 60;

        public const int DEFAULT_SQUARE_SIZE = 20;
        public const int DEFAULT_FONT_SIZE = 20;
        public const int DEFAULT_TEXT_OFFSET = 4;

        public const int NUM_HOLES = 20;
        public const int NUM_ENEMIES = 5;
        public const string DEFAULT_BILLBOARD_MESSAGE = "Use A, D and spacebar to move.";

        // Images for the game will be initialized here
        // Primitive Graphics
        // public const string IMAGE_CHARACTER = "./Assets/bluebox.png";
        public const string IMAGE_HOLE = "./Assets/graybox.png";
        // public const string IMAGE_PENDANT = "./Assets/yellowbox.png";
        // public const string IMAGE_PENDANT1 = "./Assets/yellowbox.png";
        // public const string IMAGE_PENDANT2 = "./Assets/yellowbox.png";
        // public const string IMAGE_CHEST = "./Assets/brownbox.png";

        // Fancy Graphics
        public const string IMAGE_CHARACTER = "./Assets/player.png";
        public const string IMAGE_ENEMY = "./Assets/Bad_Dude_1.png";
        public const string IMAGE_SPIKE_ROW = "./Assets/Spike_Row.png";
        public const string IMAGE_SPIKE = "./Assets/Spike.png";
        public const string IMAGE_BACKGROUND = "./Assets/Vaporwave Background_Sample_Real.gif";
        public const string IMAGE_BLUE_STUDDED_BLOCK = "./Assets/Blue Studded Block.png";
        public const string IMAGE_PINK_STUDDED_BLOCK = "./Assets/Pink Studded Block.png";
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

        public const int CHARACTER_WIDTH = 5;
        public const int CHARACTER_HEIGHT = 5;

        public const int ENEMY_WIDTH = 5;
        public const int ENEMY_HEIGHT = 5;

        public const int HOLE_WIDTH = 20;
        public const int HOLE_HEIGHT = 20;

        public const int CHARACTER_SPEED = 5;

        public const string MESSAGE_FILE = "messages.txt";
    }

}