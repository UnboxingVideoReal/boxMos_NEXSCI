using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Diagnostics;

namespace boxMos_NEXSCI
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static Texture2D pixelTexture;
        RasterizerState rasterizerState;

        Menu menu;
        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            pixelTexture = Content.Load<Texture2D>("pixel");
            rasterizerState = new RasterizerState() { ScissorTestEnable = true };
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Setup();
            // TODO: use this.Content to load your game content here
        }

        public void Setup()
        {
            

            menu = new Menu(_spriteBatch, Content);
            menu.Setup();
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            // ui

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, rasterizerState);

            menu.Draw();

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
