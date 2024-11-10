using Apollo.Display;
using Apollo.Display.ColourPresets;
using Apollo.Geometry;
using Apollo.Lighting;
using Apollo.Math;

namespace Apollo.Tests.Lighting;

public class ShadingTests
{
    [Test]
    public void Normal()
    {
        var sphere = new Sphere();
        Assert.That(sphere.NormalAt(new Point(1, 0, 0) ) == new Vector(1, 0, 0));
    }
    
    [Test]
    public void Normal2()
    {
        var sphere = new Sphere();
        Assert.That(sphere.NormalAt(new Point(0, 1, 0) ) == new Vector(0, 1, 0));
    }
    
    [Test]
    public void Normal3()
    {
        var sphere = new Sphere();
        Assert.That(sphere.NormalAt(new Point(0, 0, 1) ) == new Vector(0, 0, 1));
    }
    
    [Test]
    public void Normal4()
    {
        var sphere = new Sphere();
        var elem = (float) System.Math.Sqrt(3) / 3;
        Assert.That(sphere.NormalAt(new Point(elem, elem, elem)) == new Vector(elem, elem, elem));
    }
    
    [Test]
    public void Normal5()
    {
        var sphere = new Sphere();
        var elem = (float) System.Math.Sqrt(3) / 3;
        var normal = sphere.NormalAt(new Point(elem, elem, elem));
        Assert.That(normal.Normalize() == normal);
    }

    [Test]
    public void Normal6()
    {
        var sphere = new Sphere();
        sphere.Transform = Matrix.Translation(0, 1, 0);
        var normal = sphere.NormalAt(new Point(0, 1.70711f, -0.70711f));
        Assert.That(normal == new Vector(0, 0.70711f, -0.70711f));
    }
    
    [Test]
    public void Normal7()
    {
        var sphere = new Sphere();
        sphere.Transform = Matrix.Scaling(1, 0.5f, 1) * Matrix.ZRotation(System.Math.PI / 5);
        var elem = (float) System.Math.Sqrt(2) / 2;
        var normal = sphere.NormalAt(new Point(0, elem, -elem));
        Assert.That(normal == new Vector(0, 0.97014f, -0.24254f));
    }

    [Test]
    public void Reflect()
    {
        var vector = new Vector(1, -1, 0);
        var normal = new Vector(0, 1, 0);
        Assert.That(vector.Reflect(normal) == new Vector(1, 1, 0));
    }
    
    [Test]
    public void Reflect2()
    {
        var elem = (float) System.Math.Sqrt(2) / 2;
        var vector = new Vector(0, -1, 0);
        var normal = new Vector(elem, elem, 0);
        Assert.That(vector.Reflect(normal) == new Vector(1, 0, 0));
    }

    [Test]
    public void PhongModel()
    {
        var material = new Material();
        var position = new Point(0, 0, 0);
        var eyeV = new Vector(0, 0, -1);
        var normalV = new Vector(0, 0, -1);
        var light = new PointLight(new Point(0, 0, -10), new White());
        var result = Shading.Lighting(material, light, position, eyeV, normalV, false);
        Assert.That(result == new Colour(1.9f, 1.9f, 1.9f));
    }
    
    [Test]
    public void PhongModel2()
    {
        var elem = (float) System.Math.Sqrt(2) / 2;
        var material = new Material();
        var position = new Point(0, 0, 0);
        var eyeV = new Vector(0, elem, -elem);
        var normalV = new Vector(0, 0, -1);
        var light = new PointLight(new Point(0, 0, -10), new White());
        var result = Shading.Lighting(material, light, position, eyeV, normalV, false);
        Assert.That(result == new Colour(1f, 1f, 1f));
    }
    
    [Test]
    public void PhongModel3()
    {
        var elem = 0.7364f;
        var material = new Material();
        var position = new Point(0, 0, 0);
        var eyeV = new Vector(0, 0, -1);
        var normalV = new Vector(0, 0, -1);
        var light = new PointLight(new Point(0, 10, -10), new White());
        var result = Shading.Lighting(material, light, position, eyeV, normalV, false);
        Assert.That(result == new Colour(elem, elem, elem));
    }
    
    [Test]
    public void PhongModel4()
    {
        var elem = 1.6364f;
        var elem2 = (float) System.Math.Sqrt(2) / 2;
        var material = new Material();
        var position = new Point(0, 0, 0);
        var eyeV = new Vector(0, -elem2, -elem2);
        var normalV = new Vector(0, 0, -1);
        var light = new PointLight(new Point(0, 10, -10), new White());
        var result = Shading.Lighting(material, light, position, eyeV, normalV, false);
        Assert.That(result == new Colour(elem, elem, elem));
    }
    
    [Test]
    public void PhongModel5()
    {
        var material = new Material();
        var position = new Point(0, 0, 0);
        var eyeV = new Vector(0, 0, -1);
        var normalV = new Vector(0, 0, -1);
        var light = new PointLight(new Point(0, 0, 10), new White());
        var result = Shading.Lighting(material, light, position, eyeV, normalV, false);
        Assert.That(result == new Colour(0.1f, 0.1f, 0.1f));
    }

    [Test]
    public void PhongModel6()
    {
        var material = new Material();
        var position = new Point(0, 0, 0);
        var eyeV = new Vector(0, 0, -1);
        var normalV = new Vector(0, 0, -1);
        var light = new PointLight(new Point(0, 0, 10), new White());
        var result = Shading.Lighting(material, light, position, eyeV, normalV, true);
        Assert.That(result == new Colour(0.1f, 0.1f, 0.1f));
    }
}