using System;
using System.Collections.Generic;
using System.IO;
using HolesAreBad.Casting;
using Weighted_Randomizer;

namespace HolesAreBad
{
    /// <summary>
    /// 
    /// </summary>
    public class FileGenerator
    {
        private StaticWeightedRandomizer<string> randomizerLevel1;
        private StaticWeightedRandomizer<string> randomizerLevel2;

        public FileGenerator()
        {
            randomizerLevel1 = new StaticWeightedRandomizer<string>();
            foreach (var item in Constants.LEVEL1LIST) {
                randomizerLevel1.Add(item.Key, item.Value);
            }
        }
        private void FileGen()
        {
            // LoadMessages();
        }

        public int Generate(Dictionary<string, List<Actor>> cast, int xOffset)
        {
            string[] lines = System.IO.File.ReadAllLines(randomizerLevel1.NextWithReplacement());

            List<Platform> platforms = new List<Platform>();
            List<Spike> spikes = new List<Spike>();
            List<Enemy> enemies = new List<Enemy>();
            List<Collectable> collectables = new List<Collectable>();
            int row = 0;
            int column = 0;
            foreach (string line in lines)
            {
                column = 0;
                foreach (char c in line)
                {
                    if (c.Equals('X')) // Adds Platforms
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
                    else if (c.Equals('A')) // Adds Spikes
                    {
                        int x = (Constants.MAX_X / Constants.GRID_X) * column + xOffset;
                        int y = (Constants.MAX_Y / Constants.GRID_Y) * row;
                        Spike spike = new Spike();
                        spike.SetPosition(new Point(x+20, y+25));
                        spike.SetImage(Constants.IMAGE_SPIKE);
                        cast["spikes"].Add(spike);
                    }

                    else if (c.Equals('E')) // Adds Enemies
                    {
                        int x = (Constants.MAX_X / Constants.GRID_X) * column + xOffset;
                        int y = (Constants.MAX_Y / Constants.GRID_Y) * row;
                        Enemy enemy = new Enemy();
                        enemy.SetPosition(new Point(x, y));
                        enemy.SetImage(Constants.IMAGE_ENEMY);
                        cast["enemies"].Add(enemy);
                    }

                    else if (c.Equals('C')) // Adds Collectables
                    {
                        int x = (Constants.MAX_X / Constants.GRID_X) * column + xOffset;
                        int y = (Constants.MAX_Y / Constants.GRID_Y) * row;
                        Collectable collectable = new Collectable();
                        collectable.SetPosition(new Point(x, y));
                        collectable.SetImage(Constants.IMAGE_COLLECTABLE);
                        cast["collectables"].Add(collectable);
                    }
                    column++;
                }
                row++;
            }
            
            return column * Constants.MAX_X / Constants.GRID_X;
        }

    }
}