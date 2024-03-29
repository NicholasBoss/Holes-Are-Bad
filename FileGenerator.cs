using System;
using System.Collections.Generic;
using System.IO;
using HolesAreBad.Casting;
using Weighted_Randomizer;

namespace HolesAreBad
{
    /// <summary>
    /// Generates a file with a given number of lines, each line 
    /// containing a charater that is either a hole or a block, enemy, or  collectable.
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
            List<FlyingEnemy> flyingEnemies = new List<FlyingEnemy>();
            List<Hole> holes = new List<Hole>();
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
                        cast["platforms"].Add(platform);
                        cast["physical_objects"].Add(platform);
                    }
                    else if (c.Equals('G')) // Adds Ghost Block
                    {
                        int x = (Constants.MAX_X / Constants.GRID_X) * column + xOffset;
                        int y = (Constants.MAX_Y / Constants.GRID_Y) * row;
                        GhostBlock platform = new GhostBlock();
                        platform.SetPosition(new Point(x, y));
                        cast["ghost_block"].Add(platform);
                    }
                    // Check for spikes, collectables, and other stuff
                    else if (c.Equals('A')) // Adds Spikes
                    {
                        int x = (Constants.MAX_X / Constants.GRID_X) * column + xOffset;
                        int y = (Constants.MAX_Y / Constants.GRID_Y) * row;
                        Spike spike = new Spike();
                        spike.SetPosition(new Point(x+10, y+26));
                        cast["spikes"].Add(spike);
                    }

                    else if (c.Equals('E')) // Adds Enemies
                    {
                        int x = (Constants.MAX_X / Constants.GRID_X) * column + xOffset;
                        int y = (Constants.MAX_Y / Constants.GRID_Y) * row;
                        Enemy enemy = new Enemy();
                        enemy.SetPosition(new Point(x+20, y+10));
                        enemy.SetVelocity(new Pointf(new Random().NextDouble()*(Constants.CHARACTER_SPEED+Constants.CHARACTER_SPEED)-Constants.CHARACTER_SPEED, 0));
                        enemy.SetUseGravity(true);
                        cast["enemies"].Add(enemy);
                        cast["movable_objects"].Add(enemy);
                    }

                    else if (c.Equals('C')) // Adds Collectables
                    {
                        int x = (Constants.MAX_X / Constants.GRID_X) * column + xOffset;
                        int y = (Constants.MAX_Y / Constants.GRID_Y) * row;
                        Collectable collectable = new Collectable();
                        collectable.SetPosition(new Point(x+28, y+12));
                        cast["collectables"].Add(collectable);
                    }
                    else if (c.Equals('F')) // Adds Flying Enemies
                    {
                        int x = (Constants.MAX_X / Constants.GRID_X) * column + xOffset;
                        int y = (Constants.MAX_Y / Constants.GRID_Y) * row;
                        FlyingEnemy enemy = new FlyingEnemy();
                        enemy.SetPosition(new Point(x+20, y+10));
                        enemy.SetVelocity(new Pointf(new Random().NextDouble()*(Constants.CHARACTER_SPEED+Constants.CHARACTER_SPEED)-Constants.CHARACTER_SPEED, 0));
                        cast["flying_enemies"].Add(enemy);
                        cast["movable_objects"].Add(enemy);
                    }
                    else if (c.Equals('J')) // Adds Jumping Enemies
                    {
                        int x = (Constants.MAX_X / Constants.GRID_X) * column + xOffset;
                        int y = (Constants.MAX_Y / Constants.GRID_Y) * row;
                        JumpingEnemy enemy = new JumpingEnemy();
                        enemy.SetPosition(new Point(x+20, y+10));
                        enemy.SetVelocity(new Pointf(new Random().NextDouble()*(Constants.CHARACTER_SPEED+Constants.CHARACTER_SPEED)-Constants.CHARACTER_SPEED, 0));
                        enemy.SetUseGravity(true);
                        cast["jumping_enemies"].Add(enemy);
                        cast["movable_objects"].Add(enemy);
                    }
                    else if (c.Equals('H')) // Adds Holes
                    {
                        int x = (Constants.MAX_X / Constants.GRID_X) * column + xOffset;
                        int y = (Constants.MAX_Y / Constants.GRID_Y) * row;
                        Hole hole = new Hole();
                        hole.SetPosition(new Point(x+20, y+10));
                        cast["holes"].Add(hole);
                    }
                    
                    column++;
                }
                row++;
            }
            
            return column * Constants.MAX_X / Constants.GRID_X;
        }

    }
}