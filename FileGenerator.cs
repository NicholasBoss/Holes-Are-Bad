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
                    else
                    {
                        // Check for spikes, collectables, and other stuff
                    }
                    column++;
                }
                row++;
            }
            
            return column * Constants.MAX_X / Constants.GRID_X;
        }

    }
}