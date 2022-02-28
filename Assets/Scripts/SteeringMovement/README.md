# Steering Behaviors

Steering Behaviors incorporate acceleration. 
Thus the velocity and rotation properties will also be applied to the current values over time

```
position += velocity * Time.deltatime
orientation += rotation * Time.deltatime

velocity += steering.linear * Time.deltatime
rotation += steering.angular * Time.deltatime
```

## Seek and Arrival

Seek will not work for stationary targets since acceleration and deceleration are identical. This results in an orbiting effect.
Arrival combats this behavior by implementing a slowRadius starting at which the AI will no longer try to aproach at maximum speed and a targetRadius where movement will stop completely.

## Align

## Velocity Matching

## Pursue and Evade

