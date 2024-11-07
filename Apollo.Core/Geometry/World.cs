using Apollo.Display;
using Apollo.Display.ColourPresets;
using Apollo.Geometry.Interfaces;
using Apollo.Lighting;
using Apollo.Lighting.Interfaces;
using Apollo.Math;

namespace Apollo.Geometry;

public class World
{
    public List<GeometricObject> Contents { get; }
    public ILight LightSource { get; }

    public World(List<GeometricObject> contents, ILight lightSource)
    {
        (Contents, LightSource) = (contents, lightSource);
    }

    public static World Default()
    {
        var light = new PointLight(new Point(-10, 10, -10), new White());
        var s1 = new Sphere();
        s1.Material = new Material(new Colour(0.8f, 1.0f, 0.6f), 0.1f, 0.7f, 0.2f, 200f);
        var s2 = new Sphere();
        s2.Transform = Matrix.Scaling(0.5f, 0.5f, 0.5f);
        return new World(new List<GeometricObject>() { s1, s2 }, light);
    }
}