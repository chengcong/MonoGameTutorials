using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Button.WindowsDesktop
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D _buttonNormalTexture2D;
        Texture2D _buttonOverTexture2D;
        Texture2D _buttonPressedTexture2D;

        Rectangle _buttonRectangle;

        Texture2D _buttonTexture2D;
       

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

            _buttonNormalTexture2D = Content.Load<Texture2D>("ButtonNormal");
            _buttonOverTexture2D = Content.Load<Texture2D>("ButtonOver");
            _buttonPressedTexture2D = Content.Load<Texture2D>("ButtonPressed");

            _buttonRectangle = new Rectangle(100, 100, 320, 135);
            _buttonTexture2D = _buttonNormalTexture2D;

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var mouseState = Mouse.GetState();
            var mouseVector2D = new Vector2(mouseState.X, mouseState.Y);

            if(_buttonRectangle.Contains(mouseVector2D))
            {
                _buttonTexture2D = _buttonOverTexture2D;

                if(mouseState.LeftButton==ButtonState.Pressed)
                {
                    _buttonTexture2D = _buttonPressedTexture2D;
                    //以下是按下按钮的操作

                }

            }
            else
            {
                _buttonTexture2D = _buttonNormalTexture2D;
            }
          


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(_buttonTexture2D, _buttonRectangle, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}