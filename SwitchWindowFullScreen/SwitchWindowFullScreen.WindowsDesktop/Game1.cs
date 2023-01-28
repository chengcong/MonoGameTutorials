using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SwitchWindowFullScreen.WindowsDesktop
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = 3840;
            _graphics.PreferredBackBufferHeight = 2160;
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
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.F10))
            {
                _graphics.IsFullScreen = false;
                _graphics.PreferredBackBufferWidth = 800;
                _graphics.PreferredBackBufferHeight = 480;

                _graphics.ApplyChanges();
            }
            if(Keyboard.GetState().IsKeyDown(Keys.F11)) 
            {
                _graphics.IsFullScreen = true;
                _graphics.PreferredBackBufferWidth = 3840;
                _graphics.PreferredBackBufferHeight = 2160;
                _graphics.ApplyChanges();
            }

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}