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
        s1.Material = new Material(new Colour(0.8f, 1.0f, 0.6f), 0.1f, 0.7f, 0.2f, 200f, 0, 0, 1);
        var s2 = new Sphere();
        s2.Transform = Matrix.Scaling(0.5f, 0.5f, 0.5f);
        return new World(new List<IShape>() { s1, s2 }, light);
    }

    public void AddShape(IShape shape)
    {
        Contents.Add(shape);
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

    public AbstractColour RefractedColour(Precomputation comps, int remaining = 5)
    {
        if (remaining <= 0)
        {
            return new Black();
        }
        if (comps.Object.Material.Transparency == 0)
        {
            return new Black();
        }
        // Check for internal reflection
        var nRatio = comps.N1 / comps.N2;
        var cosI = comps.EyeV.Dot(comps.NormalV);
        var sin2T = (nRatio * nRatio) * (1 - (cosI * cosI));
        if (sin2T > 1)
        {
            return new Black();
        }

        var cosT = System.Math.Sqrt(1 - sin2T);
        var direction = (comps.NormalV * ((nRatio * cosI) - cosT)) - (comps.EyeV * nRatio);
        var refractRay = new Ray(comps.UnderPoint, direction);
        return refractRay.ColourAt(this, remaining - 1) * comps.Object.Material.Transparency;
    }
}