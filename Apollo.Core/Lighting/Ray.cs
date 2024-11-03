using Apollo.Geometry;
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
        return new Point(Origin + (Direction * time));
    }

    public Intersections Intersect(Sphere sphere)
    {
        var sphereToRay = Origin - new Point(0, 0, 0);
        
        var a = Direction.Dot(Direction);
        var b = 2 * Direction.Dot(sphereToRay);
        var c = sphereToRay.Dot(sphereToRay) - 1;
        
        var discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
        {
            return new Intersections();
        }
        else
        {
            var t1 = (float) (-b - System.Math.Sqrt(discriminant)) / (2 * a);
            var t2 = (float) (-b + System.Math.Sqrt(discriminant)) / (2 * a);
            return new Intersections(new Intersections.Intersect(sphere, t1), new Intersections.Intersect(sphere, t2));
        }
    }

    public static Intersections.Intersect? Hit(Intersections intersections)
    {
        intersections.Intersects.Sort();
        return intersections.Intersects.FirstOrDefault(item => item.Time >= 0);
    }
}