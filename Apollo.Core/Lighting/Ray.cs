using Apollo.Math;

namespace Apollo.Lighting;

public class Ray
{
    public Point Origin { get; }
    public Vector Direction { get; }

    public Ray(Point origin, Vector direction)
    {
        (Origin, Direction) = (origin, direction);
    }

    public Point Position(float time)
    {
        return new Point(Origin + Direction * time);
    }
}