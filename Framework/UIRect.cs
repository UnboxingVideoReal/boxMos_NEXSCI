using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace boxMos_NEXSCI.Framework
{
    public class UIRect : UI
    {
        public Color Color = Color.White;
        public UIRect(UIContainer container, SpriteBatch spriteBatch, ContentManager content, Rectangle rect, Vector2 angle, Color color, string name) : base(spriteBatch, content)
        {
            Rect = rect;
            Position = Rect.Location.ToVector2();
            Size = Rect.Size.ToVector2();
            Angle = angle;
            Color = color;
            Name = name;

            SpriteBatch = spriteBatch;
            Container = container;

            SetupShape(Rect, Angle);
        }

        public void SetupShape(Rectangle rect, Vector2 angle)
        {
            SpriteBatch.Draw(Main.pixelTexture, Rect, null, Color, (float)Math.Atan2(angle.Y, angle.X), Vector2.Zero/*Rect.Center.ToVector2()*/, SpriteEffects.None, 0f);

        }

    }
}
