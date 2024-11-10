using Apollo.Geometry;
using Apollo.Lighting;
using Apollo.Math;

namespace Apollo.Tests.Lighting;

public class Shadows
{
    [Test]
    public void IsShadowed()
    {
        var world = World.Default();
        var point = new Point(0, 10, 0);
        Assert.That(world.IsShadowed(point), Is.False);
    }
    
    [Test]
    public void IsShadowed2()
    {
        var world = World.Default();
        var point = new Point(10, -10, 10);
        Assert.That(world.IsShadowed(point), Is.True);
    }
    
    [Test]
    public void IsShadowed3()
    {
        var world = World.Default();
        var point = new Point(-20, 20, -20);
        Assert.That(world.IsShadowed(point), Is.False);
    }
        
    [Test]
    public void IsShadowed4()
    {
        var world = World.Default();
        var point = new Point(-2, 2, -2);
        Assert.That(world.IsShadowed(point), Is.False);
    }

    [Test]
    public void OverPoint()
    {
        var ray = new Ray(new Point(0, 0, -5), new Vector(0, 0, 1));
        var sphere = new Sphere();
        sphere.Transform = Matrix.Translation(0, 0, 1);
        var i = new Intersect(sphere, 5);
        var comps = ray.Precompute(i);
        Assert.That(comps.OverPoint.Z < 0.00001f / 2);
        Assert.That(comps.Point.Z > comps.OverPoint.Z);
    }
}