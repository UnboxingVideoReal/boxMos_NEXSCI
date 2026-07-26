using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace boxMos_NEXSCI.Framework
{
    public abstract class UI
    {
        public virtual string Name { get;  set; }
        public virtual Texture2D Texture { get; set; }
        public virtual Vector2 Position { get; set; }
        public virtual Vector2 Size { get;  set; }
        public virtual Vector2 Angle { get; set; }

        public virtual Rectangle Rect { get; set; }

        public virtual SpriteBatch SpriteBatch { get; set; }
        public virtual ContentManager Content { get; set; }
        public virtual UIContainer Container { get; set; }

        public UI(SpriteBatch spriteBatch, ContentManager content)
        {
            SpriteBatch = spriteBatch;
            Content = content;
        }

    }
}
