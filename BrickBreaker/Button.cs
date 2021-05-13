using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrickBreaker
{
    class Button : Sprite
    {
        public Button(Vector2 position, Texture2D texture, Vector2 scale, Color tint, Vector2 speed)
            : base(position, texture, scale, tint, speed)
        {

        }

        public bool IsClick(MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed && HitBox.Contains(mouseState.Position))
            {
                return true;
            }
               
            return false;
            
        }
    }
}
