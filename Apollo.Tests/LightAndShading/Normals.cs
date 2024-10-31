using Apollo.Geometry.Objects;
using Apollo.Math;
using Apollo.Math.Objects;

namespace Apollo.Tests.LightAndShading;

public class Normals
{
    [Test]
    public void Normal1()
    {
        var sphere = new Sphere();
        var normal = sphere.NormalAt(MathFactory.Point(1, 0, 0));
        Assert.That(normal.Equals(MathFactory.Vector(1, 0, 0)));
    }
    
    [Test]
    public void Normal2()
    {
        var sphere = new Sphere();
        var normal = sphere.NormalAt(MathFactory.Point(0, 1, 0));
        Assert.That(normal.Equals(MathFactory.Vector(0, 1, 0)));
    }
    
    [Test]
    public void Normal3()
    {
        var sphere = new Sphere();
        var normal = sphere.NormalAt(MathFactory.Point(0, 0, 1));
        Assert.That(normal.Equals(MathFactory.Vector(0, 0, 1)));
    }
    
    [Test]
    public void Normal4()
    {
        var sphere = new Sphere();
        var element = (float) System.Math.Sqrt(3) / 3;
        var normal = sphere.NormalAt(MathFactory.Point(element, element, element));
        Assert.That(normal.Equals(MathFactory.Vector(element, element, element)));
    }
    
    [Test]
    public void NormalNormalized()
    {
        var sphere = new Sphere();
        var element = (float) System.Math.Sqrt(3) / 3;
        var normal = sphere.NormalAt(MathFactory.Point(element, element, element));
        Assert.That(normal.Equals(normal.Normalize()));
    }

    [Test]
    public void TranslatedSphere()
    {
        var sphere = new Sphere();
        sphere.Transform = AMatrix4.TranslationMatrix4(0, 1, 0);
        var normal = sphere.NormalAt(MathFactory.Point(0, 1.70711f, -0.70711f));
        Assert.That(normal.Equals(MathFactory.Vector(0, 0.70711f, -0.70711f)));
    }
    
    [Test]
    public void TranslatedSphere2()
    {
        var sphere = new Sphere();
        var m2 = AMatrix4.ScalingMatrix4(1, 0.5f, 1).Multiply(AMatrix4.ZRotationMatrix4(System.Math.PI/5));
        sphere.Transform = m2;
        var element = (float) System.Math.Sqrt(2) / 2;
        var normal = sphere.NormalAt(MathFactory.Point(0, element, -element));
        Assert.That(normal.Equals(MathFactory.Vector(0, 0.97014f, -0.24254f)));
    }

    [Test]
    public void Reflect1()
    {
        var vector = MathFactory.Vector(1, -1, 0);
        var normal = MathFactory.Vector(0, 1, 0);
        var rVector = vector.Reflect(normal);
        Assert.That(rVector.Equals(MathFactory.Vector(1, 1, 0)));
    }
    
    [Test]
    public void Reflect2()
    {
        var vector = MathFactory.Vector(0, -1, 0);
        var element = (float) System.Math.Sqrt(2) / 2;
        var normal = MathFactory.Vector(element, element, 0);
        var rVector = vector.Reflect(normal);
        Assert.That(rVector.Equals(MathFactory.Vector(1, 0, 0)));
    }
}