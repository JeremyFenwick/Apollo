using Apollo.Geometry;
using Apollo.Lighting;
using Apollo.Math;

namespace Apollo.Tests.Geometry;

public class PlaneTests
{
    [Test]
    public void CreatePlane()
    {
        var plane = new Plane();
        var n1 = plane.NormalAt(new Point(0, 0, 0));
        var n2 = plane.NormalAt(new Point(10, 0, -10));
        var n3 = plane.NormalAt(new Point(-5, 0, 150));
        Assert.That(n1 == new Vector(0, 1, 0));
        Assert.That(n2 == new Vector(0, 1, 0));
        Assert.That(n3 == new Vector(0, 1, 0));
    }

    [Test]
    public void Intersect1()
    {
        var plane = new Plane();
        var ray = new Ray(new Point(0, 10, 0), new Vector(0, 0, 1));
        var intersections = plane.Intersect(ray);
        Assert.That(intersections.Intersects.Count == 0);
    }
    
    [Test]
    public void Intersect2()
    {
        var plane = new Plane();
        var ray = new Ray(new Point(0, 0, 0), new Vector(0, 0, 1));
        var intersections = plane.Intersect(ray);
        Assert.That(intersections.Intersects.Count == 0);
    }
    
    [Test]
    public void Intersect3()
    {
        var plane = new Plane();
        var ray = new Ray(new Point(0, 1, 0), new Vector(0, -1, 0));
        var intersections = plane.Intersect(ray);
        Assert.That(System.Math.Abs(intersections.Intersects[0].Time - 1) < 0.00001);
        Assert.That(intersections.Intersects[0].Object == plane);
    }
    
    [Test]
    public void Intersect4()
    {
        var plane = new Plane();
        var ray = new Ray(new Point(0, -1, 0), new Vector(0, 1, 0));
        var intersections = plane.Intersect(ray);
        Assert.That(System.Math.Abs(intersections.Intersects[0].Time - 1) < 0.00001);
        Assert.That(intersections.Intersects[0].Object == plane);
    }
}