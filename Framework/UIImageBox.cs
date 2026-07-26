using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace boxMos_NEXSCI.Framework
{
    public class UIImageBox : UI
    {
        public Color Color = Color.White;
        public UIImageBox(UIContainer container, SpriteBatch spriteBatch, ContentManager content, Texture2D texture, Rectangle rect, Vector2 angle, Color color, string name) : base(spriteBatch, content)
        {
            Texture = texture;
            Rect = rect;
            Position = Rect.Location.ToVector2();
            Size = Rect.Size.ToVector2();
            Angle = angle;
            Color = color;
            Name = name;

            SpriteBatch = spriteBatch;
            Content = content;
            Container = container;

            SetupImage(Texture, Rect, Angle);
        }

        public void SetupImage(Texture2D texture, Rectangle rect, Vector2 angle)
        {
            SpriteBatch.Draw(texture, Rect, null, Color, (float)Math.Atan2(angle.Y, angle.X), Vector2.Zero, SpriteEffects.None, 0f);
        }

    }
}
