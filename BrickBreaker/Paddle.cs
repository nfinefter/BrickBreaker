using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrickBreaker
{
    class Paddle : Sprite
    {
        public Paddle (Vector2 position, Texture2D texture, Vector2 scale, Color tint, Vector2 speed) 
            : base (position, texture, scale, tint, speed)
        {

        }
    }
}
