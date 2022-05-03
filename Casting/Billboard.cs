using System;

namespace HolesAreBad.Casting
{
    /// <summary>
    /// Defines the Billboard that displays the description of the artifacts.
    /// </summary>
    public class Billboard : Actor
    {
        public Billboard()
        {
            SetText(Constants.DEFAULT_BILLBOARD_MESSAGE);

            Point position = new Point(0, 0);
            SetPosition(position);
        }
    }
}