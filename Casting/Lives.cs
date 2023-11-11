using System;

namespace HolesAreBad.Casting
{
    public class Lives : Actor
    {
        public static int _lives = Constants.lives;
        public Lives()
        {
            SetText($" Lives left: {_lives}");

            Point position = new Point(Constants.MAX_X-160,0);
            SetPosition(position);
        }
    }
}