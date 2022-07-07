using HolesAreBad.Casting;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;    

namespace HolesAreBad.Scripting
{
    public class ParallaxEffect
    { 
        private int screenWidth = Constants.MAX_X; 
        private int screenHeight = Constants.MAX_Y; 

        private Texture2D foreground = LoadTexture("Assets/Backgrounds/foreground_scaled.png");
        private Texture2D midground = LoadTexture("Assets/Backgrounds/back-buildings_scaled.png");
        private Texture2D background = LoadTexture("Assets/Backgrounds/far-buildings_scaled.png");

        private float scrollingBack = 0.0f; 
        private float scrollingMid = 0.0f; 
        private float scrollingFore = 0.0f; 
        public ParallaxEffect()
        {
        }

        public Texture2D GetBackground()
        {
            return background; 
        }

        public Texture2D GetMidground()
        {
            return midground;
        }

        public Texture2D GetForeground()
        {
            return foreground;
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

        public void CalculateParallax()
        {
            scrollingBack -= 0.1f; 
            scrollingMid -= 0.5f; 
            scrollingFore -= 1.0f; 

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