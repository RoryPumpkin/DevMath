using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class DevMath
    {
        public static float Lerp(float a, float b, float t)
        {
            b -= a;
            b *= t;
            return a + b;
        }

        public static float DistanceTraveled(float startVelocity, float acceleration, float time)
        {
            return startVelocity * time + 0.5f * acceleration * (time * time);
        }

        public static float Clamp(float value, float min, float max)
        {
            if (value.CompareTo(min) < 0) return min;
            else if (value.CompareTo(max) > 0) return max;
            else return value;
        }

        public static float RadToDeg(float angle)
        {
            return (float)(angle * 180 / Math.PI);
        }

        public static float DegToRad(float angle)
        {
            return (float)(angle * Math.PI / 180);
        }
    }
}
