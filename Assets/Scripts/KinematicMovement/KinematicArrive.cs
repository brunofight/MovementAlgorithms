
using UnityEngine;

public class KinematicArrive : KinematicSteering
{
    // Satisfaction Radius
    private float radius = 5f;

    private float timeToTarget = 0.25f;

    public KinematicArrive(Transform _character) : base(_character)
    {
    }

    public override SteeringOutput GetSteering()
    {
        SteeringOutput result = new SteeringOutput();

        result.linear = target.position - character.position;

        if (result.linear.magnitude < radius) 
        {
            result.linear = Vector3.zero;
            return result;
        }
            
        // simulating a deceleration the closer the AI gets to the target
        // e.g. AI is 4 units away from target it would optimally move 16 units/s to reach the target.
        result.linear /= timeToTarget;

        if (result.linear.magnitude > maxSpeed) 
        {
            result.linear.Normalize();
            result.linear *= maxSpeed;
        }

        result.angular = Quaternion.LookRotation(result.linear).eulerAngles.y;
       
        return result;
    }
}
