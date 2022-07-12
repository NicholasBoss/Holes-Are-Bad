using System;
namespace HolesAreBad.Casting
{
    ///<summary>
    /// This class will handle all needed action with implementing the character of the game
    ///<summary>
    public class Enemy : Actor
    {
        private string _charimg = Constants.IMAGE_ENEMY;
        private int _charwidth = Constants.ENEMY_WIDTH;
        private int _charheight = Constants.ENEMY_HEIGHT;
        private double[] lastKnownYs;
        private int lastKnownYsI;
        public Enemy()
        {
            lastKnownYs = new double[5]{0, 0, 0, 0, 0};
            lastKnownYsI = 0;
            SetImage(_charimg);
            SetHeight(_charheight);
            SetWidth(_charwidth);
            SetJumpReady(true);
        }

        private double GetMedian(double[] sourceNumbers) {
            double[] sortedPNumbers = (double[])sourceNumbers.Clone();
            Array.Sort(sortedPNumbers);

            int size = sortedPNumbers.Length;
            int mid = size / 2;
            double median = (size % 2 != 0) ? (double)sortedPNumbers[mid] : ((double)sortedPNumbers[mid] + (double)sortedPNumbers[mid - 1]) / 2;
            return median;
        }

        public bool isYDifferent(double y){
            double median = GetMedian(lastKnownYs);
            if (median == 0) {
                return false;
            }
            foreach (double d in lastKnownYs) {
                if (d == 0) {
                    return false;
                }
            }
            if (median < y - y * 0.1 || median > y + y * 0.1){
                lastKnownYs = new double[5]{0, 0, 0, 0, 0};
                return true;
            }
            return false;
        }

        public void addYPos(double y){
            lastKnownYs[lastKnownYsI] = y;
            lastKnownYsI = (lastKnownYsI + 1) % 5;
        }
    }
}