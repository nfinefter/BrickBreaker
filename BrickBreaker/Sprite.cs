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

        public Point Size { get; set; }

        public Rectangle HitBox
        {
            get
            {
                return new Rectangle(Position.ToPoint(), Size);
            }
        }

        public Sprite(Vector2 position, Texture2D texture, Point size, Color tint, Vector2 speed)
        {
            Size = size;
            Position = position;
            Texture = texture;
            Tint = tint;
            Speed = speed;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, HitBox, Tint);
        }
    }
}
