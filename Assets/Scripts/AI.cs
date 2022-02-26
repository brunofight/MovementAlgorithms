using System;
using UnityEngine;

public class AI : MonoBehaviour
{
    private KinematicSteering kinematicSteering;
    public Transform playerTransform;
    public float speed = 10f;

    // rotational and movement velocity
   private Vector3 velocity;
   private float rotation;
 
    void Start()
    {
        //kinematicSteering = new KinematicFlee(this.transform);
        //kinematicSteering = new KinematicSeek(this.transform);

        kinematicSteering = new KinematicArrive(this.transform);
        kinematicSteering.setTarget(playerTransform);
        kinematicSteering.setMaxSpeed(this.speed);
        
    }
    void Update()
    {
        KinematicSteeringOutput steering = kinematicSteering.getSteering();
        
        
        UpdateKinematic(steering);
        
    }

    /**
    According to Millington Kinematic Movement neglects the usage of acceleration, thus always setting the current velocity
    the resulting velocity from the steering
    */
    private void UpdateKinematic(KinematicSteeringOutput steering)
    {        
        transform.position += velocity * Time.deltaTime;
        // no lerping here. The steering rotation is neglected in kinematic movement algorithms.
        transform.rotation = Quaternion.LookRotation(playerTransform.position - transform.position);

        velocity = steering.velocity;
        rotation = steering.rotation;         
    }    

}
