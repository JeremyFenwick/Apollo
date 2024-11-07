using Apollo.Geometry;
using Apollo.Lighting;
using Apollo.Math;

namespace Apollo.Tests.Lighting;

public class IntersectTests
{
    [Test]
    public void Precompute()
    {
        var ray = new Ray(new Point(0, 0, -5), new Vector(0, 0, 1));
        var sphere = new Sphere();
        var intersect = new Intersect(sphere, 4);
        var comps = ray.Precompute(intersect);
        Assert.That(comps.Object == sphere);
        Assert.That(comps.Point == new Point(0, 0, -1));
        Assert.That(comps.EyeV == new Vector(0, 0, -1));
        Assert.That(comps.NormalV == new Vector(0, 0, -1));
    }

    [Test]
    public void PrecomputeInside()
    {
        var ray = new Ray(new Point(0, 0, 0), new Vector(0, 0, 1));
        var sphere = new Sphere();
        var intersect = new Intersect(sphere, 1);
        var comps = ray.Precompute(intersect);
        Assert.That(comps.Point == new Point(0, 0, 1));
        Assert.That(comps.EyeV == new Vector(0, 0, -1));
        Assert.That(comps.Inside);
        Assert.That(comps.NormalV == new Vector(0, 0, -1));
    }
}