using HolesAreBad.Casting;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;    

namespace HolesAreBad.Scripting
{
    public class ParallaxEffect : Actor
    { 
        private int screenWidth = Constants.MAX_X; 
        private int screenHeight = Constants.MAX_Y; 

        private Texture2D foreground;
        private Texture2D midground;
        private Texture2D background;

        private string _foreground_image;
        private string _midground_image; 
        private string _background_image; 

        private float scrollingBack = 0.0f; 
        private float scrollingMid = 0.0f; 
        private float scrollingFore = 0.0f; 
        
        public ParallaxEffect(string foreground_image, string midground_image, string background_image)
        {
            foreground = LoadTexture(foreground_image);
            midground = LoadTexture(midground_image);
            background = LoadTexture(background_image);

            _foreground_image = foreground_image;
            _midground_image = midground_image;
            _foreground_image = foreground_image;

        }

        public Texture2D GetBackground()
        {
            return background; 
        }
        
        public void SetBackground(string new_background)
        {
            _background_image = new_background;
        }

        public Texture2D GetMidground()
        {
            return midground;
        }

        public void SetMidground(string new_midground)
        {
            _midground_image = new_midground; 
        }

        public Texture2D GetForeground()
        {
            return foreground;
        }

        public void SetForeground(string new_foreground)
        {
            _foreground_image = new_foreground;
        }

        public float GetScrollingBack()
        {
            return scrollingBack; 
        }

        public float GetScrollingMid()
        {
            return scrollingMid; 
        }

        public float GetScrollingFore()
        {
            return scrollingFore; 
        }

        public void CalculateParallax(float scrolling_dir)
        {
            scrollingBack -= 0.1f * scrolling_dir; 
            scrollingMid -= 0.5f * scrolling_dir; 
            scrollingFore -= 1.0f * scrolling_dir; 

            if(scrollingBack <= -background.width * 2)
            {
                scrollingBack = 0; 
            }

            if(scrollingMid <= -midground.width * 2)
            {
                scrollingMid = 0; 
            }

            if(scrollingFore <= -foreground.width * 2)
            {
                scrollingFore = 0; 
            }
        }

    }
}