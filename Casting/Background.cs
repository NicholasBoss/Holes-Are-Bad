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
            //ImageCrop(IMAGE_BACKGROUND, 1600, 900);
            SetImage(Constants.IMAGE_BACKGROUND);

            Point position = new Point(1, 1);
            SetPosition(position);
        }
    }
}