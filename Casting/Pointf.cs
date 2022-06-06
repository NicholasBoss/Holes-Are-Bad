using System;

namespace HolesAreBad.Casting
{
    /// <summary>
    /// Represents an X, Y pair.
    /// 
    /// This can be used for both a location and also a velocity.
    /// </summary>
    public class Pointf
    {
        private double _x;
        private double _y;

        public Pointf(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public double GetX()
        {
            return _x;
        }

        public double GetY()
        {
            return _y;
        }

        /// <summary>
        /// Returns a new Pointf that is the result of adding this one to the provided one.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Pointf Add(Pointf other)
        {
            double newX = _x + other._x;
            double newY = _y + other._y;

            return new Pointf(newX, newY);
        }

        /// <summary>
        /// Returns a new Pointf that is the reversed version of this one.
        /// Both X and Y are multiplied by -1.
        /// </summary>
        /// <returns></returns>
        public Pointf Reverse()
        {
            return Scale(-1);
        }

        /// <summary>
        /// Scales the Pointf by the factor provided. Multiplies both X and Y
        /// by the amount.
        /// </summary>
        /// <param name="factor"></param>
        /// <returns></returns>
        public Pointf Scale(int factor)
        {
            double newX = _x * factor;
            double newY = _y * factor;

            return new Pointf(newX, newY);
        }

        /// <summary>
        /// Used by the system when you use == to compare the Pointfs.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Pointf Pointf &&
                   _x == Pointf._x &&
                   _y == Pointf._y;
        }

        // If you ever override the Equals function, you should also override the GetHashCode function
        public override int GetHashCode()
        {
            return HashCode.Combine(_x, _y);
        }
    }

}