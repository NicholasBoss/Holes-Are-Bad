using System;
using Raylib_cs;
using System.Collections.Generic;

namespace HolesAreBad.Services
{
    /// <summary>
    /// Handles all the audio elements the game.
    /// </summary>
    public class AudioService
    {
        private Dictionary<string, Raylib_cs.Sound> _sounds
            = new Dictionary<string, Raylib_cs.Sound>();
        
        public AudioService()
        {

        }

        /// <summary>
        /// Plays the sound stored in the provided .wav file.
        /// </summary>
        /// <param name="filename">The path to the .wav file</param>
        public void PlaySound(string filename)
        {
            if (!_sounds.ContainsKey(filename))
            {
                Raylib_cs.Sound loaded = Raylib.LoadSound(filename);
                _sounds[filename] = loaded;
            }
            Raylib_cs.Sound sound = _sounds[filename];
            Raylib.PlaySound(sound);
        }

        /// <summary>
        /// Initializes the audio device.
        /// </summary>
        public void StartAudio()
        {
            Raylib.InitAudioDevice();
        }

        /// <summary>
        /// Closes down the audio device.
        /// </summary>
        public void StopAudio()
        {
            Raylib.CloseAudioDevice();
        }
 
   }

}