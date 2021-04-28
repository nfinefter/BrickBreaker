using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BrickBreaker
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        Ball ball;
        Brick[] bricks;
        public int lives = 3;
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

            Texture2D pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });


            ball = new Ball(new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height - 70), pixel, new Point(20, 20), Color.Black, new Vector2 (5, 5));

            bricks = new Brick[54];

            int gap = 5;
            int x = gap;
            int y = gap;
            int width = GraphicsDevice.Viewport.Width / 10;
            int height = 25;
            for (int i = 0; i < bricks.Length; i++)
            {

                bricks[i] = new Brick(new Vector2(x, y), pixel, new Point(width, height), Color.White, new Vector2 (0, 0));
                x = x + width + gap;

                if (x + width >= GraphicsDevice.Viewport.Width)
                {
                    y = y + height + gap;
                    x = gap;
                }
            }
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            // TODO: Add your update logic here

            ball.BounceBall(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();


            ball.Draw(spriteBatch);
            for (int i = 0; i < bricks.Length; i++)
            {
                bricks[i].Draw(spriteBatch);
            }
          
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
