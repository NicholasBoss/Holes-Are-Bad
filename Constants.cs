using System;
using System.Collections.Generic;

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
        public const int NUM_ENEMIES = 1;
        public const string DEFAULT_BILLBOARD_MESSAGE = "Use A, D and spacebar to move.";
        
        // File setup for the level
        public const int GRID_X = 25;
        public const int GRID_Y = 25;
        public const string FILE = "./Assets/Level_Design/Segment2.txt";
        private const string segmentDir = "./Assets/Level_Design/";
        public static Dictionary<string, int> LEVEL1LIST = new Dictionary<string, int>()
        {
            {segmentDir+"Segment1.txt", 1},
            {segmentDir+"Segment2.txt", 2},
            {segmentDir+"Segment3.txt", 3},
            {segmentDir+"Segment4.txt", 4},
            {segmentDir+"Segment5.txt", 5},
        };


        // Images for the game will be initialized here
        // Primitive Graphics
        // public const string IMAGE_CHARACTER = "./Assets/bluebox.png";
        public const string IMAGE_HOLE = "./Assets/Enemies/Hole_lvl_1.png";
        // public const string IMAGE_PENDANT = "./Assets/yellowbox.png";
        // public const string IMAGE_PENDANT1 = "./Assets/yellowbox.png";
        // public const string IMAGE_PENDANT2 = "./Assets/yellowbox.png";
        // public const string IMAGE_CHEST = "./Assets/brownbox.png";

        // Fancy Graphics
        public const string IMAGE_CHARACTER = "./Assets/Character/player.png";
        public const string IMAGE_ENEMY = "./Assets/Enemies/Flying_Enemy_lvl_2.png";
        public const string IMAGE_SPIKE_ROW = "./Assets/Good/Spike_Row.png";
        public const string IMAGE_SPIKE = "./Assets/Good/Spike.png";
        public const string IMAGE_BACKGROUND = "./Assets/Backgrounds/Vaporwave_Background_Sample_Real_big.gif";
        public const string IMAGE_BLUE_STUDDED_BLOCK = "./Assets/Platforms/Blue_Studded_Block.png";
        public const string IMAGE_PINK_STUDDED_BLOCK = "./Assets/Platforms/Pink_Studded_Block.png";
        public const string IMAGE_PLATFORM = "./Assets/Platforms/Blue_Studded_Block_FAT.png";
        // public const string IMAGE_BUSH = "./Assets/bush.png";
        // public const string IMAGE_PENDANT = "./Assets/pendant.png";
        // public const string IMAGE_PENDANT1 = "./Assets/pendant1.png";
        // public const string IMAGE_PENDANT2 = "./Assets/pendant2.png";
        // public const string IMAGE_CHEST = "./Assets/chest.png";


        // Sounds for the game will be initialized here
        // public const string SOUND_LEAF = "./Assets/leaf.mp3";
        // public const string SOUND_PENDANTFOUND = "./Assets/PendantFound.wav";
        // public const string SOUND_WIN = "./Assets/Win.wav";
        public const string SOUND_START = "./Assets/Music/i_think_i_like_you.mp3";
        // public const string SOUND_LOSE = "./Assets/Lose.wav";

        
        //Speed and position of the actors will be initialized here
        public const int CHARACTER_X = MAX_X / 2;
        public const int CHARACTER_Y = MAX_Y - 125;

        public const int CHARACTER_WIDTH = 16;
        public const int CHARACTER_HEIGHT = 29;

        public const int ENEMY_WIDTH = 36;
        public const int ENEMY_HEIGHT = 21;

        public const int HOLE_WIDTH = 35;
        public const int HOLE_HEIGHT = 25;

        public const int PLATFORM_WIDTH = 64;
        public const int PLATFORM_HEIGHT = 36;

        public const int SPIKE_WIDTH = 32;
        public const int SPIKE_HEIGHT = 32;

        public const int CHARACTER_SPEED = 6;
        public const int JUMP_POWER = 20;
        public const double GRAVITY = .99;
        public const double TERMINAL_VELOCITY = 30;

        public const double SCROLL_THRESHOLD_FORWARD = 0.55; // Percentage of screen before beginning to scroll screen forward. Must be greater than 0.5 (50%).
        public const double SCROLL_THRESHOLD_BACKWARD = 0.2; // Percentage of screen before beginning to scroll screen forward. Must be less than 0.5 (50%).

        public const string MESSAGE_FILE = "messages.txt";
    }

}