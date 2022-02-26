using UnityEngine;

public class KinematicFlee : KinematicSteering
{
    public KinematicFlee(Transform _character) : base(_character)
    {
    }

    public override KinematicSteeringOutput getSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        result.velocity = base.character.position - base.target.position;
        result.velocity.Normalize();
        result.velocity *= base.maxSpeed; 

        return result;
    }
}
