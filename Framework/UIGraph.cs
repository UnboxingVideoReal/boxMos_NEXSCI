using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.X3DAudio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace boxMos_NEXSCI.Framework
{
    public class UIGraph : UI
    {
        public Color Color = Color.White;
        public Texture2D GridTexture;
        public float PixelSize = 3;
        public Viewport2 ViewingWindow;
        public List<Vector2> Graph = new List<Vector2>();
        public Vector2 Bounds;
        public UIGraph(UIContainer container, SpriteBatch spriteBatch, ContentManager content, Func<double, double> f, Vector2 bounds, Texture2D pixelTexture, float pixelSize, Texture2D gridTexture, Viewport2 viewWin, Rectangle rect, Vector2 angle, Color color, string name) : base(spriteBatch, content)
        {
            Bounds = bounds;
            Texture = pixelTexture;
            PixelSize = pixelSize;
            GridTexture = gridTexture;
            ViewingWindow = viewWin;
            Rect = rect;
            Position = Rect.Location.ToVector2();
            Size = Rect.Size.ToVector2();
            Angle = angle;
            Color = color;
            Name = name;
            SpriteBatch = spriteBatch;
            Content = content;
            Container = container;

            SpriteBatch.GraphicsDevice.ScissorRectangle = Rect;
            CreateGraph(Graph, ViewingWindow, Texture, GridTexture, Rect, Angle, f, Bounds);
        }
        public void CreateGraph(List<Vector2> table, Viewport2 viewWin, Texture2D texture, Texture2D gridTexture, Rectangle rect, Vector2 angle, Func<double, double> f, Vector2 bounds)
        {

            SpriteBatch.Draw(Main.pixelTexture, rect, null, new Color(10,10,10), (float)Math.Atan2(angle.Y, angle.X), Vector2.Zero, SpriteEffects.None, 0f);
            //SpriteBatch.Draw(Main.pixelTexture, new Vector2(viewWin.minX, viewWin.minY), null, Color.Red, (float)Math.Atan2(angle.Y, angle.X), Vector2.Zero, PixelSize, SpriteEffects.None, 0f);
            //SpriteBatch.Draw(Main.pixelTexture, new Vector2(viewWin.maxX, viewWin.maxY), null, Color.Red, (float)Math.Atan2(angle.Y, angle.X), Vector2.Zero, PixelSize, SpriteEffects.None, 0f);

            SpriteBatch.Draw(Main.pixelTexture, new Vector2(rect.X, 0) + new Vector2(rect.X, rect.Y) - new Vector2(viewWin.minX, -viewWin.minY) + new Vector2(-100, -PixelSize/2), null, Color.Red, 0f, new Vector2(0, 0), new Vector2(rect.Width*100, PixelSize), SpriteEffects.None, 0f);
            SpriteBatch.Draw(Main.pixelTexture, new Vector2(rect.Height, -rect.Y) + new Vector2(rect.X, rect.Y) - new Vector2(viewWin.minX, -viewWin.minY) + new Vector2(-PixelSize/2, -100), null, Color.Blue, 0f, new Vector2(0, 0), new Vector2(PixelSize, rect.Height*100), SpriteEffects.None, 0f);
            SpriteBatch.Draw(Main.pixelTexture, new Vector2(rect.Right, rect.Top), null, Color.Red, (float)Math.Atan2(angle.Y, angle.X), Vector2.Zero, PixelSize, SpriteEffects.None, 0f);


            for (int i = (int)float.Round(bounds.X); i < (int)float.Round(bounds.Y) + 1; i++) // viewWin.maxX
            {
                Vector2 ourPos = new Vector2(i + viewWin.maxX, -(float)f(i)) + new Vector2(rect.X, rect.Y) - new Vector2(viewWin.minX, -viewWin.minY);
                if (rect.Contains(ourPos))
                {
                    SpriteBatch.Draw(texture, ourPos, null, Color, (float)Math.Atan2(angle.Y, angle.X), Vector2.Zero, PixelSize, SpriteEffects.None, 0f);
                }
            }
            
        }
    }
}
////work on ts shit later

