using System.Data.SqlTypes;
using Apollo.Display;
using Apollo.Display.ColourPresets;
using Apollo.Geometry;
using Apollo.Geometry.Patterns;
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

    [Test]
    public void RefractedColour()
    {
        var world = World.Default();
        var shape = world.Contents[0];
        var ray = new Ray(new Point(0, 0, -5), new Vector(0, 0, 1));
        var xs = new Intersections(new Intersect(shape, 4), new Intersect(shape, 6));
        var comps = ray.Precompute(xs.Intersects[0], xs);
        var colour = world.RefractedColour(comps);
        Assert.That(colour == new Black());
    }

    [Test]
    public void InfiniteRecursion()
    {
        var world = World.Default();
        var shape = world.Contents[0];
        shape.Material.Transparency = 1.0;
        shape.Material.RefractiveIndex = 1.5;
        var ray = new Ray(new Point(0, 0, -5), new Vector(0, 0, 1));
        var xs = new Intersections(new Intersect(shape, 4), new Intersect(shape, 6));
        var comps = ray.Precompute(xs.Intersects[0], xs);
        var colour = world.RefractedColour(comps, 0);
        Assert.That(colour == new Black());
    }

    [Test]
    public void InternalRefraction()
    {
        var world = World.Default();
        var shape = world.Contents[0];
        shape.Material.Transparency = 1.0;
        shape.Material.RefractiveIndex = 1.5;
        var elem = System.Math.Sqrt(2) / 2;
        var ray = new Ray(new Point(0, 0, elem), new Vector(0, 1, 0));
        var xs = new Intersections(new Intersect(shape, - elem), new Intersect(shape, elem));
        var comps = ray.Precompute(xs.Intersects[1], xs);
        var colour = world.RefractedColour(comps, 5);
        Assert.That(colour == new Black());
    }
    
    [Test]
    public void RefractionColour()
    {
        var world = World.Default();
        var shape = world.Contents[0];
        shape.Material.Ambient = 1.0;
        shape.Material.Pattern = new TestPattern();
        
        var shape2 = world.Contents[1];
        shape2.Material.Transparency = 1.0;
        shape2.Material.RefractiveIndex = 1.5;
        
        var ray = new Ray(new Point(0, 0, 0.1), new Vector(0, 1, 0));
        var xs = new Intersections();
        xs.Intersects.Add(new Intersect(shape, -0.9899));
        xs.Intersects.Add(new Intersect(shape2, -0.4899));
        xs.Intersects.Add(new Intersect(shape2, 0.4899));
        xs.Intersects.Add(new Intersect(shape, 0.9899));

        var comps = ray.Precompute(xs.Intersects[2], xs);
        var colour = world.RefractedColour(comps, 5);
        
        Assert.That(colour == new Colour(0, 0.99888, 0.04725));
    }
    
    [Test]
    public void RefractionColour2()
    {
        var world = World.Default();
        var floor = new Plane();
        floor.Material.Transparency = 0.5;
        floor.Material.RefractiveIndex = 1.5;
        floor.Transform = Matrix.Translation(0, -1, 0);
        world.AddShape(floor);
        
        var ball = new Sphere();
        ball.Material.Colour = new Red();
        ball.Material.Ambient = 0.5;
        ball.Transform = Matrix.Translation(0, -3.5, -0.5);
        world.AddShape(ball);
        
        var elem = System.Math.Sqrt(2) / 2;
        var ray = new Ray(new Point(0, 0, -3), new Vector(0, -elem, elem));

        var colour = ray.ColourAt(world);
        
        Assert.That(colour == new Colour(0.93642, 0.68642, 0.68642));
    }

    [Test]
    public void FresnelEffect()
    {
        var sphere = Sphere.Glass();
        var elem = System.Math.Sqrt(2) / 2;

        var ray = new Ray(new Point(0, 0, elem), new Vector(0, 1, 0)); 
        var xs = new Intersections(new Intersect(sphere, -elem), new Intersect(sphere, elem));
        var comps = ray.Precompute(xs.Intersects[1], xs);
        var reflectance = Shading.Shclick(comps);
        Assert.That(System.Math.Abs(reflectance - 1) < 0.00001);
    }
    
    [Test]
    public void FresnelEffect2()
    {
        var sphere = Sphere.Glass();
        var ray = new Ray(new Point(0, 0, 0), new Vector(0, 1, 0)); 
        var xs = new Intersections(new Intersect(sphere, -1), new Intersect(sphere, 1));
        var comps = ray.Precompute(xs.Intersects[1], xs);
        var reflectance = Shading.Shclick(comps);
        Assert.That(System.Math.Abs(reflectance - 0.04) < 0.00001);
    }
    
    [Test]
    public void FresnelEffect3()
    {
        var sphere = Sphere.Glass();
        var ray = new Ray(new Point(0, 0.99, -2), new Vector(0, 0, 1));
        var xs = new Intersections(new Intersect(sphere, 1.8589));
        var comps = ray.Precompute(xs.Intersects[0], xs);
        var reflectance = Shading.Shclick(comps);
        Assert.That(System.Math.Abs(reflectance - 0.48873) < 0.00001);
    }
    
    [Test]
    public void FresnelEffect4()
    {
        var world = World.Default();
        var elem = System.Math.Sqrt(2) / 2;
        var ray = new Ray(new Point(0, 0, -3), new Vector(0, -elem, elem)); 
        
        var floor = new Plane();
        floor.Material.Transparency = 0.5;
        floor.Material.RefractiveIndex = 1.5;
        floor.Material.Reflectivity = 0.5;
        floor.Transform = Matrix.Translation(0, -1, 0);
        world.AddShape(floor);
        
        var ball = new Sphere();
        ball.Material.Colour = new Red();
        ball.Material.Ambient = 0.5;
        ball.Transform = Matrix.Translation(0, -3.5, -0.5);
        world.AddShape(ball);

        var color = ray.ColourAt(world);
        Assert.That(color == new Colour(0.93391, 0.69643, 0.69243));
    }
}