using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using boxMos_NEXSCI.Framework;

namespace boxMos_NEXSCI
{
    public class Menu
    {
        SpriteBatch batch;
        ContentManager content;
        int interval = 0;
        public Menu(SpriteBatch spriteBatch, ContentManager contentt) 
        {
            batch = spriteBatch;
            content = contentt;
        }
        public void Setup()
        {

        }
        public void Draw()
        {
            interval++;
            UIContainer container = new(batch, content, new Rectangle(0, 0, batch.GraphicsDevice.Viewport.Width, batch.GraphicsDevice.Viewport.Height), new Vector2(0, 0), "menu");
            UIRect shape = new(container, batch, content, new Rectangle(0, 0, 70, 50), new Vector2(0, 0), Color.White, "shape");
            UIImageBox image = new(container, batch, content, content.Load<Texture2D>("test"), new Rectangle(400, 0, 200, 100), new Vector2(1, 1), Color.White, "image");
            UIGraph graph = new(container, batch, content,
                x => Math.Sin(x)/*Math.Pow(x,3)*/,
                new Vector2(-100, 100),
                Main.pixelTexture,
                3f,
                Main.pixelTexture,
                new Viewport2(0 + interval, -33, 100, 100),
                new Rectangle(100, 100, 200, 200), new Vector2(0, 0), Color.White, "x^2");
        }
    }
}
