using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Text;

namespace BrickBreaker
{
    class Brick : Sprite
    {
        public bool PowerUp;
        public bool IsVisible = true;

        public Brick(Vector2 position, Texture2D texture, Vector2 scale, Color tint, Vector2 speed, Random random)
            : base (position, texture, scale, tint, speed)
        {

            if (random.Next(1, 10) == 5)
            {
                PowerUp = true;
            }
            else
            {
                PowerUp = false;
            }

        }
        

    }
}
