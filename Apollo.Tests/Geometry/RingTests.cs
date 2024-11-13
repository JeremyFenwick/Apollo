using Apollo.Display.ColourPresets;
using Apollo.Geometry.Patterns;
using Apollo.Math;

namespace Apollo.Tests.Geometry;

public class RingTests
{
    [Test]
    public void RingTest()
    {
        var ring = new Ring(new White(), new Black());
        Assert.That(ring.ColourAt(new Point(0, 0, 0)) == new White());
        Assert.That(ring.ColourAt(new Point(1, 0, 0)) == new Black());
        Assert.That(ring.ColourAt(new Point(0, 0, 1)) == new Black());
        Assert.That(ring.ColourAt(new Point(0.708, 0, 0.708)) == new Black());
    }
}