using boxMos_NEXSCI.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace boxMos_NEXSCI
{
    public class Menu
    {
        SpriteBatch batch;
        ContentManager content;
        RasterizerState rasterizer;
        double interval = 0;
        //RecolorUtils RecolorUtils = new RecolorUtils();
        public Menu(SpriteBatch spriteBatch, ContentManager contentt, RasterizerState rasterizerState) 
        {
            batch = spriteBatch;
            content = contentt;
            rasterizer = rasterizerState;
        }
        public async Task PreloadXmls()
        {
            XDocument pscomppars = await RecolorUtils.sFetchandXDoc("pscomppars", "https://exoplanetarchive.ipac.caltech.edu/TAP/sync?query=select+*+from+pscomppars");
        }
        public async Task Setup()
        {
            await PreloadXmls();
            //Debug.WriteLine(testRead[0]);
        }
        public void Draw()
        {
            batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, rasterizer);

            interval += 1;
            UIContainer container = new(batch, content, new Rectangle(0, 0, batch.GraphicsDevice.Viewport.Width, batch.GraphicsDevice.Viewport.Height), new Vector2(0, 0), "menu");
            UIRect shape = new(container, batch, content, new Rectangle(0, 0, 70, 50), new Vector2(0, 0), Color.White, "shape");
            UIImageBox image = new(container, batch, content, content.Load<Texture2D>("test"), new Rectangle(400, 0, 200, 100), new Vector2(1, 1), Color.White, "image");
            batch.End();
            batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, rasterizer);
            UIGraph graph = new(null, batch, content,
                x => (Math.Atan((Math.Tanh(x) * Math.Sin(interval/5)*5) /5)+Math.Cos(x/5))*50,
                new Vector2(-200,200),
                Main.pixelTexture,
                3f,
                Main.pixelTexture,
                new Viewport2(100, 100, 100, 100),
                new Rectangle(100, 100, 200, 200), new Vector2(0, 0), Color.White, "(tanh(x)*5sin(y/5)/5)+50cos(x/5)",
                new List<Vector2>());
        }
    }
}


// COOL FUNCTIONS

// Math.Tan(Math.Cos(x*Math.Sin(x))+interval)
// (1/Math.Sinh((x / 1/Math.Cos(interval))/20))*100
// 