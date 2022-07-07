using HolesAreBad.Scripting; 
using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using static Raylib_cs.KeyboardKey;

namespace HolesAreBad.Casting
{
    
    public class SpriteAnimations
    {
        
    private Texture2D character = Raylib_cs.Raylib.LoadTexture("Assets/Character/red-hood.png");
        
        public SpriteAnimations() 
        {              
        }

        public Texture2D GetCharacter()
        {
            return character;
        }

        public float GetWidth()
        {
            float frameWidth = (character.width / 12);
            return frameWidth;
        }

        public float GetHeight()
        {
            float frameHeight = (character.height / 8);
            return frameHeight; 
        }

        public void InitSprite()
        {
            
        }

    }

}