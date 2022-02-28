/// <summary>
/// Steering Behavior to match position variable
/// If chasing a stationary target will likely orbit around target.
/// Revert to Arrive in this case
/// Chapter 3.3 (Page 59ff)
/// </summary>
public class Seek : AbstractSteering
{
    public override SteeringOutput GetSteering()
    {
        SteeringOutput result = new SteeringOutput();

        result.linear = target.GetPosition() - character.GetPosition();
        result.linear.Normalize();
        result.linear *= maxAcceleration;

        result.angular = 0f;

        return result;
    }
}
