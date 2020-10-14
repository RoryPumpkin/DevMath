using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Line
    {
        public Vector2 Position
        {
            get; set;
        }

        public Vector2 Direction
        {
            get; set;
        }

        public float Length
        {
            get; set;
        }

        public bool IntersectsWith(Circle circle)
        {
            Vector2 L = circle.Position - Position;
            float Tca = Vector2.Dot(L, Direction);
            float d = (float)Math.Sqrt(L.Magnitude * L.Magnitude - Tca * Tca);

            float Thc = (float)Math.Sqrt(circle.Radius * circle.Radius - d * d);
            float T0 = Tca - Thc;

            if (Length < T0 || T0 < 0) { return false; }
            if (d < 0 || d > circle.Radius)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
