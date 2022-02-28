
using UnityEngine;

public class Arrive : AbstractSteering
{
    public float maxSpeed = 100f;
    
    public float targetRadius = 5f;
    // Slow Radius needs to be reasonably bigger than target radius to give character enough time to decelerate
    public float slowRadius = 50f;
    public float timeToTarget = .1f;

    public override SteeringOutput GetSteering()
    {
        SteeringOutput result = new SteeringOutput();
        result.angular = 0;
        float targetSpeed = maxSpeed;

        Vector3 targetVelocity = target.GetPosition() - character.GetPosition();
        float distance = targetVelocity.magnitude;

        if (distance < targetRadius) 
        {
            return null;
        }

        if (distance <= slowRadius)
        {
            targetSpeed = maxSpeed * distance / slowRadius;
        }

        targetVelocity.Normalize();
        targetVelocity *= targetSpeed;

        // Try to match the accelerationamount to the desired velocity
        result.linear = targetVelocity - character.GetVelocity();
        result.linear /= timeToTarget;

        if (result.linear.magnitude > maxAcceleration)
        {
            result.linear.Normalize();
            result.linear *= maxAcceleration;
        }       

        return result;

    }

    
}
