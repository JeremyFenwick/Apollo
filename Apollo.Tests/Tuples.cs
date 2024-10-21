using Apollo.Math;
namespace Apollo.Tests;

public class Tests
{
    [Test]
    public void PointTuple()
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
    public void VectorTuple()
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
    public void AddTuples()
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
    public void SubtractTuples()
    {
        var a1 = MathFactory.Point(3, 2, 1);
        var a2 = MathFactory.Point(5, 6, 7);
        var result = ATuple.Subtract(a1, a2);
        var isVector = ATuple.IsVector(result);
        Assert.That(result.X, Is.EqualTo(-2));
        Assert.That(result.Y, Is.EqualTo(-4));
        Assert.That(result.Z, Is.EqualTo(-6));
        Assert.That(isVector, Is.True);
    }
}