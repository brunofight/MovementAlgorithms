using UnityEngine;

public class KinematicSeek : KinematicSteering
{
    public KinematicSeek(Transform _character) : base(_character) {}    

    public override KinematicSteeringOutput getSteering() {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        result.velocity = base.target.position - character.position;

        // Since this is a seek, the AI will want to run at the character at full speed
        // this will cause problems since the AI will overshoot its target
        // furthermore there should be a mechanism to have the AI decelerate faster than accelerate - 
        // otherwise movement would mimic a pendulum
        result.velocity.Normalize();
        result.velocity *= base.maxSpeed;

        //rotate characters orientation towards target
        //character.Rotate(result.linear);

        return result;
    }

}
