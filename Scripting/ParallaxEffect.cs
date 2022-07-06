



using HolesAreBad.Casting; 

namespace HolesAreBad.Scripting
{
    public class ParallaxEffect
    {
        public ParallaxEffect()
        {
            int screenWidth = Constants.MAX_X;
            int screenHeight = Constants.MAX_Y; 

            Texture2D foreground = LoadTexture("Assets/Backgrounds/foreground_scaled.png");
            Texture2D midground = LoadTexture("Assets/Backgrounds/back-buildings_scaled.png");
            Texture2D background = LoadTexture("Assets/Backgrounds/far-buildings_scaled.png");
            float scrollingBack = 0.0f; 
            float scrollingMid = 0.0f; 
            float scrollingFore = 0.0f;
            SetTargetFPS(60);  
        }

        public void DrawParallax()
        {
            ClearBackground(GetColor(0x052c46ff));
            scrollingBack -= 0.1f; 
            scrollingMid -= 0.5f; 
            scrollingFore -= 1.0f; 

            if (scrollingBack <= -background.width * 2) 
            {
                scrollingBack = 0; 
            }

            if (scrollingBack <= -midground.width * 2)
            {
                scrollingMid = 0; 
            }

            if (scrollingFore <= -foreground.width * 2)
            {
                scrollingFore = 0; 
            }

            DrawTextureEx(background, (Vector2){ scrollingBack, 20}, 0.0f, 2.0f, WHITE);
            DrawTextureEx(background, (Vector2){ background.width*2 + scrollingBack, 20 }, 0.0f, 2.0f, WHITE);

            DrawTextureEx(midground, (Vector2){ scrollingMid, 20 }, 0.0f, 2.0f, WHITE);
            DrawTextureEx(midground, (Vector2){ midground.width*2 + scrollingMid, 20 }, 0.0f, 2.0f, WHITE);

            DrawTextureEx(foreground, (Vector2){ scrollingFore, 70 }, 0.0f, 2.0f, WHITE);
            DrawTextureEx(foreground, (Vector2){ foreground.width*2 + scrollingFore, 70 }, 0.0f, 2.0f, WHITE);
            
        }

        public void UnloadTextures()
        {
            UnloadTexture(background);
            UnloadTexture(midground);
            UnloadTexture(foreground);
        }
    }
}