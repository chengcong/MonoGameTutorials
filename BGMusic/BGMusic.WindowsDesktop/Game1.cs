using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BGMusic.WindowsDesktop
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Song _bgMusic;
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
            _bgMusic = Content.Load<Song>("BGMusic");

            MediaPlayer.Play(_bgMusic);
            MediaPlayer.IsRepeating=true;
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            var keyboardState=Keyboard.GetState();
            if(keyboardState.IsKeyDown(Keys.F2))
            {
                MediaPlayer.Pause();
            }
            else if(keyboardState.IsKeyDown(Keys.F3))
            { 
                MediaPlayer.Resume();
            }
            else if(keyboardState.IsKeyDown(Keys.F4))
            {
                MediaPlayer.Stop();
            }
            else if(keyboardState.IsKeyDown(Keys.F5))
            {
                MediaPlayer.Play(_bgMusic);
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