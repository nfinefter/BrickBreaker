using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrickBreaker
{
    class Ball : Sprite
    {
        public Ball(Vector2 position, Texture2D texture, Point size, Color tint, Vector2 speed)
           : base(position, texture, size, tint, speed)
        {

        }

        public void BounceBall(int width, int height)
        {
            Position -= Speed;

            if (Position.Y + Size.Y >= height)
            {
                //reset ball
            }
            if (Position.X + Size.X >= width)
            {
                Speed *= -1;
            }
            if (Position.X <= 0)
            {
                Speed *= -1;
            }
            if (Position.Y <= 0)
            {
                Speed *= -1;
            }
        }
    }
}
