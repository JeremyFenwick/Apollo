using Apollo.Display.ColourPresets;
using Apollo.Geometry.Patterns;
using Apollo.Math;

namespace Apollo.Tests.Geometry;

public class CheckerTests
{
    [Test]
    public void CheckerTest()
    {
        var checker = new Checker(new White(), new Black());
        Assert.That(checker.ColourAt(new Point(0 ,0, 0)) == new White());
        Assert.That(checker.ColourAt(new Point(0.99f ,0, 0)) == new White());
        Assert.That(checker.ColourAt(new Point(1.01f ,0, 0)) == new Black());
    }
    
    [Test]
    public void CheckerTest2()
    {
        var checker = new Checker(new White(), new Black());
        Assert.That(checker.ColourAt(new Point(0, 0, 0)) == new White());
        Assert.That(checker.ColourAt(new Point(0, 0.99f, 0)) == new White());
        Assert.That(checker.ColourAt(new Point(0, 1.01f, 0)) == new Black());
    }
    
    [Test]
    public void CheckerTest3()
    {
        var checker = new Checker(new White(), new Black());
        Assert.That(checker.ColourAt(new Point(0, 0, 0)) == new White());
        Assert.That(checker.ColourAt(new Point(0, 0, 0.99f)) == new White());
        Assert.That(checker.ColourAt(new Point(0, 0, 1.01f)) == new Black());
    }
}