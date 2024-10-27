using Apollo.Math;
using Apollo.Math.Objects;

namespace Apollo.Tests;

public class Transformations
{
    [Test]
    public void TransformationMultiple()
    {
        var transform = AMatrix4.TranslationMatrix4(5, -3, 2);
        var point = MathFactory.Point(-3, 4, 5);
        var expectedPoint = MathFactory.Point(2, 1, 7);
        Assert.That(transform.Multiply(point).Equals(expectedPoint));
    }

    [Test]
    public void TransformationInverseMultiple()
    {
        var transform = AMatrix4.TranslationMatrix4(5, -3, 2).Inverse();
        var point = MathFactory.Point(-3, 4, 5);
        var expectedPoint = MathFactory.Point(-8, 7, 3);
        Assert.That(transform.Multiply(point).Equals(expectedPoint));
    }

    [Test]
    public void VectorNotEffectedByTransformation()
    {
        var transform = AMatrix4.TranslationMatrix4(5, -3, 2);
        var vector = MathFactory.Vector(-3, 4, 5);
        Assert.That(transform.Multiply(vector).Equals(vector));
    }
}