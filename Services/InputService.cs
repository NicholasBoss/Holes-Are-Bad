using System;
using Raylib_cs;

using HolesAreBad.Casting;

namespace HolesAreBad.Services
{
    /// <summary>
    /// Handles all the interaction with the user input library.
    /// </summary>
    public class InputService
    {
        public InputService()
        {

        }

        public bool IsLeftPressed()
        {
            return Raylib.IsKeyDown(Raylib_cs.KeyboardKey.KEY_A);
        }

        public bool IsRightPressed()
        {
            return Raylib.IsKeyDown(Raylib_cs.KeyboardKey.KEY_D);
        }
        public bool IsUpPressed()
        {
            return Raylib.IsKeyDown(Raylib_cs.KeyboardKey.KEY_W);
        }
        public bool IsDownPressed()
        {
            return Raylib.IsKeyDown(Raylib_cs.KeyboardKey.KEY_S);
        }
        public bool IsSpacePressed()
        {
            return Raylib.IsKeyDown(Raylib_cs.KeyboardKey.KEY_SPACE);
        }
        public bool IsKeyRPressed()
        {
            return Raylib.IsKeyDown(Raylib_cs.KeyboardKey.KEY_R);
        }

        /// <summary>
        /// Gets the direction asked for by the current key presses
        /// </summary>
        /// <returns></returns>
        public Point GetDirection()
        {
            int x = 0;
            int y = 0;

            if (IsLeftPressed())
            {
                x += -1;
            }

            if (IsRightPressed())
            {
                x += 1;
            }
            
            if (IsUpPressed() || IsSpacePressed())
            {
                y += -1;
            }
            
            return new Point(x, y);
        }

        /// <summary>
        /// Returns true if the user has attempted to close the window.
        /// </summary>
        /// <returns></returns>
        public bool IsWindowClosing()
        {
            return Raylib.WindowShouldClose();
        }
    }

}