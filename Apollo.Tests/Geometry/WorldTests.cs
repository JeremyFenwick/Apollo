using System.Drawing;
using Apollo.Display;
using Apollo.Display.ColourPresets;
using Apollo.Geometry;
using Apollo.Lighting;
using Apollo.Math;
using Point = Apollo.Math.Point;

namespace Apollo.Tests.Geometry;

public class WorldTests
{
    [Test]
    public void DefaultWorldRays()
    {
        var world = World.Default();
        var ray = new Ray(new Point(0, 0, -5f), new Vector(0, 0, 1));
        var result = ray.WorldIntersect(world).Intersects;
        Assert.That(System.Math.Abs(result[0].Time - 4) < 0.0001);
        Assert.That(System.Math.Abs(result[1].Time - 4.5) < 0.0001);
        Assert.That(System.Math.Abs(result[2].Time - 5.5) < 0.0001);
        Assert.That(System.Math.Abs(result[3].Time - 6) < 0.0001);
    }

    [Test]
    public void ColourAt()
    {
        var world = World.Default();
        var ray = new Ray(new Point(0, 0, -5f), new Vector(0, 1, 0));
        var colourAt = ray.ColourAt(world);
        Assert.That(colourAt == new Black());
    }
    
    [Test]
    public void ColourAt2()
    {
        var world = World.Default();
        var ray = new Ray(new Point(0, 0, -5f), new Vector(0, 0, 1));
        var colourAt = ray.ColourAt(world);
        Assert.That(colourAt == new Colour(0.38066f, 0.47583f, 0.2855f));
    }
}