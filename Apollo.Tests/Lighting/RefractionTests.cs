using Apollo.Geometry;
using Apollo.Lighting;
using Apollo.Math;

namespace Apollo.Tests.Lighting;

public class RefractionTests
{
    public Precomputation Comps(int index)
    {
        // Sphere A
        var a = Sphere.Glass();
        a.Transform = Matrix.Scaling(2, 2, 2);
        a.Material.RefractiveIndex = 1.5;
        // Sphere B
        var b = Sphere.Glass();
        b.Transform = Matrix.Translation(0, 0, -0.25);
        b.Material.RefractiveIndex = 2.0;
        // Sphere C
        var c = Sphere.Glass();
        c.Transform = Matrix.Translation(0, 0, 0.25);
        c.Material.RefractiveIndex = 2.5;
        // Ray
        var ray = new Ray(new Point(0, 0, -4), new Vector(0, 0, 1));
        var xs = new Intersections();
        xs.Intersects.Add(new Intersect(a, 2));
        xs.Intersects.Add(new Intersect(b, 2.75));
        xs.Intersects.Add(new Intersect(c, 3.25));
        xs.Intersects.Add(new Intersect(b, 4.75));
        xs.Intersects.Add(new Intersect(c, 5.25));
        xs.Intersects.Add(new Intersect(a, 6));
        return ray.Precompute(xs.Intersects[index], xs);
    }

    [Test]
    public void Intersections1()
    {
        var comps = Comps(0);
        Assert.That(System.Math.Abs(comps.N1 - 1.0) < 0.00001 && System.Math.Abs(comps.N2 - 1.5) < 0.00001);
    }
    
    [Test]
    public void Intersections2()
    {
        var comps = Comps(1);
        Assert.That(System.Math.Abs(comps.N1 - 1.5) < 0.00001 && System.Math.Abs(comps.N2 - 2.0) < 0.00001);
    }
    
    [Test]
    public void Intersections3()
    {
        var comps = Comps(2);
        Assert.That(System.Math.Abs(comps.N1 - 2.0) < 0.00001 && System.Math.Abs(comps.N2 - 2.5) < 0.00001);
    }
    
    [Test]
    public void Intersections4()
    {
        var comps = Comps(3);
        Assert.That(System.Math.Abs(comps.N1 - 2.5) < 0.00001 && System.Math.Abs(comps.N2 - 2.5) < 0.00001);
    }
    
    [Test]
    public void Intersections5()
    {
        var comps = Comps(4);
        Assert.That(System.Math.Abs(comps.N1 - 2.5) < 0.00001 && System.Math.Abs(comps.N2 - 1.5) < 0.00001);
    }
    
    [Test]
    public void Intersections6()
    {
        var comps = Comps(5);
        Assert.That(System.Math.Abs(comps.N1 - 1.5) < 0.00001 && System.Math.Abs(comps.N2 - 1.0) < 0.00001);
    }

    [Test]
    public void UnderPoint()
    {
        var ray = new Ray(new Point(0, 0, -5), new Vector(0, 0, 1));
        var sphere = Sphere.Glass();
        sphere.Transform = Matrix.Translation(0, 0, 1);
        var i = new Intersect(sphere, 5);
        var comps = ray.Precompute(i);
        Assert.That(comps.UnderPoint.Z > 0.00001 /2);
        Assert.That(comps.Point.Z < comps.UnderPoint.Z);
    }
}