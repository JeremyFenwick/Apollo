using Apollo.Geometry;
using Apollo.Lighting;
using Apollo.Math;

namespace Apollo.Tests.Lighting;

public class RayTests
{
    [Test]
    public void CreateRay()
    {
        var origin = new Point(1, 2, 3);
        var direction = new Vector(4, 5, 6);
        var ray = new Ray(origin, direction);
        Assert.That(ray.Origin, Is.EqualTo(origin));
        Assert.That(ray.Direction, Is.EqualTo(direction));
    }

    [Test]
    public void Distance()
    {
        var ray = new Ray(new Point(2, 3, 4), new Vector(1, 0, 0));
        var a1 = ray.Position(0);
        Assert.That(ray.Position(0) == new Point(2, 3, 4));
        Assert.That(ray.Position(1) == new Point(3, 3, 4));
        Assert.That(ray.Position(-1f) == new Point(1, 3, 4));
        Assert.That(ray.Position(2.5f) == new Point(4.5f, 3, 4));
    }

    [Test]
    public void Intersection()
    {
        var ray = new Ray(new Point(0, 0, -5), new Vector(0, 0, 1));
        var result = ray.Intersect(new Sphere());
        Assert.That(result.Intersects.Count == 2);
        Assert.That(System.Math.Abs(result.Intersects[0].Time - 4.0) < 0.00001);
        Assert.That(System.Math.Abs(result.Intersects[1].Time - 6.0) < 0.00001);
    }
    
    [Test]
    public void Intersection2()
    {
        var ray = new Ray(new Point(0, 1, -5), new Vector(0, 0, 1));
        var result = ray.Intersect(new Sphere());
        Assert.That(result.Intersects.Count == 2);
        Assert.That(System.Math.Abs(result.Intersects[0].Time - 5.0) < 0.00001);
        Assert.That(System.Math.Abs(result.Intersects[1].Time - 5.0) < 0.00001);
    }
    
    [Test]
    public void Intersection3()
    {
        var ray = new Ray(new Point(0, 2, -5), new Vector(0, 0, 1));
        var result = ray.Intersect(new Sphere());
        Assert.That(result.Intersects.Count == 0);
    }
    
    [Test]
    public void Intersection4()
    {
        var ray = new Ray(new Point(0, 0, 0), new Vector(0, 0, 1));
        var result = ray.Intersect(new Sphere());
        Assert.That(result.Intersects.Count == 2);
        Assert.That(System.Math.Abs(result.Intersects[0].Time - (- 1.0)) < 0.00001);
        Assert.That(System.Math.Abs(result.Intersects[1].Time - 1.0) < 0.00001);
    }
    
    [Test]
    public void Intersection5()
    {
        var ray = new Ray(new Point(0, 0, 5), new Vector(0, 0, 1));
        var result = ray.Intersect(new Sphere());
        Assert.That(result.Intersects.Count == 2);
        Assert.That(System.Math.Abs(result.Intersects[0].Time  - (- 6.0)) < 0.00001);
        Assert.That(System.Math.Abs(result.Intersects[1].Time  - (- 4.0)) < 0.00001);
    }

    [Test]
    public void Intersection6()
    {
        var sphere = new Sphere();
        var intersect = new Intersect(sphere, 3.5f);
        Assert.That(intersect.Object.Equals(sphere));
    }
    
    [Test]
    public void Intersection7()
    {
        var sphere = new Sphere();
        var intersect1 = new Intersect(sphere, 1);
        var intersect2 = new Intersect(sphere, 2);
        var intersections = new Intersections(intersect1, intersect2).Intersects;
        Assert.That(intersections.Count == 2);
        Assert.That(intersections[0].Object.Equals(sphere));
        Assert.That(intersections[1].Object.Equals(sphere));
    }

    [Test]
    public void Hits()
    {
        var sphere = new Sphere();
        var intersect1 = new Intersect(sphere, 1);
        var intersect2 = new Intersect(sphere, 2);
        var intersections = new Intersections(intersect1, intersect2);
        Assert.That(Ray.Hit(intersections) == intersect1);
    }
    
    [Test]
    public void Hits2()
    {
        var sphere = new Sphere();
        var intersect1 = new Intersect(sphere, -1);
        var intersect2 = new Intersect(sphere, 1);
        var intersections = new Intersections(intersect1, intersect2);
        Assert.That(Ray.Hit(intersections) == intersect2);
    }
    
    [Test]
    public void Hits3()
    {
        var sphere = new Sphere();
        var intersect1 = new Intersect(sphere, -2);
        var intersect2 = new Intersect(sphere, -1);
        var intersections = new Intersections(intersect1, intersect2);
        Assert.That(Ray.Hit(intersections) == null);
    }
    
    [Test]
    public void Hits4()
    {
        var sphere = new Sphere();
        var intersect1 = new Intersect(sphere, 5);
        var intersect2 = new Intersect(sphere, 7);
        var intersect3 = new Intersect(sphere, -3);
        var intersect4 = new Intersect(sphere, 2);
        var intersections = new Intersections([intersect1, intersect2, intersect3, intersect4]);
        Assert.That(Ray.Hit(intersections) == intersect4);
    }

    [Test]
    public void Translate()
    {
        var ray = new Ray(new Point(1, 2, 3), new Vector(0, 1, 0));
        var tRay = ray.Translate(3, 4, 5);
        Assert.That(tRay.Origin == new Point(4, 6, 8));
        Assert.That(tRay.Direction == new Vector(0, 1, 0));
    }
    
    [Test]
    public void Scale()
    {
        var ray = new Ray(new Point(1, 2, 3), new Vector(0, 1, 0));
        var tRay = ray.Scale(2, 3, 4);
        Assert.That(tRay.Origin == new Point(2, 6, 12));
        Assert.That(tRay.Direction == new Vector(0, 3, 0));
    }
    
    
}