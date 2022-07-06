using System;
using System.Collections.Generic;
using System.IO;
using HolesAreBad.Casting;

namespace HolesAreBad
{
    /// <summary>
    /// 
    /// </summary>
    public class FileGenerator
    {
        public FileGenerator()
        {
            //loadMessages();
        }
        private void FileGen()
        {
            // LoadMessages();
        }

        public int Generate(Dictionary<string, List<Actor>> cast, int xOffset)
        {
            string[] lines = System.IO.File.ReadAllLines(Constants.FILE);

            List<Platform> platforms = new List<Platform>();
            List<Spike> spikes = new List<Spike>();
            List<Enemy> enemies = new List<Enemy>();
            int row = 0;
            int column = 0;
            foreach (string line in lines)
            {
                column = 0;
                foreach (char c in line)
                {
                    if (c.Equals('X'))
                    {
                        int x = (Constants.MAX_X / Constants.GRID_X) * column + xOffset;
                        int y = (Constants.MAX_Y / Constants.GRID_Y) * row;
                        Platform platform = new Platform();
                        platform.SetPosition(new Point(x, y));
                        platform.SetImage(Constants.IMAGE_PLATFORM);
                        cast["platforms"].Add(platform);
                        cast["physical_objects"].Add(platform);
                    }
                    // Check for spikes, collectables, and other stuff
                    else if (c.Equals('A'))
                    {
                        int x = (Constants.MAX_X / Constants.GRID_X) * column + xOffset;
                        int y = (Constants.MAX_Y / Constants.GRID_Y) * row;
                        Spike spike = new Spike();
                        spike.SetPosition(new Point(x+20, y+25));
                        spike.SetImage(Constants.IMAGE_SPIKE);
                        cast["spikes"].Add(spike);
                    }

                    else if (c.Equals('E'))
                    {
                        int x = (Constants.MAX_X / Constants.GRID_X) * column + xOffset;
                        int y = (Constants.MAX_Y / Constants.GRID_Y) * row;
                        Enemy enemy = new Enemy();
                        enemy.SetPosition(new Point(x, y));
                        enemy.SetImage(Constants.IMAGE_ENEMY);
                        cast["enemies"].Add(enemy);
                    }
                    column++;
                }
                row++;
            }
            
            return column * Constants.MAX_X / Constants.GRID_X;
        }

    }
}