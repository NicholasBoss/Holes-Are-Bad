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
    public class EnemyGenerator
    {
        private Random _randomGenerator = new Random();

        public EnemyGenerator()
        {
            
        }


        /// <summary>
        /// Generates a new artifact at a random location.
        /// </summary>
        /// <returns></returns>
        public Enemy Generate()
        {
            Enemy enemy = new Enemy();
            int diff = 20;
            int x = _randomGenerator.Next(diff, Constants.MAX_X-diff);
            int y = _randomGenerator.Next(diff, Constants.MAX_Y-diff);
            enemy.SetPosition(new Point(x, y));

            enemy.SetImage(Constants.IMAGE_ENEMY);

            return enemy;
        }

    }
}