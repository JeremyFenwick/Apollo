using Apollo.Display.AbstractClasses;
using Apollo.Geometry.Interfaces;
using Apollo.Lighting;
using Apollo.Math;
using Apollo.Math.AbstractClasses;

namespace Apollo.Geometry;

public class Plane : IShape
{
    public Material Material { get; set; }
    public Matrix Transform { get; set; }
    private const double Epsilon = 0.0000001;
    
    public Plane()
    {
        Transform = Matrix.Identity();
        Material = new Material();
    }
    
    public AbstractTuple NormalAt(Point p)
    {
        var objectNormal = new Vector(0, 1, 0);
        var worldNormal = (this.Transform.Inverse().Transpose()) * objectNormal;
        var vector = new Vector(worldNormal).Normalize();
        return vector;    
    }

    public Intersections Intersect(Ray ray)
    {
        var tOrigin = ray.Origin * Transform.Inverse();
        var tDirection = ray.Direction * Transform.Inverse();
        
        if (System.Math.Abs(tDirection.Y) < Epsilon)
        {
            return new Intersections();
        }
        else
        {
            var t = -tOrigin.Y / tDirection.Y;
            return new Intersections(new Intersect(this, t));
        }
    }
    
    public AbstractColour ColourAt(AbstractTuple p)
    {
        if (Material.Pattern == null) { return Material.Colour; }
        var objectPoint = Transform.Inverse() * p;
        var patternPoint = Material.Pattern.Transform.Inverse() * objectPoint;
        return Material.Pattern.ColourAt(patternPoint);
    }
}