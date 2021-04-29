using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrickBreaker
{
    class Ball : Sprite
    {
        public Ball(Vector2 position, Texture2D texture, Vector2 scale, Color tint, Vector2 speed)
           : base(position, texture, scale, tint, speed)
        {

        }

        public void BounceBall(int width, int height)
        {
            Position -= Speed;

            if (Position.Y + Scale.Y >= height)
            {
                //reset ball
            }
            if (Position.X + Scale.X >= width)
            {
                Speed = new Vector2(Speed.X * -1, Speed.Y);
            }
            if (Position.X <= 0)
            {
                Speed = new Vector2(Speed.X * -1, Speed.Y);
            }
            if (Position.Y <= 0)
            {
                Speed = new Vector2(Speed.X, Speed.Y * -1);
            }
        }
    }
}
