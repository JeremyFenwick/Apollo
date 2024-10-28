using Apollo.Geometry.Objects;
using Apollo.Math;
using Apollo.Math.Objects;
namespace Apollo.Rays.Objects;

/// <summary> 
/// A ray for use by the ray tracer. Has an origin and direction.
/// </summary>
public class Ray
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

    /// <summary> 
    /// Computes where this ray intersects a sphere. Returns an intersect which contains the intersection points, if they exist.
    /// https://en.wikipedia.org/wiki/Line%E2%80%93sphere_intersection
    /// </summary>
    public Intersect SphereIntersect(Sphere sphere)
    {
        var sphereToRay = this.Origin.Subtract(MathFactory.Point(0, 0, 0));

        var a = this.Direction.DotProduct(this.Direction);
        var b = 2 * this.Direction.DotProduct(sphereToRay);
        var c = sphereToRay.DotProduct(sphereToRay) - 1;

        var discriminant = (b * b) - (4 * a * c);
        if (discriminant < 0)
        {
            return new Intersect(false, -1, -1);
        }
        else
        {
            var t1 = (float) (-b - System.Math.Sqrt(discriminant)) / (2 * a);
            var t2 = (float) (-b + System.Math.Sqrt(discriminant)) / (2 * a);
            return new Intersect(true, t1, t2);
        }
    }
}