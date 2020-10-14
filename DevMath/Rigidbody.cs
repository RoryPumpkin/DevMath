using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Rigidbody
    {
        public Vector2 Velocity
        {
            get; private set;
        }

        public float Acceleration 
        { 
            get; private set; 
        }

        public float mass = 1.0f;

        public float frictionCoefficient;
        public float normalForce;

        public void UpdateVelocityWithForce(Vector2 forceDirection, float forceNewton, float deltaTime)
        {
            float friction = frictionCoefficient * normalForce;

            if (forceDirection.Magnitude == 0)
            {
                if (Velocity.Magnitude < 0.01f)
                {
                    Acceleration = 0;
                    Velocity = new Vector2(0, 0);
                }
                else
                {
                    Acceleration = -friction / mass * deltaTime;
                    Velocity += Velocity.Normalized * Acceleration;
                }
            }
            else
            {
                Acceleration = (forceNewton - friction) / mass * deltaTime;
                Velocity += forceDirection * Acceleration;
            }
        }
    }
}
