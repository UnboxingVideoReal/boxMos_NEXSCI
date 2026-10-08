using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace boxMos_NEXSCI
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static Texture2D pixelTexture;
        RasterizerState rasterizerState;
        public static string directory;

        Menu menu;
        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Content.RootDirectory);
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
            PreloadXmls();
            //ClearXmls();
            Setup();
            // TODO: use this.Content to load your game content here
        }
        public async Task PreloadXmls()
        {
            XDocument pscomppars = await RecolorUtils.sFetchandXDoc("pscomppars", "https://exoplanetarchive.ipac.caltech.edu/TAP/sync?query=select+*+from+pscomppars");
        }

        public void ClearXmls()
        {
            foreach (string file in Directory.EnumerateFiles(directory, "*.xml", SearchOption.TopDirectoryOnly))
            {
                File.Delete(file);
            }
        }
        public void Setup()
        {
            menu = new Menu(_spriteBatch, Content, rasterizerState);
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

            menu.Draw();

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
