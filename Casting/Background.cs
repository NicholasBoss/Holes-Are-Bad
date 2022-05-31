using System;
using Raylib_cs;

namespace HolesAreBad.Casting
{
    /// <summary>
    /// Defines the Billboard that displays the description of the artifacts.
    /// </summary>
    public class Background : Actor
    {
        public Background()
        {
            string IMAGE_BACKGROUND = "./Assets/Vaporwave Background_Sample_Real.gif";
            //ImageCrop(IMAGE_BACKGROUND, 1600, 900);
            SetImage(IMAGE_BACKGROUND);

            Point position = new Point(1, 1);
            SetPosition(position);
        }
    }
}