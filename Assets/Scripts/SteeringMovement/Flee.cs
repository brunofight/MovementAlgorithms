/// <summary>
/// Steering Behavior to match position variable
/// If chasing a stationary target will likely orbit around target.
/// Revert to Arrive in this case
/// Chapter 3.3 (Page 59ff)
/// </summary>
public class Flee : AbstractSteering
{
    public override SteeringOutput GetSteering()
    {
        SteeringOutput result = new SteeringOutput();

        result.linear = character.GetPosition() - target.GetPosition();
        result.linear.Normalize();
        result.linear *= maxAcceleration;

        result.angular = 0f;

        return result;
    }
}
