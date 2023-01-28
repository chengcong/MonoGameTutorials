using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace RectangleRotation.WindowsDesktop
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D _yellowRectangleTexture2D;
        Rectangle _yellowRectanglePosition;

        float _rotation;
        Vector2 _origin;

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
            _yellowRectangleTexture2D = Content.Load<Texture2D>("YellowRectangle");
            _yellowRectanglePosition=new Rectangle(200,200,100,100);

            _rotation = 0;
            _origin=new Vector2(50,50);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _rotation -= 1f;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(_yellowRectangleTexture2D, _yellowRectanglePosition,null,Color.White,_rotation,_origin,SpriteEffects.None,0);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}