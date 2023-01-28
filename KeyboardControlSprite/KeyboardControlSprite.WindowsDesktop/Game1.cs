using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KeyboardControlSprite.WindowsDesktop
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D _fishTexture2D;
        Rectangle _fishRectangle;

        Texture2D _fishTexture2DLeft;
        Texture2D _fishTexture2DRight;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
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
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _fishTexture2D = Content.Load<Texture2D>("FishLeft");
            _fishRectangle = new Rectangle(0, 0, 209, 248);

            _fishTexture2DLeft= Content.Load<Texture2D>("FishLeft");
            _fishTexture2DRight = Content.Load<Texture2D>("FishRight");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var keyboardState = Keyboard.GetState();
            if(keyboardState.IsKeyDown(Keys.Left))
            {
                _fishTexture2D = _fishTexture2DLeft;
                _fishRectangle.X -= 1;
            }
            else if(keyboardState.IsKeyDown(Keys.Right))
            {
                _fishTexture2D = _fishTexture2DRight;
                _fishRectangle.X += 1;
            }
            else if(keyboardState.IsKeyDown(Keys.Up))
            {
                _fishRectangle.Y -= 1;
            }
            else if(keyboardState.IsKeyDown(Keys.Down))
            {
                _fishRectangle.Y+= 1;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(_fishTexture2D, _fishRectangle,Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}