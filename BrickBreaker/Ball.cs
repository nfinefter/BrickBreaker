using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrickBreaker
{
    class Ball : Sprite
    {
        public int Lives = 3;
        public Vector2 OriginalPos;
        public bool OriginalBall;
        public bool isDead;
        public bool GameEnd;


        public Ball(Vector2 position, Texture2D texture, Vector2 scale, Color tint, Vector2 speed, Vector2 originalPos, bool originalBall)
           : base(position, texture, scale, tint, speed)
        {
            OriginalBall = originalBall;
            OriginalPos = originalPos;
        }

        public void BounceBall(int width, int height, KeyboardState ks)
        {
            if(isDead)
            {
                return;
            }

            Position -= Speed;

            if (Position.Y + Scale.Y >= height)
            {
                if (OriginalBall == true)
                {
                    Speed = new Vector2(0, 0);
                    Lives--;
                    isDead = true;
                    Position = new Vector2(-100, -100);
                    if (Lives <= 0)
                    {
                        GameEnd = true;
                    }
                }
                else
                {
                    isDead = true;
                }
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
        public void Powers(Random rand, List<Ball> balls)
        {
            for (int i = 0; i < 3; i++)
            {
                Ball ball = new Ball(OriginalPos, Texture, Scale, Tint, new Vector2(rand.Next(1, 11), rand.Next(1, 11)), OriginalPos, false);
                balls.Add(ball);
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
