using UnityEngine;

/**
<summary> A Kinematic Wanderer alsways moves in the direction it is looking
and randomly changes its rotation to mimic a meandering movement
</summary>
*/
public class KinematicWander : KinematicSteering
{
    public float maxRotation = 1f;

    public KinematicWander(Transform _character) : base(_character)
    {
    }

    public override SteeringOutput GetSteering()
    {
        SteeringOutput result = new SteeringOutput();

        // transform.forward is normalized so we can use it as is
        result.linear = character.forward * maxSpeed;
        
        // Millingtons implementation of Wandering uses randomness instead of noise
        // which results in choppy/jittery rotation changes
        result.angular = character.rotation.eulerAngles.y + randomBinomial() * maxRotation;
        
        //result.rotation = character.rotation.eulerAngles.y + randomNoise() * maxRotation;

        Debug.Log(result.angular);

        return result;
    }

    // triangular random distribution with most likely value being 0
    private float randomBinomial() 
    {
        return Random.value - Random.value;
    }

    private float randomNoise()
    {
        return Mathf.PerlinNoise( Time.time , 0f) - .5f;
    }
}
