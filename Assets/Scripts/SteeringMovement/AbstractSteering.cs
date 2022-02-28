
using UnityEngine;

public abstract class AbstractSteering
{
   public Kinematic character;
   public Kinematic target;

   public float maxAcceleration;

   public abstract SteeringOutput GetSteering();
   
}
