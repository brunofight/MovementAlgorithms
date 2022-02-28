using UnityEngine;

public class KinematicFlee : KinematicSteering
{
    public KinematicFlee(Transform _character) : base(_character)
    {
    }

    public override SteeringOutput GetSteering()
    {
        SteeringOutput result = new SteeringOutput();

        result.linear = base.character.position - base.target.position;
        result.linear.Normalize();
        result.linear *= base.maxSpeed; 

        return result;
    }
}
