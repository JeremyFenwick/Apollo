using Apollo.Math;
namespace Apollo.Tests;

public class Tests
{
    [Test]
    public void Point()
    {
        var point = new ATuple
        {
            X = 4.3,
            Y = -4.2,
            Z = 3.1,
            W = 1.0
        };
        Assert.That(point.X, Is.EqualTo(4.3));
        Assert.That(point.Y, Is.EqualTo(-4.2));
        Assert.That(point.Z, Is.EqualTo(3.1));
        var isPoint = ATuple.IsPoint(point);
        var isVector = ATuple.IsVector(point);
        Assert.That(isPoint, Is.True);
        Assert.That(isVector, Is.False);
    }

    [Test]
    public void Vector()
    {
        var vector = new ATuple
        {
            X = 4.3,
            Y = -4.2,
            Z = 3.1,
            W = 0.0
        };
        Assert.That(vector.X, Is.EqualTo(4.3));
        Assert.That(vector.Y, Is.EqualTo(-4.2));
        Assert.That(vector.Z, Is.EqualTo(3.1));
        var isPoint = ATuple.IsPoint(vector);
        var isVector = ATuple.IsVector(vector);
        Assert.That(isPoint, Is.False);
        Assert.That(isVector, Is.True);
    }

    [Test]
    public void CreatePoint()
    {
        var point = MathFactory.Point(4.3, -4.2, 3.1);
        Assert.That(point.X, Is.EqualTo(4.3));
        Assert.That(point.Y, Is.EqualTo(-4.2));
        Assert.That(point.Z, Is.EqualTo(3.1));
        var isPoint = ATuple.IsPoint(point);
        var isVector = ATuple.IsVector(point);
        Assert.That(isPoint, Is.True);
        Assert.That(isVector, Is.False);
    }

    [Test]
    public void CreateVector()
    {
        var vector = MathFactory.Vector(4.3, -4.2, 3.1);
        Assert.That(vector.X, Is.EqualTo(4.3));
        Assert.That(vector.Y, Is.EqualTo(-4.2));
        Assert.That(vector.Z, Is.EqualTo(3.1));
        var isPoint = ATuple.IsPoint(vector);
        var isVector = ATuple.IsVector(vector);
        Assert.That(isPoint, Is.False);
        Assert.That(isVector, Is.True);
    }

    [Test]
    public void Add()
    {
        var a1 = MathFactory.Point(3, -2, 5);
        var a2 = MathFactory.Vector(-2, 3, 1);
        var result = ATuple.Add(a1, a2);
        var isPoint = ATuple.IsPoint(result);
        Assert.That(result.X, Is.EqualTo(1));
        Assert.That(result.Y, Is.EqualTo(1));
        Assert.That(result.Z, Is.EqualTo(6));
        Assert.That(isPoint, Is.True);
    }
    
    [Test]
    public void Subtract()
    {
        var a1 = MathFactory.Point(3, 2, 1);
        var a2 = MathFactory.Point(5, 6, 7);
        var result = ATuple.Subtract(a1, a2);
        Assert.That(result.X, Is.EqualTo(-2));
        Assert.That(result.Y, Is.EqualTo(-4));
        Assert.That(result.Z, Is.EqualTo(-6));
        Assert.That(ATuple.IsVector(result), Is.True);
    }
    
    [Test]
    public void Subtract2()
    {
        var a1 = MathFactory.Point(3, 2, 1);
        var a2 = MathFactory.Vector(5, 6, 7);
        var result = ATuple.Subtract(a1, a2);
        Assert.That(result.X, Is.EqualTo(-2));
        Assert.That(result.Y, Is.EqualTo(-4));
        Assert.That(result.Z, Is.EqualTo(-6));
        Assert.That(ATuple.IsPoint(result), Is.True);
    }
    
    [Test]
    public void Subtract3()
    {
        var a1 = MathFactory.Vector(3, 2, 1);
        var a2 = MathFactory.Vector(5, 6, 7);
        var result = ATuple.Subtract(a1, a2);
        Assert.That(result.X, Is.EqualTo(-2));
        Assert.That(result.Y, Is.EqualTo(-4));
        Assert.That(result.Z, Is.EqualTo(-6));
        Assert.That(ATuple.IsVector(result), Is.True);
    }
    
