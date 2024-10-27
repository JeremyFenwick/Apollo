using Apollo.Math;
using Apollo.Math.Objects;

namespace Apollo.Tests;

public class Scaling
{
    [Test]
    public void PointScaling()
    {
        var scalingMatrix = AMatrix4.ScalingMatrix4(2, 3, 4);
        var point = MathFactory.Point(-4, 6, 8);
        var expectedPoint = MathFactory.Point(-8, 18, 32);
        Assert.That(scalingMatrix.Multiply(point).Equals(expectedPoint));
    }
    
    [Test]
    public void VectorScaling()
    {
        var scalingMatrix = AMatrix4.ScalingMatrix4(2, 3, 4);
        var vector = MathFactory.Vector(-4, 6, 8);
        var scaledVector = scalingMatrix.Multiply(vector);
        var expectedVector = MathFactory.Vector(-8, 18, 32);
        Assert.That(scaledVector.Equals(expectedVector));
    }
    
    [Test]
    public void InverseVectorScaling()
    {
        var scalingMatrix = AMatrix4.ScalingMatrix4(2, 3, 4).Inverse();
        var vector = MathFactory.Vector(-4, 6, 8);
        var scaledVector = scalingMatrix.Multiply(vector);
        var expectedVector = MathFactory.Vector(-2, 2, 2);
        Assert.That(scaledVector.Equals(expectedVector));
    }
}