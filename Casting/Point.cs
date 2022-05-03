using System;

namespace HolesAreBad.Casting
{
    /// <summary>
    /// Represents an X, Y pair.
    /// 
    /// This can be used for both a location and also a velocity.
    /// </summary>
    public class Point
    {
        private int _x;
        private int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int GetX()
        {
            return _x;
        }

        public int GetY()
        {
            return _y;
        }

        /// <summary>
        /// Returns a new point that is the result of adding this one to the provided one.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Point Add(Point other)
        {
            int newX = _x + other._x;
            int newY = _y + other._y;

            return new Point(newX, newY);
        }

        /// <summary>
        /// Returns a new point that is the reversed version of this one.
        /// Both X and Y are multiplied by -1.
        /// </summary>
        /// <returns></returns>
        public Point Reverse()
        {
            return Scale(-1);
        }

        /// <summary>
        /// Scales the point by the factor provided. Multiplies both X and Y
        /// by the amount.
        /// </summary>
        /// <param name="factor"></param>
        /// <returns></returns>
        public Point Scale(int factor)
        {
            int newX = _x * factor;
            int newY = _y * factor;

            return new Point(newX, newY);
        }

        /// <summary>
        /// Used by the system when you use == to compare the points.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   _x == point._x &&
                   _y == point._y;
        }

        // If you ever override the Equals function, you should also override the GetHashCode function
        public override int GetHashCode()
        {
            return HashCode.Combine(_x, _y);
        }
    }

}