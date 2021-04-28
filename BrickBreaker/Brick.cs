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

        public Brick(Vector2 position, Texture2D texture, Point size, Color tint, Vector2 speed, bool powerUp)
            : base (position, texture, size, tint, speed)
        {
            PowerUp = powerUp;
        }
        public void IsPower()
        {
            Random rand = new Random();

            if (rand.Next(1, 30) == 15)
            {
                PowerUp = true;
            }
            else
            {
                PowerUp = false
            }

        }
    }
}
