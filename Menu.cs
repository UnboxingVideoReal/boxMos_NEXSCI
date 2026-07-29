using boxMos_NEXSCI.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace boxMos_NEXSCI
{
    public class Menu
    {
        SpriteBatch batch;
        ContentManager content;
        RasterizerState rasterizer;
        int interval = 0;
        public Menu(SpriteBatch spriteBatch, ContentManager contentt, RasterizerState rasterizerState) 
        {
            batch = spriteBatch;
            content = contentt;
            rasterizer = rasterizerState;
        }
        public void Setup()
        {

        }
        public void Draw()
        {
            batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, rasterizer);

            interval++;
            UIContainer container = new(batch, content, new Rectangle(0, 0, batch.GraphicsDevice.Viewport.Width, batch.GraphicsDevice.Viewport.Height), new Vector2(0, 0), "menu");
            UIRect shape = new(container, batch, content, new Rectangle(0, 0, 70, 50), new Vector2(0, 0), Color.White, "shape");
            UIImageBox image = new(container, batch, content, content.Load<Texture2D>("test"), new Rectangle(400, 0, 200, 100), new Vector2(1, 1), Color.White, "image");
            batch.End();
            batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, rasterizer);
            UIGraph graph = new(null, batch, content,
                x => /*Math.Sin(x/10)*20*/Math.Pow(x,3),
                new Vector2(-200, 200),
                Main.pixelTexture,
                3f,
                Main.pixelTexture,
                new Viewport2(200, 200, 200, 200),
                new Rectangle(100, 100, 200, 200), new Vector2(0, 0), Color.White, "x^2");
        }
    }
}
