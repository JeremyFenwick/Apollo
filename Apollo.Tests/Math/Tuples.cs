using Apollo.Math;
using Apollo.Math.Objects;
using Apollo.Tests.Cannon;

namespace Apollo.Tests.Math;

public class Tests
{
    [Test]
    public void Point()
    {
        var point = new ATuple(4.3f, -4.2f, 3.1f, 1.0f);
        Assert.That(point.X, Is.EqualTo(4.3f));
        Assert.That(point.Y, Is.EqualTo(-4.2f));
        Assert.That(point.Z, Is.EqualTo(3.1f));
        Assert.That(point.IsPoint(), Is.True);
        Assert.That(point.IsVector(), Is.False);
    }

    [Test]
    public void Vector()
    {
        var vector = new ATuple(4.3f, -4.2f, 3.1f, 0.0f);
        Assert.That(vector.X, Is.EqualTo(4.3f));
        Assert.That(vector.Y, Is.EqualTo(-4.2f));
        Assert.That(vector.Z, Is.EqualTo(3.1f));
        Assert.That(vector.IsPoint(), Is.False);
        Assert.That(vector.IsVector(), Is.True);
    }

    [Test]
    public void CreatePoint()
    {
        var point = MathFactory.Point(4.3f, -4.2f, 3.1f);
        Assert.That(point.X, Is.EqualTo(4.3f));
        Assert.That(point.Y, Is.EqualTo(-4.2f));
        Assert.That(point.Z, Is.EqualTo(3.1f));
        Assert.That(point.IsPoint(), Is.True);
        Assert.That(point.IsVector(), Is.False);
    }

    [Test]
    public void CreateVector()
    {
        var vector = MathFactory.Vector(4.3f, -4.2f, 3.1f);
        Assert.That(vector.X, Is.EqualTo(4.3f));
        Assert.That(vector.Y, Is.EqualTo(-4.2f));
        Assert.That(vector.Z, Is.EqualTo(3.1f));
        Assert.That(vector.IsPoint(), Is.False);
        Assert.That(vector.IsVector(), Is.True);
    }

    [Test]
    public void Add()
    {
        var a1 = MathFactory.Point(3f, -2f, 5f);
        var a2 = MathFactory.Vector(-2f, 3f, 1f);
        var result = a1.Add(a2);
        Assert.That(result.X, Is.EqualTo(1f));
        Assert.That(result.Y, Is.EqualTo(1f));
        Assert.That(result.Z, Is.EqualTo(6f));
        Assert.That(result.IsPoint(), Is.True);
    }
    
    [Test]
    public void Subtract()
    {
        var a1 = MathFactory.Point(3f, 2f, 1f);
        var a2 = MathFactory.Point(5f, 6f, 7f);
        var result = a1.Subtract(a2);
        Assert.That(result.X, Is.EqualTo(-2f));
        Assert.That(result.Y, Is.EqualTo(-4f));
        Assert.That(result.Z, Is.EqualTo(-6f));
        Assert.That(result.IsVector(), Is.True);
    }
    
    [Test]
    public void Subtract2()
    {
        var a1 = MathFactory.Point(3f, 2f, 1f);
        var a2 = MathFactory.Vector(5f, 6f, 7f);
        var result = a1.Subtract(a2);
        Assert.That(result.X, Is.EqualTo(-2f));
        Assert.That(result.Y, Is.EqualTo(-4f));
        Assert.That(result.Z, Is.EqualTo(-6f));
        Assert.That(result.IsPoint(), Is.True);
    }
    
    [Test]
    public void Subtract3()
    {
        var a1 = MathFactory.Vector(3f, 2f, 1f);
        var a2 = MathFactory.Vector(5f, 6f, 7f);
        var result = a1.Subtract(a2);
        Assert.That(result.X, Is.EqualTo(-2f));
        Assert.That(result.Y, Is.EqualTo(-4f));
        Assert.That(result.Z, Is.EqualTo(-6f));
        Assert.That(result.IsVector(), Is.True);
    }
    
