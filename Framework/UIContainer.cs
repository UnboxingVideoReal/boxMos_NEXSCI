using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace boxMos_NEXSCI.Framework
{
    public class UIContainer : UI
    {
        public List<UI> items = new List<UI>();
        public UIContainer(SpriteBatch spriteBatch, ContentManager content, Rectangle rect, Vector2 angle, string name) : base(spriteBatch, content)
        {
            Container = this;
            Rect = rect;
            Position = Rect.Location.ToVector2();
            Size = Rect.Size.ToVector2();
            Angle = angle;
            Name = name;
            SpriteBatch = spriteBatch;

            spriteBatch.GraphicsDevice.ScissorRectangle = Rect;
        }

        public void AddItem(UI item)
        {
            items.Add(item);
        }
    }
}
