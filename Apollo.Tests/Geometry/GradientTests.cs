using System.Drawing;
using Apollo.Display;
using Apollo.Display.ColourPresets;
using Apollo.Geometry.Patterns;
using Point = Apollo.Math.Point;

namespace Apollo.Tests.Geometry;

public class GradientTests
{
    [Test]
    public void GradientTest()
    {
        var gradient = new Gradient(new White(), new Black());
        Assert.That(gradient.ColourAt(new Point(0, 0, 0)) == new White());
        Assert.That(gradient.ColourAt(new Point(0.25, 0, 0)) == new Colour(0.75f, 0.75f, 0.75f));
        Assert.That(gradient.ColourAt(new Point(0.5, 0, 0)) == new Colour(0.5f, 0.5f, 0.5f));
        Assert.That(gradient.ColourAt(new Point(0.75, 0, 0)) == new Colour(0.25f, 0.25f, 0.25f));
    }
}