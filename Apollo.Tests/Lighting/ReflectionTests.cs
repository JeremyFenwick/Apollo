using Apollo.Display;
using Apollo.Display.ColourPresets;
using Apollo.Geometry;
using Apollo.Lighting;
using Apollo.Math;

namespace Apollo.Tests.Lighting;

public class ReflectionTests
{
    [Test]
    public void ReflectV()
    {
        var shape = new Plane();
        var elem = System.Math.Sqrt(2) / 2;
        var ray = new Ray(new Point(0, 1, -1), new Vector(0, -elem, elem));
        var intersect = new Intersect(shape, System.Math.Sqrt(2));
        var comps = ray.Precompute(intersect);
        Assert.That(comps.ReflectV == new Vector(0, elem, elem));
    }

    [Test]
    public void NonReflectiveSurface()
    {
        var world = World.Default();
        var ray = new Ray(new Point(0, 0, 0), new Vector(0, 0, 1));
        var shape = world.Contents[1];
        shape.Material.Ambient = 1;
        var intersect = new Intersect(shape, 1);
        var comps = ray.Precompute(intersect);
        var colour = world.ReflectedColour(comps);
        Assert.That(colour == new Black());
    }

    [Test]
    public void ReflectiveSurface()
    {
        var world = World.Default();
        var plane = new Plane();
        plane.Material.Reflectivity = 0.5;
        plane.Transform = Matrix.Translation(0, -1, 0);
        world.Contents.Add(plane);
        var ray = new Ray(new Point(0, 0, -3), new Vector(0, - System.Math.Sqrt(2)/2, System.Math.Sqrt(2)/2));
        var intersect = new Intersect(plane, System.Math.Sqrt(2));
        var comps = ray.Precompute(intersect);
        var colour = world.ReflectedColour(comps);
        Assert.That(colour == new Colour(0.19032, 0.2379, 0.14274));
    }
    
    [Test]
    public void ReflectiveSurface2()
    {
        var world = World.Default();
        var plane = new Plane();
        plane.Material.Reflectivity = 0.5;
        plane.Transform = Matrix.Translation(0, -1, 0);
        world.Contents.Add(plane);
        var ray = new Ray(new Point(0, 0, -3), new Vector(0, - System.Math.Sqrt(2)/2, System.Math.Sqrt(2)/2));
        var colour = ray.ColourAt(world);
        Assert.That(colour == new Colour(0.87677, 0.92436, 0.82918));
    }
    
    [Test]
    public void InfiniteReflection()
    {
        var lower = new Plane();
        lower.Material.Reflectivity = 1;
        lower.Transform = Matrix.Translation(0, -1, 0);
        var upper = new Plane();
        upper.Material.Reflectivity = 1;
        upper.Transform = Matrix.Translation(0, 1, 0);
        var light = new PointLight(new Point(0, 0, 0), new White());
        var world = new World([lower, upper], light);
        var ray = new Ray(new Point(0, 0, 0), new Vector(0, 1, 0));
        ray.ColourAt(world);
        Assert.That(true);
    }
    
    [Test]
    public void LimitRecursion()
    {
        var world = World.Default();
        var plane = new Plane();
        plane.Material.Reflectivity = 0.5;
        plane.Transform = Matrix.Translation(0, -1, 0);
        world.Contents.Add(plane);
        var ray = new Ray(new Point(0, 0, -3), new Vector(0, - System.Math.Sqrt(2)/2, System.Math.Sqrt(2)/2));
        Assert.That(ray.ColourAt(world, 0) == new Black());
    }
}