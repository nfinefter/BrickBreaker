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
        public void Update(int scoreNum)
        {
            if (Position.X < 0)
            {
                scoreNum--;
            }
        }
    }
}
