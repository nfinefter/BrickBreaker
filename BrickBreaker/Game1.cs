using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace BrickBreaker
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        List<Ball> balls = new List<Ball>();

        Brick[] bricks;
        Button yesButton;
        Button noButton;
        Paddle paddle;
        Random rand = new Random();
        Vector2 originalPos;
        SpriteFont font;
        KeyboardState ks;
        Ball og;
        int gap;
        int x;
        int y;
        int width;
        int height;
        int level;
        Texture2D pixel;
        bool isPlaying = true;
        bool moveBall = true;
        bool win = false;
        bool lose = false;

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

            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            originalPos = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height - 70);

            og = new Ball(originalPos, pixel, new Vector2(20, 20), Color.Red, new Vector2(5, 5), originalPos, true);
            balls.Add(og);

            paddle = new Paddle(new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height - 15), pixel, new Vector2(200, 15), Color.Black, new Vector2(10, 5));

            bricks = new Brick[60];

            yesButton = new Button(new Vector2(GraphicsDevice.Viewport.Width / 2 + 50, GraphicsDevice.Viewport.Height / 2), pixel, new Vector2(50, 50), Color.White, Vector2.Zero);
            noButton = new Button(new Vector2(GraphicsDevice.Viewport.Width / 2 - 40, GraphicsDevice.Viewport.Height / 2), pixel, new Vector2(50, 50), Color.White, Vector2.Zero);

            gap = 5;
            x = gap + 10;
            y = gap + 30;
            width = GraphicsDevice.Viewport.Width / 10;
            height = 25;

            level = 0;

            for (int i = 0; i < bricks.Length; i++)
            {
                bricks[i] = new Brick(new Vector2(x, y), pixel, new Vector2(width, height), Color.White, new Vector2(0, 0), rand);
                bricks[i].IsVisible = true;
                x = x + width + gap;

                if (x + width >= GraphicsDevice.Viewport.Width)
                {
                    y = y + height + gap;
                    level++;
                    if (level % 2 == 0)
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

        public void Reset()
        {

            isPlaying = true;

            og.IsVisible = true;
            og.Lives = 3;
            x = gap + 10;
            y = gap + 30;

            yesButton.IsVisible = false;
            noButton.IsVisible = false;

            lose = false;
            win = false;

            moveBall = true;

            for (int i = 0; i < bricks.Length; i++)
            {
                bricks[i].IsVisible = true;
            }
            for (int i = 0; i < bricks.Length; i++)
            {
                bricks[i] = new Brick(new Vector2(x, y), pixel, new Vector2(width, height), Color.White, new Vector2(0, 0), rand);
                x = x + width + gap;

                if (x + width >= GraphicsDevice.Viewport.Width)
                {
                    y = y + height + gap;
                    level++;
                    if (level % 2 == 0)
                    {
                        x = gap + 10;
                    }
                    else
                    {
                        x = gap + 40;
                    }
                }
                
            }
            //og = new Ball(originalPos, pixel, new Vector2(20, 20), Color.Red, new Vector2(5, 5), originalPos, true);
            //balls.Add(og);

        }
        public void GameOver()
        {
            isPlaying = false;
            yesButton.IsVisible = true;
            noButton.IsVisible = true;

            og.Speed = Vector2.Zero;
            og.IsVisible = false;
            moveBall = false;
            for (int i = 1; i < balls.Count; i++)
            {
                balls.RemoveAt(i);
            }
        }

        public bool DidWin()
        {
            //Loop through the array, and check if there is a SINGLE brick that is VISIBLE
            //return false

            for (int i = 0; i < bricks.Length; i++)
            {
                if (bricks[i].IsVisible == true)
                {
                    return false;
                }
            }
            return true;
            //return true
        }

        protected override void Update(GameTime gameTime)
        {
            

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ks = Keyboard.GetState();
            MouseState ms = Mouse.GetState();

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

            for (int ballIndex = 0; ballIndex < balls.Count; ballIndex++)
            {
                Ball ball = balls[ballIndex];

                if (ball.isDead == true)
                {
                    if (ball.OriginalBall == false)
                    {
                        balls.RemoveAt(ballIndex);
                        ballIndex--;
                        continue;
                    }
                    if (moveBall == true)
                    {
                        if (ks.IsKeyDown(Keys.Space))
                        {
                            ball.Speed = new Vector2(5, 5);
                            ball.Position = new Vector2(paddle.Position.X, paddle.Position.Y - 40);
                            ball.isDead = false;
                        }
                    }
                }
               
                //At the very end set paddle.Position = new Vector2(x, y)

                // TODO: Add your update logic here

                //Loop through your bricks collection
                //Check if bricks[i][j].HitBox.Intersects(ball.Hitbox)
                for (int i = 0; i < bricks.Length; i++)
                {
                    if (bricks[i].HitBox.Intersects(ball.HitBox) && bricks[i].IsVisible == true)
                    {
                        float newx = ball.Position.X;
                        float newy = ball.Position.Y;

                        newx = Math.Max(newx, bricks[i].Position.X - ball.Width);
                        newx = Math.Min(newx, bricks[i].Position.X + bricks[i].Width);


                        newy = Math.Max(newy, bricks[i].Position.Y - ball.Height);
                        newy = Math.Min(newy, bricks[i].Position.Y + bricks[i].Height);

                        ball.Position = new Vector2(newx, newy);

                        ball.Speed = new Vector2(ball.Speed.X, ball.Speed.Y * -1);
                        if (bricks[i].PowerUp == true)
                        {
                            ball.Powers(rand, balls);
                        }
                        bricks[i].IsVisible = false;
                    }
                    if (bricks[i].PowerUp == true)
                    {
                        bricks[i].Tint = Color.Red;
                    }
                }

                if (paddle.HitBox.Intersects(ball.HitBox))
                {
                    //Then make sure ball gets readjusted to correct location


                    if (ball.Position.Y + ball.Height >= paddle.Position.Y && ball.Position.Y + ball.Height <= paddle.Position.Y + Math.Abs(ball.Speed.Y))
                    {
                        //we are colliding on the top

                        ball.Speed = new Vector2(ball.Speed.X, ball.Speed.Y * -1);
                    }
                    else
                    {
                        //colliding on the side
                        ball.Speed = new Vector2(ball.Speed.X * -1, ball.Speed.Y);

                        if(ball.Position.X < paddle.Position.X + paddle.Width / 2)
                        {
                            ball.Position = new Vector2(paddle.Position.X - ball.Width, ball.Position.Y);
                        }
                        else
                        {
                            ball.Position = new Vector2(paddle.Position.X + paddle.Width, ball.Position.Y);
                        }

                    //    float newx = ball.Position.X;
                    //
                    //    newx = Math.Max(newx, paddle.Position.X - ball.Width);
                    //    newx = Math.Min(newx, paddle.Position.X + paddle.Width);
                    //
                    //    ball.Position = new Vector2(newx, ball.Position.Y);
                    }
                }
                else
                {
                    Window.Title = "";
                }

                if (ball.Lives == 0)
                {
                    lose = true;
                    GameOver();
                }
                if (DidWin() == true)
                {
                    win = true;
                    GameOver();
                }
                
                if (yesButton != null && yesButton.IsClick(ms) )
                {
                    Reset();
                }
                if (noButton != null && noButton.IsClick(ms))
                {
                    Exit();
                }
                ball.BounceBall(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, ks);

                if (ball.GameEnd == true && ball.OriginalBall)
                {

                }

            }

            base.Update(gameTime);
        }

       

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].Draw(spriteBatch);
            }

            paddle.Draw(spriteBatch);

           
            if (isPlaying == true)
            {
                for (int i = 0; i < bricks.Length; i++)
                {
                    //If bricks[i] is not visible do not draw
                    if (bricks[i].IsVisible == true)
                    {
                        bricks[i].Draw(spriteBatch);
                    }
                }
            }
            else
            {
                if (noButton != null)
                {
                    noButton.Draw(spriteBatch);
                }
                if (yesButton != null)
                {
                    yesButton.Draw(spriteBatch);
                }
                spriteBatch.DrawString(font, "Do you want to play again?", new Vector2(GraphicsDevice.Viewport.Width / 2 - 60, GraphicsDevice.Viewport.Height / 2 - 40), Color.Black);
                spriteBatch.DrawString(font, "Yes", new Vector2(yesButton.Position.X, yesButton.Position.Y), Color.Black);
                spriteBatch.DrawString(font, "No", new Vector2(noButton.Position.X, noButton.Position.Y), Color.Black);

            }
            if (lose == true)
            {
                spriteBatch.DrawString(font, "You Lose!", new Vector2(GraphicsDevice.Viewport.Width / 2 - 60, GraphicsDevice.Viewport.Height / 2 - 70), Color.Black);
            }
            if (win == true)
            {
                spriteBatch.DrawString(font, "You Win!", new Vector2(GraphicsDevice.Viewport.Width / 2 - 60, GraphicsDevice.Viewport.Height / 2 - 70), Color.Black);
            }
            

            spriteBatch.DrawString(font, $"Lives: {balls[0].Lives}", new Vector2(0, 0), Color.Black);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
