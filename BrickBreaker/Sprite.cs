using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrickBreaker
{
    class Sprite
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Color Tint { get; set; }
        public Vector2 Speed { get; set; }

        public Vector2 Scale { get; set; }

        public int Width
        {
            get
            {
                return Texture.Width * (int)Scale.X;
            }
        }

        public int Height
        {
            get
            {
                return Texture.Height * (int)Scale.Y;
            }
        }

        public Rectangle HitBox
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
            }
        }

        public Sprite(Vector2 position, Texture2D texture, Vector2 scale, Color tint, Vector2 speed)
        {
            Scale = scale;
            Position = position;
            Texture = texture;
            Tint = tint;
            Speed = speed;

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //IsDebug

            spriteBatch.Draw(Texture, HitBox, Tint);
        }
    }
}
