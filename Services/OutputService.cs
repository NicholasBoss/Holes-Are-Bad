using System;
using System.Collections.Generic;
using Raylib_cs;
using HolesAreBad.Casting;
using HolesAreBad.Scripting;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using System.Numerics;    

namespace HolesAreBad.Services
{
    /// <summary>
    /// Handles all the interaction with the drawing library.
    /// </summary>
    public class OutputService
    {
        private Raylib_cs.Color _backgroundColor = Raylib_cs.Color.LIME;
        private Dictionary<string, Raylib_cs.Texture2D> _textures
            = new Dictionary<string, Raylib_cs.Texture2D>();

        public OutputService()
        {

        }

        /// <summary>
        /// Opens a new window with the specified coordinates and title.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="title"></param>
        /// <param name="frameRate"></param>
        public void OpenWindow(int width, int height, string title, int frameRate)
        {
            Raylib.InitWindow(width, height, title);
            Raylib.SetTargetFPS(frameRate);
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }

        /// <summary>
        /// Starts the drawing process. This should be called
        /// before any draw commands.
        /// </summary>
        public void StartDrawing()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(_backgroundColor);
        }

        /// <summary>
        /// This finishes the drawing process. This should be called
        /// after all draw commands are finished.
        /// </summary>
        public void EndDrawing()
        {
            Raylib.EndDrawing();
        }

        /// <summary>
        /// Draws a rectangular box on the screen at the provided coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawBox(int x, int y, int width, int height)
        {
            Raylib.DrawRectangle(x, y, width, height, Raylib_cs.Color.BLUE);            
        }

        /// <summary>
        /// Draws an image at the specified coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="image">The path to the image file</param>
        public void DrawImage(int x, int y, string image)
        {
            if (!_textures.ContainsKey(image))
            {
                Raylib_cs.Texture2D loaded = Raylib.LoadTexture(image);
                _textures[image] = loaded;
            }

            Raylib_cs.Texture2D texture = _textures[image];
            Raylib.DrawTexture(texture, x, y, Raylib_cs.Color.WHITE);
        }

        /// <summary>
        /// Displays text on the screen at the provided coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="text"></param>
        /// <param name="darkText"></param>
        public void DrawText(int x, int y, string text)
        {
            Raylib_cs.Color color = Raylib_cs.Color.WHITE;

            Raylib.DrawText(text,
                x + Constants.DEFAULT_TEXT_OFFSET,
                y + Constants.DEFAULT_TEXT_OFFSET,
                Constants.DEFAULT_FONT_SIZE,
                color);
        }

        /// <summary>
        /// Draws a single actor.
        /// </summary>
        /// <param name="actor"></param>
        public void DrawActor(Actor actor)
        {
            int x = actor.GetX();
            int y = actor.GetY();
            int width = actor.GetWidth();
            int height = actor.GetHeight();


            if (actor.HasImage())
            {
                string image = actor.GetImage();
                DrawImage(x, y, image);
            }
            else if (actor.HasText())
            {
                bool darkText = true;
                string text = actor.GetText();
                DrawText(x, y, text);
            }
            else
            {
                DrawBox(x, y, width, height);
            }
        }

        /// <summary>
        /// Draws all actors in the list.
        /// </summary>
        /// <param name="actors"></param>
        public void DrawActors(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                DrawActor(actor);
            }
        }

        public void DrawParallax(ParallaxEffect parallax, string background_image, string foreground_image, string midground_image)
        {   

            parallax.CalculateParallax();
            parallax.SetBackground(background_image);
            parallax.SetForeground(foreground_image);
            parallax.SetMidground(midground_image); 
            Texture2D _background = parallax.GetBackground(); 
            Texture2D _midground = parallax.GetMidground(); 
            Texture2D _foreground = parallax.GetForeground(); 

            float _scrollingBack = parallax.GetScrollingBack(); 
            float _scrollingMid = parallax.GetScrollingMid(); 
            float _scrollingFore = parallax.GetScrollingFore(); 

            // Far background
            DrawTextureEx(_background, new Vector2(_scrollingBack, 20), 0.0f, 2.0f, Raylib_cs.Color.WHITE);
            DrawTextureEx(_background, new Vector2(_background.width * 2 + _scrollingBack, 20), 0.0f, 2.0f, Raylib_cs.Color.WHITE);

            // Mid background
            DrawTextureEx(_midground, new Vector2(_scrollingMid, 20), 0.0f, 2.0f, Raylib_cs.Color.WHITE);
            DrawTextureEx(_midground, new Vector2(_midground.width * 2 + _scrollingMid, 20), 0.0f, 2.0f, Raylib_cs.Color.WHITE);

            //Foreground 
            DrawTextureEx(_foreground, new Vector2(_scrollingFore, 20), 0.0f, 2.0f, Raylib_cs.Color.WHITE);
            DrawTextureEx(_foreground, new Vector2(_foreground.width * 2 + _scrollingFore, 20), 0.0f, 2.0f, Raylib_cs.Color.WHITE);

        }
        
        public void DrawSprite(SpriteAnimations sprite)
        {
            Texture2D _sprite = sprite.GetCharacter(); 
            float _width = sprite.GetWidth();
            float _height = sprite.GetHeight();  
            
        }

    }

}