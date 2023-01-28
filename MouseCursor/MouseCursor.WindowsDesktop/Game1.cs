using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MouseCursor.WindowsDesktop
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D _mouseCursorTexture2D;
        Rectangle _mouseCursorRectangle;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
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
            _mouseCursorTexture2D = Content.Load<Texture2D>("MouseCursor");
            _mouseCursorRectangle = new Rectangle(0, 0,69,110);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var mouseState = Mouse.GetState();
            _mouseCursorRectangle.X = mouseState.X;
            _mouseCursorRectangle.Y = mouseState.Y;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(_mouseCursorTexture2D, _mouseCursorRectangle, Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}