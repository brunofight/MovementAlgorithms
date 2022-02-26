using UnityEngine;

/**
<summary>
Information associated with character
</summary>
*/
public class Kinematic
{
   public Vector3 position;
   public float orientation;

   // rotational and movement velocity
   public Vector3 velocity;
   public float rotation;

   public void update(SteeringOutput steering, float deltatime) 
   {
        position += velocity * deltatime;
        orientation += rotation * deltatime;

        velocity += steering.linear * deltatime;
        rotation += steering.angular * deltatime;
   }
}
