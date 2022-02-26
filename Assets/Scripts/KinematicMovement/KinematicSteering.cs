using UnityEngine;
public abstract class KinematicSteering
{
    protected Transform character;
    protected Transform target;

    protected float maxSpeed;

    public KinematicSteering(Transform _character) 
    {
        this.character = _character;
    }
    public abstract KinematicSteeringOutput getSteering();

    public float newOrientation(float current, Vector3 velocity) 
    {
        if (velocity.magnitude > 0) 
        {
            return Mathf.Atan2(-velocity.x, velocity.z);
        }
        else return current;
    }
    
    public void setMaxSpeed(float _maxSpeed)  
    {
        this.maxSpeed = _maxSpeed;
    }
    public void setTarget(Transform _target) {
        this.target = _target;
    }
}