//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
//using SharpDX.X3DAudio;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace boxMos_NEXSCI.Framework
//{
//    public class UIGraph : UI
//    {
//        public Color Color = Color.White;
//        public Texture2D GridTexture;
//        public float PixelSize = 3;
//        public Viewport2 ViewingWindow;
//        public List<Vector2> Graph = new List<Vector2>();
//        public Vector2 Bounds;
//        public UIGraph(UIContainer container, SpriteBatch spriteBatch, ContentManager content, Func<double, double> f, Vector2 bounds, Texture2D pixelTexture, float pixelSize, Texture2D gridTexture, Viewport2 viewWin, Rectangle rect, Vector2 angle, Color color, string name) : base(spriteBatch, content)
//        {
//            Bounds = bounds;
//            Texture = pixelTexture;
//            PixelSize = pixelSize;
//            GridTexture = gridTexture;
//            ViewingWindow = viewWin;
//            Rect = rect;
//            Position = Rect.Location.ToVector2();
//            Size = Rect.Size.ToVector2();
//            Angle = angle;
//            Color = color;
//            Name = name;
//            SpriteBatch = spriteBatch;
//            Content = content;
//            Container = container;
//            Graph = Calculate(f, Bounds);
//            CreateGraph(Graph, ViewingWindow, Texture, GridTexture, Rect, Angle, f); 
//        }
//        public List<Vector2> Calculate(Func<double, double> f, Vector2 bounds /*, Viewport2 viewport*/)
//        {
//            List<Vector2> tempGraph = new List<Vector2>();
//            double x = (int)float.Round(bounds.X);
//            double y = 0;
//            for (int i = (int)float.Round(bounds.X); i < (int)float.Round(bounds.Y) + 1; i++)
//            {
//                x = i;
//                y = f(i);
//                tempGraph.Add(new Vector2((float)x, (float)y));
//            }
//            return tempGraph;
//        }
//        //    public void CreateGraph(List<Vector2> table, Viewport2 viewWin, Texture2D texture, Texture2D gridTexture, Rectangle rect, Vector2 angle)
//        //    {
//        //        SpriteBatch.Draw(Main.pixelTexture, rect, null, Color.DarkGray, (float)Math.Atan2(angle.Y, angle.X), Vector2.Zero, SpriteEffects.None, 0f);

//        //        //float scaleX = (float)rect.Width / (viewWin.maxX - viewWin.minX);
//        //        //float scaleY = (float)rect.Height / (viewWin.maxY - viewWin.minY);
//        //        SpriteBatch.Draw(Main.pixelTexture, new Vector2(viewWin.minX /** scaleX*/ + rect.X, viewWin.minY /** scaleY*/ + rect.Y), null, Color.Red, (float)Math.Atan2(angle.Y, angle.X), Vector2.Zero, PixelSize, SpriteEffects.None, 0f);
//        //        SpriteBatch.Draw(Main.pixelTexture, new Vector2(viewWin.maxX /** scaleX*/ + rect.X, viewWin.maxY /** scaleY*/ + rect.Y), null, Color.Red, (float)Math.Atan2(angle.Y, angle.X), Vector2.Zero, PixelSize, SpriteEffects.None, 0f);

//        //        Vector2 ourBounds = new Vector2(table[0].X, table[table.Count-1].X);
//        //        for (int i = 0; i < table.Count; i++)
//        //        {
//        //            if (viewWin.Contains(new Vector2(table[i].X, table[i].Y)))
//        //            {
//        //                Debug.WriteLine(new Vector2(
//        //                    (table[i].X - viewWin.minX) /** scaleX*/,
//        //                    (viewWin.maxY - (table[i].Y - viewWin.minY)) /** scaleY*/
//        //                    ).ToString());
//        //                SpriteBatch.Draw(texture, new Vector2(
//        //                    (table[i].X - viewWin.minX) /** scaleX*/,
//        //                    (viewWin.maxY - (table[i].Y - viewWin.minY)) /** scaleY*/
//        //                    ) + new Vector2(rect.X, rect.Y), null, Color, (float)Math.Atan2(angle.Y, angle.X), Vector2.Zero, PixelSize, SpriteEffects.None, 0f);
//        //            }
//        //        }

//        //        Debug.WriteLine("end");
//        //    }
//        //}
//        public void CreateGraph(List<Vector2> table, Viewport2 viewWin, Texture2D texture, Texture2D gridTexture, Rectangle rect, Vector2 angle, Func<double, double> f)
//        {
//            SpriteBatch.Draw(Main.pixelTexture, rect, null, Color.DarkGray, (float)Math.Atan2(angle.Y, angle.X), Vector2.Zero, SpriteEffects.None, 0f);

//            for (int i = 0; i < table.Count - PixelSize; i++) // viewWin.maxX
//            {
//                Vector2 ourPos = new Vector2(i, (float)f(i - (viewWin.minX + viewWin.maxX)) + viewWin.Height * 0.75f) + new Vector2(rect.X, rect.Y));
//                if (viewWin.Contains())
//                {
//                    SpriteBatch.Draw(texture, ourPos, null, Color, (float)Math.Atan2(angle.Y, angle.X), Vector2.Zero, PixelSize, SpriteEffects.None, 0f);
//                }
//            }
//        }
//    }
//}
