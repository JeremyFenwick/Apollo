using Apollo.Display;
using Apollo.Display.AbstractClasses;
using Apollo.Geometry.Interfaces;
using Apollo.Lighting;
using Apollo.Math;
using Apollo.Math.AbstractClasses;

namespace Apollo.Geometry;

public class Sphere : IShape
{
    private IShape _shapeImplementation;
    public Matrix Transform { get; set; }
    public Material Material { get; set; }

    public Sphere()
    {
        Transform = Matrix.Identity();
        Material = new Material();
    }

    public AbstractTuple NormalAt(Point p)
    {
        var objectPoint = this.Transform.Inverse() * p;
        var objectNormal = objectPoint - new Point(0,0,0);
        var worldNormal = (this.Transform.Inverse().Transpose()) * objectNormal;
        var vector = new Vector(worldNormal).Normalize();
        return vector;
    }
    
    public Intersections Intersect(Ray ray)
    {
        var tOrigin = ray.Origin * Transform.Inverse();
        var tDirection = ray.Direction * Transform.Inverse();
        
        var sphereToRay = tOrigin - new Point(0, 0, 0);
        
        var a = tDirection.Dot(tDirection);
        var b = 2 * tDirection.Dot(sphereToRay);
        var c = sphereToRay.Dot(sphereToRay) - 1;
        
        var discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
        {
            return new Intersections();
        }
        else
        {
            var t1 = (double) (-b - System.Math.Sqrt(discriminant)) / (2 * a);
            var t2 = (double) (-b + System.Math.Sqrt(discriminant)) / (2 * a);
            return new Intersections(new Intersect(this, t1), new Intersect(this, t2));
        }
    }

    public AbstractColour ColourAt(AbstractTuple p)
    {
        if (Material.Pattern == null) { return Material.Colour; }
        var objectPoint = Transform.Inverse() * p;
        var patternPoint = Material.Pattern.Transform.Inverse() * objectPoint;
        return Material.Pattern.ColourAt(patternPoint);
    }

    public static Sphere Glass()
    {
        var sphere = new Sphere();
        sphere.Material.Transparency = 1.0;
        sphere.Material.RefractiveIndex = 1.5;
        return sphere;
    }
}