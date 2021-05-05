using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BrickBreaker
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        Ball ball;
        Brick[] bricks;
        Paddle paddle;
        public int lives = 3;
        Random rand = new Random();
        SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("Font");

            Texture2D pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });


            ball = new Ball(new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height - 70), pixel, new Vector2(20, 20), Color.Black, new Vector2(5, 5));
            paddle = new Paddle(new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height - 15), pixel, new Vector2(200, 15), Color.Black, new Vector2(10, 5));

            bricks = new Brick[60];

            int gap = 5;
            int x = gap + 10;
            int y = gap + 30;
            int width = GraphicsDevice.Viewport.Width / 10;
            int height = 25;

            int level = 0;

            for (int i = 0; i < bricks.Length; i++)
            {

                bricks[i] = new Brick(new Vector2(x, y), pixel, new Vector2(width, height), Color.White, new Vector2(0, 0), rand);
                x = x + width + gap;

                if (x + width >= GraphicsDevice.Viewport.Width)
                {
                    y = y + height + gap;
                    level++;
                    if(level % 2 == 0)
                    {
                        x = gap + 10;
                    }
                    else
                    {
                        x = gap + 40;
                    }
                }
            }

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState ks = Keyboard.GetState();

            float x = paddle.Position.X;
            float y = paddle.Position.Y;

            if (ks.IsKeyDown(Keys.Right))
            {
                x += 5;
            }
            if (ks.IsKeyDown(Keys.Left))
            {
                x -= 5;
            }

            x = Math.Max(x, 0);
            x = Math.Min(x, GraphicsDevice.Viewport.Width - paddle.Width);

            paddle.Position = new Vector2(x, y);
            //At the very end set paddle.Position = new Vector2(x, y)

            // TODO: Add your update logic here

            //Loop through your bricks collection
            //Check if bricks[i][j].HitBox.Intersects(ball.Hitbox)
            for (int i = 0; i < bricks.Length; i++)
            {
                if (bricks[i].HitBox.Intersects(ball.HitBox) && bricks[i].IsVisible == true)
                {
                    ball.Speed = new Vector2(ball.Speed.X, ball.Speed.Y * -1);
                    bricks[i].IsVisible = false;
                }
                if (bricks[i].PowerUp == true)
                {
                    bricks[i].Tint = Color.Red;
                }
            }
            if (paddle.HitBox.Intersects(ball.HitBox))
            {
                ball.Speed = new Vector2(ball.Speed.X, ball.Speed.Y * -1);
            }

            ball.BounceBall(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();


            ball.Draw(spriteBatch);
            paddle.Draw(spriteBatch);

            for (int i = 0; i < bricks.Length; i++)
            {
                //If bricks[i] is not visible do not draw
                if (bricks[i].IsVisible == true)
                {
                    bricks[i].Draw(spriteBatch);
                }
            }

            spriteBatch.DrawString(font, $"Lives: {lives}", new Vector2(0, 0), Color.Black);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