    [Test]
    public void Negate()
    {
        var tuple = new ATuple
        {
            X = 1,
            Y = -2,
            Z = 3,
            W = 0
        };
        var nTuple = ATuple.Negate(tuple);
        Assert.That(nTuple.X, Is.EqualTo(-1));
        Assert.That(nTuple.Y, Is.EqualTo(2));
        Assert.That(nTuple.Z, Is.EqualTo(-3));
        Assert.That(nTuple.W, Is.EqualTo(0));
    }

    [Test]
    public void Multiply()
    {
        var tuple = new ATuple
        {
            X = 1,
            Y = -2,
            Z = 3,
            W = -4
        };
        var mTuple = ATuple.Multiply(tuple, 3.5);
        Assert.That(mTuple.X, Is.EqualTo(3.5));
        Assert.That(mTuple.Y, Is.EqualTo(-7));
        Assert.That(mTuple.Z, Is.EqualTo(10.5));
        Assert.That(mTuple.W, Is.EqualTo(-14));
    }
    
    [Test]
    public void Divide()
    {
        var tuple = new ATuple
        {
            X = 1,
            Y = -2,
            Z = 3,
            W = -4
        };
        var mTuple = ATuple.Divide(tuple, 2);
        Assert.That(mTuple.X, Is.EqualTo(0.5));
        Assert.That(mTuple.Y, Is.EqualTo(-1));
        Assert.That(mTuple.Z, Is.EqualTo(1.5));
        Assert.That(mTuple.W, Is.EqualTo(-2));
    }

    [Test]
    public void Magnitude()
    {
        var v1 = MathFactory.Vector(1, 0, 0);
        Assert.That(ATuple.Magnitude(v1), Is.EqualTo(1));
        var v2 = MathFactory.Vector(0, 1, 0);
        Assert.That(ATuple.Magnitude(v2), Is.EqualTo(1));
        var v3 = MathFactory.Vector(0, 0, 1);
        Assert.That(ATuple.Magnitude(v3), Is.EqualTo(1));
        var v4 = MathFactory.Vector(1, 2, 3);
        Assert.That(ATuple.Magnitude(v4), Is.EqualTo(System.Math.Sqrt(14)));
        var v5 = MathFactory.Vector(-1, -2, -3);
        Assert.That(ATuple.Magnitude(v5), Is.EqualTo(System.Math.Sqrt(14)));
    }

    [Test]
    public void Normalize()
    {
        var v1 = MathFactory.Vector(4, 0, 0);
        var nv1 = ATuple.Normalize(v1);
        Assert.That(nv1.X, Is.EqualTo(1));
        Assert.That(nv1.Y, Is.EqualTo(0));
        Assert.That(nv1.Z, Is.EqualTo(0));
        Assert.That(nv1.W, Is.EqualTo(0));
        var v2 = MathFactory.Vector(1, 2, 3);
        var nv2 = ATuple.Normalize(v2);
        Assert.True(System.Math.Abs(nv2.X - 0.26726) < 0.00001);
        Assert.True(System.Math.Abs(nv2.Y - 0.53452) < 0.00001);
        Assert.True(System.Math.Abs(nv2.Z - 0.80178) < 0.00001);
        Assert.True(System.Math.Abs(ATuple.Magnitude(nv2) - 1.0) < 0.00001);
    }

    [Test]
    public void DotProduct()
    {
        var v1 = MathFactory.Vector(1, 2, 3);
        var v2 = MathFactory.Vector(2, 3, 4);
        var dp = ATuple.DotProduct(v1, v2);
        Assert.That(dp, Is.EqualTo(20));
    }

    [Test]
    public void CrossProduct()
    {
        var v1 = MathFactory.Vector(1, 2, 3);
        var v2 = MathFactory.Vector(2, 3, 4);
        var c1 = ATuple.CrossProduct(v1, v2);
        var c2 = ATuple.CrossProduct(v2, v1);
        Assert.True(ATuple.Equals(c1, MathFactory.Vector(-1, 2, -1)));
        Assert.True(ATuple.Equals(c2, MathFactory.Vector(1, -2, 1)));
    }
}