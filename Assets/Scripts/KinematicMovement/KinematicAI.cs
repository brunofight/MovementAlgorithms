
using UnityEngine;

public class KinematicAI : Kinematic
{
    private KinematicSteering steering;
    public Transform playerTransform;
    public float maxSpeed = 10f;

    // rotational and movement velocity
 
    void Start()
    {
        //kinematicSteering = new KinematicFlee(this.transform);
        //kinematicSteering = new KinematicSeek(this.transform);

        steering = new KinematicArrive(this.transform);
        steering.setTarget(playerTransform);
        steering.setMaxSpeed(this.maxSpeed);
        
    }
    void Update()
    {
        //KinematicSteeringOutput steering = kinematicSteering.getSteering();
        //UpdateKinematic(steering);

        UpdateSteering(steering.GetSteering());
        
    }

    /**
    According to Millington Kinematic Movement neglects the usage of acceleration, thus always setting the current velocity
    the resulting velocity from the steering
    */
    public override void UpdateSteering(SteeringOutput steering)
    {        
        transform.position += velocity * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(new Vector3(0f, rotation, 0f));
        
        velocity = steering.linear;
        rotation = steering.angular;         
    }  

}
