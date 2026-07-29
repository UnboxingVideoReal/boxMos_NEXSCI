using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace boxMos_NEXSCI.Framework
{
    public struct Viewport2
    {
        public Viewport2(float X1, float Y1, float X2, float Y2)
        {
            minX = X1;
            minY = Y1;
            maxX = X2;
            maxY = Y2;
        }

        public float minX;
        public float minY;
        public float maxX;
        public float maxY;

        public float Width => Math.Abs(maxX - minX);
        public float Height => Math.Abs(maxY - minY);

        public bool Contains(Vector2 position)
        {
                return position.X >= minX &&
                        position.X <= maxX &&
                        position.Y >= minY &&
                        position.Y <= maxY;
        }
    }
}
