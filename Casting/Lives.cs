using System;

namespace HolesAreBad.Casting
{
    public class Lives : Actor
    {
        public static int lives = 15;
        public Lives()
        {
            SetText($" Lives left: {lives}");

            Point position = new Point(Constants.MAX_X-160,0);
            SetPosition(position);
        }
    }
}