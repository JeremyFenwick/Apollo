using Apollo.Math;
using Apollo.Math.Objects;

namespace Apollo.Tests;

public class Matrices
{
    [Test]
    public void matrix4x4()
    {
        var m = new AMatrix4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
        Assert.That(m.Get(1, 0), Is.EqualTo(5));
    }
}