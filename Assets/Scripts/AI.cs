using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum Behavior 
{
    SEEK, FLEE, ARRIVE, ALIGN, VELOCITY_MATCH, PURSUE, FACE, FOLLOW_PATH
}


[CustomEditor(typeof(AI))]
public class AIEditor : Editor {
    string[] alwaysDrawList = 
        {"activeBehavior",  "maxSpeed", "maxAcceleration", "playerTransform"};

    SerializedProperty activeBehavior;
    SerializedProperty targetRadius;
    SerializedProperty slowRadius;
    SerializedProperty timeToTarget;

    private void OnEnable() {
        activeBehavior = serializedObject.FindProperty("activeBehavior");
        targetRadius = serializedObject.FindProperty("targetRadius");
        slowRadius = serializedObject.FindProperty("slowRadius");
        timeToTarget = serializedObject.FindProperty("timeToTarget");
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        foreach (string propertyName in alwaysDrawList)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty(propertyName));
        }

        if (activeBehavior.enumValueIndex == (int) Behavior.ARRIVE) 
        {
            EditorGUILayout.PropertyField(targetRadius);
            EditorGUILayout.PropertyField(slowRadius);
            EditorGUILayout.PropertyField(timeToTarget);
        }

        serializedObject.ApplyModifiedProperties();
        
    }

}

public class AI : Kinematic
{
    private AbstractSteering steering;
    [SerializeField]
    private Transform playerTransform;
    public float maxSpeed = 10f;
    public float maxAcceleration = 20f;

    public Behavior activeBehavior = Behavior.SEEK;
    
    [SerializeField]
    private float slowRadius = 50f;
    [SerializeField]
    private float targetRadius = 5f;
    [SerializeField]
    private float timeToTarget = .1f;

    // rotational and movement velocity inherited by Kinematic-Class
    
    void Start()
    {
        
        steering = GetActiveSteering();
        steering.character = this;
        steering.target = playerTransform.GetComponent<Kinematic>();
        steering.maxAcceleration = maxAcceleration;
        
    }

    private AbstractSteering GetActiveSteering()
    {
        AbstractSteering result;

        switch (activeBehavior)
        {
            case Behavior.SEEK: 
                result = new Seek();
                break;
            case Behavior.FLEE: 
                result = new Flee();
                break;
            case Behavior.ARRIVE: 
                Arrive a = new Arrive();
                a.maxSpeed = maxSpeed;
                a.slowRadius = slowRadius;
                a.targetRadius = targetRadius;
                a.timeToTarget = timeToTarget;
                result = a;
                break;
            
            default:
                result = new Seek();
                break;
        }

        result.target = playerTransform.GetComponent<Kinematic>();
        result.maxAcceleration = maxAcceleration;

        return result;
    }

    void Update()
    {
        //KinematicSteeringOutput steering = kinematicSteering.getSteering();
        //UpdateKinematic(steering);

        UpdateSteering(steering.GetSteering());
        
        Debug.DrawLine(transform.position, transform.position + velocity, Color.blue);
        
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;

        if (activeBehavior == Behavior.ARRIVE)
        {
            Gizmos.DrawWireSphere(playerTransform.position, ((Arrive) steering).slowRadius);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(playerTransform.position, ((Arrive) steering).targetRadius);
        }
            
    }

    
    public override void UpdateSteering(SteeringOutput steering)
    {   
        if (steering == null) 
        {
            this.velocity = Vector3.zero;
            return;
        }

        transform.position += velocity * Time.deltaTime;
        // equivalent to += rotation * Time.deltaTime wrapped in a function to match Unity Quaternion rotation instead of float
        AddRotation(rotation * Time.deltaTime);
        
        velocity += steering.linear * Time.deltaTime;
        rotation += steering.angular * Time.deltaTime; 

        if (velocity.magnitude > this.maxSpeed)
        {
            this.velocity.Normalize();
            this.velocity *= this.maxSpeed;
        }        
    }

    private void AddRotation(float _rotation)
    {
        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles + Vector3.up * _rotation);
        transform.rotation = newRotation;
    }

    
}
