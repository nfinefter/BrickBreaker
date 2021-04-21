using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Text;

namespace BrickBreaker
{
    class Brick : Sprite
    {
        public Brick(Vector2 position, Texture2D texture, Point size, Color tint, Vector2 speed)
            : base (position, texture, size, tint, speed)
        {

        }
    }
}
