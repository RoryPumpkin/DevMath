using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public struct Vector2
    {
        public float x;
        public float y;

        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(x * x + y * y);
            }
        }

        public Vector2 Normalized
        {
            get
            {
                var mag = this.Magnitude;
                return this / mag;
            }
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static float Dot(Vector2 lhs, Vector2 rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y;
        }

        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            b -= a;
            b *= t;
            return a + b;
        }

        public static float Angle(Vector2 lhs, Vector2 rhs)
        {
            Vector2 v = lhs - rhs;
            return -(float)Math.Atan2(v.x, v.y) - (0.5f * (float)Math.PI);
        }

        public static Vector2 DirectionFromAngle(float angle)
        {
            var x = (float)Math.Cos(DevMath.DegToRad(angle));
            var y = (float)Math.Sin(DevMath.DegToRad(angle));
            return new Vector2(x, y);
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static Vector2 operator -(Vector2 v)
        {
            return new Vector2(-v.x, -v.y);
        }

        public static Vector2 operator *(Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.x *= scalar, lhs.y *= scalar);
        }

        public static Vector2 operator *(Vector2 lhs, Vector2 rhs)
        {
            float x = lhs.x * rhs.x;
            float y = lhs.y * rhs.y;
            return new Vector2(x, y);
        }

        public static Vector2 operator /(Vector2 lhs, float scalar)
        {
            return new Vector2(lhs.x /= scalar, lhs.y /= scalar);
        }
    }
}
