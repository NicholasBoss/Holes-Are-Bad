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

        public List<Platform> Generate()
        {
            string[] lines = System.IO.File.ReadAllLines(Constants.FILE);
            List<Platform> platforms = new List<Platform>();
            int row = 0;
            int column = 0;
            foreach (string line in lines)
            {
                column = 0;
                foreach (char c in line)
                {
                    if (c.Equals('X'))
                    {
                        int x = (Constants.MAX_X / Constants.GRID_X) * column;
                        int y = (Constants.MAX_Y / Constants.GRID_Y) * row;
                        Platform platform = new Platform();
                        platform.SetPosition(new Point(x, y));
                        platform.SetImage(Constants.IMAGE_PLATFORM);
                        platforms.Add(platform);
                    }
                    else
                    {
                        // Check for spikes, collectables, and other stuff
                    }
                    column++;
                }
                row++;
            }

            return platforms;
        }

    }
}