    [Test]
    public void Negate()
    {
        var tuple = new ATuple(1f, -2f, 3f, 0f);
        var nTuple = tuple.Negate();
        Assert.That(nTuple.X, Is.EqualTo(-1f));
        Assert.That(nTuple.Y, Is.EqualTo(2f));
        Assert.That(nTuple.Z, Is.EqualTo(-3f));
        Assert.That(nTuple.W, Is.EqualTo(0f));
    }

    [Test]
    public void Multiply()
    {
        var tuple = new ATuple(1f, -2f, 3f, -4f);
        var mTuple = tuple.Multiply(3.5f);
        Assert.That(mTuple.X, Is.EqualTo(3.5f));
        Assert.That(mTuple.Y, Is.EqualTo(-7f));
        Assert.That(mTuple.Z, Is.EqualTo(10.5f));
        Assert.That(mTuple.W, Is.EqualTo(-14f));
    }
    
    [Test]
    public void Divide()
    {
        var tuple = new ATuple(1f, -2f, 3f, -4f);
        var mTuple = tuple.Divide(2f);
        Assert.That(mTuple.X, Is.EqualTo(0.5f));
        Assert.That(mTuple.Y, Is.EqualTo(-1f));
        Assert.That(mTuple.Z, Is.EqualTo(1.5f));
        Assert.That(mTuple.W, Is.EqualTo(-2f));
    }

    [Test]
    public void Magnitude()
    {
        var v1 = MathFactory.Vector(1f, 0f, 0f);
        Assert.That(v1.Magnitude(), Is.EqualTo(1f));
        var v2 = MathFactory.Vector(0f, 1f, 0f);
        Assert.That(v2.Magnitude(), Is.EqualTo(1f));
        var v3 = MathFactory.Vector(0f, 0f, 1f);
        Assert.That(v3.Magnitude(), Is.EqualTo(1f));
        var v4 = MathFactory.Vector(1f, 2f, 3f);
        Assert.True(v4.Magnitude() - System.Math.Sqrt(14f) < 0.00001f);
        var v5 = MathFactory.Vector(-1f, -2f, -3f);
        Assert.True(v5.Magnitude() - System.Math.Sqrt(14f) < 0.00001f);
    }

    [Test]
    public void Normalize()
    {
        var v1 = MathFactory.Vector(4, 0, 0);
        var nv1 = v1.Normalize();
        Assert.That(nv1.X, Is.EqualTo(1));
        Assert.That(nv1.Y, Is.EqualTo(0));
        Assert.That(nv1.Z, Is.EqualTo(0));
        Assert.That(nv1.W, Is.EqualTo(0));
        var v2 = MathFactory.Vector(1, 2, 3);
        var nv2 = v2.Normalize();
        Assert.True(System.Math.Abs(nv2.X - 0.26726) < 0.00001);
        Assert.True(System.Math.Abs(nv2.Y - 0.53452) < 0.00001);
        Assert.True(System.Math.Abs(nv2.Z - 0.80178) < 0.00001);
        Assert.True(System.Math.Abs(nv2.Magnitude() - 1.0) < 0.00001);
    }

    [Test]
    public void DotProduct()
    {
        var v1 = MathFactory.Vector(1, 2, 3);
        var v2 = MathFactory.Vector(2, 3, 4);
        var dp = v1.DotProduct(v2);
        Assert.That(dp, Is.EqualTo(20));
    }

    [Test]
    public void CrossProduct()
    {
        var v1 = MathFactory.Vector(1, 2, 3);
        var v2 = MathFactory.Vector(2, 3, 4);
        var c1 = v1.CrossProduct(v2);
        var c2 = v2.CrossProduct(v1);
        Assert.True(c1.Equals(MathFactory.Vector(-1, 2, -1)));
        Assert.True(c2.Equals(MathFactory.Vector(1, -2, 1)));
    }
    
    // Visual Test. No actual assert used.
    [Test]
    public void FireCannon()
    {
        var p = new Projectile(MathFactory.Point(0, 1, 0), MathFactory.Vector(1, 1, 0).Normalize());
        var v = new FEnvironment(MathFactory.Vector(0, -0.1f, 0), MathFactory.Vector(-0.01f, 0, 0));
        while (p.Position.Y > 0)
        {
            p = Cannon.CannonFire.Tick(p, v);
            Console.WriteLine(System.Math.Round(p.Position.Y, 2));
        }
    }
}