
using UnityEngine;

public class KinematicArrive : KinematicSteering
{
    // Satisfaction Radius
    private float radius = 5f;

    private float timeToTarget = 0.25f;

    public KinematicArrive(Transform _character) : base(_character)
    {
    }

    public override KinematicSteeringOutput getSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        result.velocity = target.position - character.position;

        if (result.velocity.magnitude < radius) 
        {
            result.velocity = Vector3.zero;
            return result;
        }
            
        // simulating a deceleration the closer the AI gets to the target
        // e.g. AI is 4 units away from target it would optimally move 16 units/s to reach the target.
        result.velocity /= timeToTarget;

        if (result.velocity.magnitude > maxSpeed) 
        {
            result.velocity.Normalize();
            result.velocity *= maxSpeed;
        }

        result.rotation = newOrientation(character.rotation.y,result.velocity);

        return result;
    }
}
