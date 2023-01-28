using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace SoundEffect.WindowsDesktop
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D _buttonTexture2D;
        Rectangle _buttonRectangle;
      
        SoundEffectInstance _wangSoundEffectInstance;
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
            _buttonTexture2D = Content.Load<Texture2D>("Button");
            _buttonRectangle = new Rectangle(100, 100, _buttonTexture2D.Width, _buttonTexture2D.Height);

            _wangSoundEffectInstance = Content.Load<Microsoft.Xna.Framework.Audio.SoundEffect>("Wang").CreateInstance();

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var mouseState = Mouse.GetState();
            var mouseVector2D = new Vector2(mouseState.X, mouseState.Y);

            if(mouseState.LeftButton==ButtonState.Pressed&&_buttonRectangle.Contains(mouseVector2D))
            {
                _wangSoundEffectInstance.Play();
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