using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Circle
    {
        public Vector2 Position
        {
            get; set;
        }

        public float Radius
        {
            get; set;
        }

        public bool CollidesWith(Circle circle)
        {
            var dx = this.Position.x - circle.Position.x;
            var dy = this.Position.y - circle.Position.y;
            var distance = Math.Sqrt(dx * dx + dy * dy);

            if (distance <= this.Radius + circle.Radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
