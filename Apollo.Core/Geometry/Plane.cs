using Apollo.Geometry.Interfaces;
using Apollo.Lighting;
using Apollo.Math;
using Apollo.Math.AbstractClasses;

namespace Apollo.Geometry;

public class Plane : IShape
{
    public Material Material { get; set; }
    public Matrix Transform { get; set; }
    private const double Epsilon = 0.00001;
    
    public Plane()
    {
        Transform = Matrix.Identity();
        Material = new Material();
    }
    
    public AbstractTuple NormalAt(Point p)
    {
        return new Vector(0, 1, 0);
    }

    public Intersections Intersect(Ray ray)
    {
        var tOrigin = ray.Origin * Transform.Inverse();
        var tDirection = ray.Direction * Transform.Inverse();
        
        if (System.Math.Abs(ray.Direction.Y) < Epsilon)
        {
            return new Intersections();
        }
        else
        {
            var t = -tOrigin.Y / tDirection.Y;
            return new Intersections(new Intersect(this, t));
        }
    }
}