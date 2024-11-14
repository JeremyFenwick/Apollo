using Apollo.Display;
using Apollo.Display.AbstractClasses;
using Apollo.Display.ColourPresets;
using Apollo.Geometry.Interfaces;
using Apollo.Lighting;
using Apollo.Lighting.Interfaces;
using Apollo.Math;
using Apollo.Math.AbstractClasses;

namespace Apollo.Geometry;

public class World
{
    public List<IShape> Contents { get; }
    public ILight LightSource { get; }

    public World(List<IShape> contents, ILight lightSource)
    {
        (Contents, LightSource) = (contents, lightSource);
    }

    public static World Default()
    {
        var light = new PointLight(new Point(-10, 10, -10), new White());
        var s1 = new Sphere();
        s1.Material = new Material(new Colour(0.8f, 1.0f, 0.6f), 0.1f, 0.7f, 0.2f, 200f, 0);
        var s2 = new Sphere();
        s2.Transform = Matrix.Scaling(0.5f, 0.5f, 0.5f);
        return new World(new List<IShape>() { s1, s2 }, light);
    }

    public bool IsShadowed(AbstractTuple point)
    {
        var v = LightSource.Position - point;
        var distance = v.Magnitude();
        var direction = v.Normalize();
        
        var ray = new Ray(point, direction);
        var intersections = ray.WorldIntersect(this);
        var hit = Ray.Hit(intersections);
        
        return hit != null && hit.Time < distance;
    }

    public AbstractColour ReflectedColour(Precomputation comps, int remaining = 5)
    {
        if (remaining <= 0)
        {
            return new Black();
        }
        if (comps.Object.Material.Reflectivity == 0)
        {
            return new Black();
        };
        var reflectRay = new Ray(comps.OverPoint, comps.ReflectV);
        var colour = reflectRay.ColourAt(this, remaining - 1);
        return colour * comps.Object.Material.Reflectivity;
    }
}