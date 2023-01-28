using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ArrowAnimation.WindowsDesktop
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        List<Texture2D> _arrowTexture2DList;
        Rectangle _arrowRectangle;
        int currentFame = 0;

        int timeLastFrame = 0;
        int timePerFrame = 500;

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
            _arrowTexture2DList=new List<Texture2D>();

            for(int i=0;i<8;i++)
            {
                _arrowTexture2DList.Add(Content.Load<Texture2D>("Arrow" + i));
            }

            _arrowRectangle = new Rectangle(100, 100, 263, 184);


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            timeLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeLastFrame > timePerFrame)
            {
                timeLastFrame = gameTime.ElapsedGameTime.Milliseconds;
                if (currentFame >= _arrowTexture2DList.Count - 1)
                {
                    currentFame = 0;
                }
                else
                {
                    currentFame += 1;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(_arrowTexture2DList[currentFame], _arrowRectangle, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}