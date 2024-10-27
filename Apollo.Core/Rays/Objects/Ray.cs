using Apollo.Math.Objects;
namespace Apollo.Rays.Objects;

/// <summary> 
/// A ray for use by the ray tracer. Has an origin and direction.
/// </summary>
public readonly struct Ray
{
    public ATuple Origin { get; }
    public ATuple Direction { get; }

    public Ray(ATuple origin, ATuple direction)
    {
        Origin = origin;
        Direction = direction;
    }

    /// <summary> 
    /// Returns the position (point) of a ray at a given time.
    /// </summary>
    public ATuple Position(float time)
    {
        return Origin.Add(Direction.Multiply(time));
    }
}