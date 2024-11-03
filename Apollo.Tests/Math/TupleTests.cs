using Apollo.Math;

namespace Apollo.Tests.Math;

public class TupleTests
{
    [Test]
    public void CreatePoint()
    {
        var point = new Point(4.3f, -4.2f, 3.1f);
        Assert.That(point.X, Is.EqualTo(4.3f));
        Assert.That(point.Y, Is.EqualTo(-4.2f));
        Assert.That(point.Z, Is.EqualTo(3.1f));
        Assert.That(point.W, Is.EqualTo(1.0f));
    }

    [Test]
    public void CreateVector()
    {
        var vector = new Vector(4.3f, -4.2f, 3.1f);
        Assert.That(vector.X, Is.EqualTo(4.3f));
        Assert.That(vector.Y, Is.EqualTo(-4.2f));
        Assert.That(vector.Z, Is.EqualTo(3.1f));
        Assert.That(vector.W, Is.EqualTo(0f));
    }

    [Test]
    public void RawATuple()
    {
        var rawATuple = new ATuple(4.3f, -4.2f, 3.1f, 1.5f);
        Assert.That(rawATuple.X, Is.EqualTo(4.3f));
        Assert.That(rawATuple.Y, Is.EqualTo(-4.2f));
        Assert.That(rawATuple.Z, Is.EqualTo(3.1f));
        Assert.That(rawATuple.W, Is.EqualTo(1.5f));
    }
    
    [Test]
    public void Equality1()
    {
        var vector = new Vector(4.3f, -4.2f, 3.1f);
        var vector2 = new Vector(4.3f, -4.2f, 3.1f);
        Assert.That(vector == vector2);
    }
    
    [Test]
    public void Equality2()
    {
        var vector = new Vector(4.1f, -4.2f, 3.1f);
        var vector2 = new Vector(4.3f, -4.2f, 3.1f);
        Assert.That(vector != vector2);
    }
    
    [Test]
    public void Addition()
    {
        var t1 = new ATuple(3f, -2f, 5f, 1f);
        var t2 = new ATuple(-2f, 3f, 1f, 0f);
        Assert.That((t1 + t2) == (new ATuple(1f, 1f, 6f, 1f)));
    }

    [Test]
    public void Subtraction()
    {
        var p1 = new Point(3, 2, 1);
        var p2 = new Point(5, 6, 7);
        Assert.That((p1 - p2) == (new Vector(-2, -4, -6)));
    }
    
    [Test]
    public void Subtraction2()
    {
        var p1 = new Point(3, 2, 1);
        var v1 = new Vector(5, 6, 7);
        Assert.That((p1 - v1) == (new Point(-2, -4, -6)));
    }
    
    [Test]
    public void Negation()
    {
        var ATuple = new ATuple(1, -2, 3, -4);
        Assert.That(-ATuple == new ATuple(-1, 2, -3, 4));
    }

    [Test]
    public void Multiplication()
    {
        var ATuple = new ATuple(1, -2, 3, -4);
        Assert.That(ATuple * 3.5f == new ATuple(3.5f, -7, 10.5f, -14));
    }
    
    [Test]
    public void Multiplication2()
    {
        var ATuple = new ATuple(1, -2, 3, -4);
        Assert.That(ATuple * 0.5f == new ATuple(0.5f, -1, 1.5f, -2));
    }

    [Test]
    public void Division()
    {
        var ATuple = new ATuple(1, -2, 3, -4);
        Assert.That(ATuple / 2 == new ATuple(0.5f, -1, 1.5f, -2));
    }

    [Test]
    public void Magnitude()
    {
        var vector = new Vector(0, 1, 0);
        Assert.That(System.Math.Abs(vector.Magnitude() - 1) < 0.00001);
    }
    
    [Test]
    public void Magnitude2()
    {
        var vector = new Vector(0, 0, 1);
        Assert.That(System.Math.Abs(vector.Magnitude() - 1) < 0.00001);
    }
    
    [Test]
    public void Magnitude3()
    {
        var vector = new Vector(1, 2, 3);
        Assert.That(System.Math.Abs(vector.Magnitude() - System.Math.Sqrt(14)) < 0.00001);
    }
    
    [Test]
    public void Magnitude4()
    {
        var vector = new Vector(-1, -2, -3);
        Assert.That(System.Math.Abs(vector.Magnitude() - System.Math.Sqrt(14)) < 0.00001);
    }
    
    [Test]
    public void Normalize()
    {
        var vector = new Vector(4, 0, 0);
        Assert.That(vector.Normalize() == new ATuple(1, 0, 0, 0));
    }
    
    [Test]
    public void Normalize2()
    {
        var vector = new Vector(1, 2, 3);
        Assert.That(vector.Normalize() == new ATuple(0.26726f, 0.53452f, 0.80178f, 0));
    }
    
    [Test]
    public void Normalize3()
    {
        var vector = new Vector(1, 2, 3);
        Assert.That(System.Math.Abs(vector.Normalize().Magnitude() - 1) < 0.00001);
    }

    [Test]
    public void Dot()
    {
        var v1 = new Vector(1, 2, 3);
        var v2 = new Vector(2, 3, 4);
        Assert.That(System.Math.Abs(v1.Dot(v2) - 20f) < 0.00001);
    }
    
    [Test]
    public void Cross()
    {
        var v1 = new Vector(1, 2, 3);
        var v2 = new Vector(2, 3, 4);
        Assert.That(v1.Cross(v2) == new ATuple(-1, 2, -1, 0));
        Assert.That(v2.Cross(v1) == new ATuple(1, -2, 1, 0));
    }
}