using UnityEngine;

/**
<summary>
Information associated with character
</summary>
*/
public class Kinematic : MonoBehaviour
{
   // rotational and movement velocity
   protected Vector3 velocity;
   protected float rotation;

   public virtual void UpdateSteering(SteeringOutput steering) 
   {
   }

   public Vector3 GetPosition()
   {
      return transform.position;
   }

   public float GetRotation()
   {
      return transform.rotation.eulerAngles.y;
   }

   public Vector3 GetVelocity()
   {
      return velocity;
   }

   public float GetRotationVelocity()
   {
      return rotation;
   }

}
