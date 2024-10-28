using Apollo.Geometry.Objects;
using Apollo.Math;
using Apollo.Rays.Objects;

namespace Apollo.Tests.Rays;

public class Rays
{
    [Test]
    public void CreateRay()
    {
        var origin = MathFactory.Point(1, 2, 3);
        var direction = MathFactory.Vector(4, 5, 6);
        var ray = new Ray(origin, direction);
        Assert.That(ray.Origin.Equals(origin));
        Assert.That(ray.Direction.Equals(direction));
    }

    [Test]
    public void RayPosition()
    {
        var origin = MathFactory.Point(2, 3, 4);
        var direction = MathFactory.Vector(1, 0, 0);
        var ray = new Ray(origin, direction);
        Assert.That(ray.Position(0).Equals(MathFactory.Point(2, 3, 4)));
        Assert.That(ray.Position(1).Equals(MathFactory.Point(3, 3, 4)));
        Assert.That(ray.Position(-1).Equals(MathFactory.Point(1, 3, 4)));
        Assert.That(ray.Position(2.5f).Equals(MathFactory.Point(4.5f, 3, 4)));
    }

    [Test]
    public void LineSphereIntersection()
    {
        var ray = new Ray(MathFactory.Point(0, 0, -5), MathFactory.Vector(0, 0, 1));
        var sphere = new Sphere();
        var result = ray.SphereIntersect(sphere);
        Assert.That(result.Count > 0);
        Assert.That(System.Math.Abs(result[0].Location - 4f) < 0.00001);
        Assert.That(System.Math.Abs(result[1].Location - 6f) < 0.00001);
    }

    [Test]
    public void LineSphereTangent()
    {
        var ray = new Ray(MathFactory.Point(0, 1, -5), MathFactory.Vector(0, 0, 1));
        var sphere = new Sphere();
        var result = ray.SphereIntersect(sphere);
        Assert.That(result.Count > 0);
        Assert.That(System.Math.Abs(result[0].Location - 5f) < 0.00001);
        Assert.That(System.Math.Abs(result[1].Location - 5f) < 0.00001);
    }
    
    [Test]
    public void RayMissesSphere()
    {
        var ray = new Ray(MathFactory.Point(0, 2, -5), MathFactory.Vector(0, 0, 1));
        var sphere = new Sphere();
        var result = ray.SphereIntersect(sphere);
        Assert.That(result.Count == 0);
    }
    
    [Test]
    public void RayStartsInsideSphere()
    {
        var ray = new Ray(MathFactory.Point(0, 0, 0), MathFactory.Vector(0, 0, 1));
        var sphere = new Sphere();
        var result = ray.SphereIntersect(sphere);
        Assert.That(result.Count > 0);
        Assert.That(System.Math.Abs(result[0].Location + 1f) < 0.00001);
        Assert.That(System.Math.Abs(result[1].Location - 1f) < 0.00001);
    }
    
    [Test]
    public void RayStartsBehindSphere()
    {
        var ray = new Ray(MathFactory.Point(0, 0, 5), MathFactory.Vector(0, 0, 1));
        var sphere = new Sphere();
        var result = ray.SphereIntersect(sphere);
        Assert.That(result.Count() > 0);
        Assert.That(System.Math.Abs(result[0].Location + 6f) < 0.00001);
        Assert.That(System.Math.Abs(result[1].Location + 4f) < 0.00001);
    }

    [Test]
    public void IntersectionReturnsShape()
    {
        var ray = new Ray(MathFactory.Point(0, 0, -5), MathFactory.Vector(0, 0, 1));
        var sphere = new Sphere();
        var result = ray.SphereIntersect(sphere);
        Assert.That(result.Count == 2);
        Assert.That(result[0].Object == sphere);
        Assert.That(result[1].Object == sphere);
    }
    
    [Test]
    public void SortIntersections()
    {
        var sphere = new Sphere();
        var i1 = new Intersect(sphere, 5);
        var i2 = new Intersect(sphere, 7);
        var i3 = new Intersect(sphere, -3);
        var i4 = new Intersect(sphere, 2);
        List<Intersect> xs = [i1, i2, i3, i4];
        xs.Sort();
        Assert.That(xs[0] == i3);
    }

    [Test]
    public void Hit1()
    {
        var sphere = new Sphere();
        var i1 = new Intersect(sphere, 5);
        var i2 = new Intersect(sphere, 7);
        List<Intersect> xs = [i1, i2];
        Assert.That(Ray.Hit(xs) == i1);
    }
    
    [Test]
    public void Hit2()
    {
        var sphere = new Sphere();
        var i1 = new Intersect(sphere, -1);
        var i2 = new Intersect(sphere, 1);
        List<Intersect> xs = [i1, i2];
        Assert.That(Ray.Hit(xs) == i2);
    }
    
    [Test]
    public void Hit3()
    {
        var sphere = new Sphere();
        var i1 = new Intersect(sphere, -2);
        var i2 = new Intersect(sphere, -1);
        List<Intersect> xs = [i1, i2];
        Assert.That(Ray.Hit(xs) == null);
    }

    [Test]
    public void Hit4()
    {
        var sphere = new Sphere();
        var i1 = new Intersect(sphere, 5);
        var i2 = new Intersect(sphere, 7);
        var i3 = new Intersect(sphere, -3);
        var i4 = new Intersect(sphere, 2);
        List<Intersect> xs = [i1, i2, i3, i4];
        Assert.That(Ray.Hit(xs) == i4);
    }
}