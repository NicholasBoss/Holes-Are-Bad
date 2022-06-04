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
        private List<string> _messages;
        private Random _randomGenerator = new Random();

        public EnemyGenerator()
        {
            // LoadMessages();
        }

        /// <summary>
        /// Loads messages from a file.
        /// </summary>
        private void LoadMessages()
        {
            // There are other ways to do this, including not putting it into an
            // actual List<string>, but this seemed most consistent with what we have
            // done to this point.
            string[] allLines = File.ReadAllLines(Constants.MESSAGE_FILE);

            _messages = new List<string>();
            foreach (string line in allLines)
            {
                _messages.Add(line);
            }
        }

        /// <summary>
        /// Generates a new artifact at a random location.
        /// </summary>
        /// <returns></returns>
        public Enemy Generate()
        {
            Enemy enemy = new Enemy();
            int diff = 20;
            int x = _randomGenerator.Next(20, Constants.MAX_X-diff);
            int y = _randomGenerator.Next(20, Constants.MAX_Y-diff);
            enemy.SetPosition(new Point(x, y));

            enemy.SetImage(Constants.IMAGE_ENEMY);

            // string message = GetRandomMessage();
            // enemy.SetDescription(message);

            return enemy;
        }

        /// <summary>
        /// Gets a random message from the messages file.
        /// </summary>
        /// <returns></returns>
        public string GetRandomMessage()
        {
            string message = _messages[_randomGenerator.Next(0, _messages.Count)];
            return message;
        }
    }
}