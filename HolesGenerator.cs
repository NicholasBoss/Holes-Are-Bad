using System;
using System.Collections.Generic;
using System.IO;
using HolesAreBad.Casting;

namespace HolesAreBad
{
    /// <summary>
    /// This class is used to generate new artifacts, pulling their
    /// messages from the message file.
    /// </summary>
    public class HolesGenerator
    {
        private Random _randomGenerator = new Random();

        public HolesGenerator()
        {
            // LoadMessages();
        }

        /// <summary>
        /// Generates a new artifact at a random location.
        /// </summary>
        /// <returns></returns>
        public Hole hGenerate()
        {
            Hole hole = new Hole();
            int diff = Constants.MAX_X - Constants.MAX_Y;
            int x = _randomGenerator.Next(20, Constants.MAX_X-diff);
            int y = _randomGenerator.Next(20, Constants.MAX_X-diff);
            hole.SetPosition(new Point(x, y));

            hole.SetImage(Constants.IMAGE_HOLE);
            
            return hole;
        }
    }
}