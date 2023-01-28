using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SwitchScene.WindowsDesktop
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Scene CurrentScene;

        Texture2D _mainMenuTexture2D;
        Texture2D _backgroundTexture2D;
        Texture2D _buttonNormalTexture2D;
        Rectangle _buttonNormalRectangle;
        Texture2D _buttonBackTexutre2D;
        Rectangle _buttonBackRectangle;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 480;
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
            //游戏的主菜单场景
            _mainMenuTexture2D = Content.Load<Texture2D>("MainMenu");
            _buttonNormalTexture2D = Content.Load<Texture2D>("ButtonNormal");
            _buttonNormalRectangle = new Rectangle((800 - _buttonNormalTexture2D.Width) / 2, (480 - _buttonNormalTexture2D.Height)/2, _buttonNormalTexture2D.Width, _buttonNormalTexture2D.Height);

            //游戏的游戏场景
            _backgroundTexture2D = Content.Load<Texture2D>("Background");
            _buttonBackTexutre2D = Content.Load<Texture2D>("ButtonBack");
            _buttonBackRectangle = new Rectangle(50, 50, _buttonBackTexutre2D.Width, _buttonBackTexutre2D.Height);
            CurrentScene = Scene.MainMenu;

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var mouseState = Mouse.GetState();
            var mouseVector2D = new Vector2(mouseState.X, mouseState.Y);
            if (CurrentScene == Scene.MainMenu)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && _buttonNormalRectangle.Contains(mouseVector2D))
                {
                    CurrentScene = Scene.GamePlaying;
                }
            }
            else if(CurrentScene==Scene.GamePlaying)
            {
                if(mouseState.LeftButton==ButtonState.Pressed&&_buttonBackRectangle.Contains(mouseVector2D))
                {
                    CurrentScene = Scene.MainMenu;
                }
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if(CurrentScene==Scene.MainMenu)
            {
                _spriteBatch.Draw(_mainMenuTexture2D,Vector2.Zero,Color.White);
                _spriteBatch.Draw(_buttonNormalTexture2D,_buttonNormalRectangle,Color.White);
            }
            else if(CurrentScene==Scene.GamePlaying)
            {
                _spriteBatch.Draw(_backgroundTexture2D,Vector2.Zero,Color.White);
                _spriteBatch.Draw(_buttonBackTexutre2D, _buttonBackRectangle, Color.White);

            }

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}