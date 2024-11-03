using Apollo.Display;

namespace Apollo.Tests.Display;

public class ColourTests
{
    [Test]
    public void CreateColour()
    {
        var colour = new Colour(-0.5f, 0.4f, 1.7f);
        Assert.That(System.Math.Abs(colour.R - (-0.5f)) < 0.00001);
        Assert.That(System.Math.Abs(colour.G - (0.4f)) < 0.00001);
        Assert.That(System.Math.Abs(colour.B - (1.7f)) < 0.00001);
    }

    [Test]
    public void Addition()
    {
        var c1 = new Colour(0.9f, 0.6f, 0.75f);
        var c2 = new Colour(0.7f, 0.1f, 0.25f);
        Assert.That(c1 + c2 == new Colour(1.6f, 0.7f, 1f));
    }

    [Test]
    public void Subtraction()
    {
        var c1 = new Colour(0.9f, 0.6f, 0.75f);
        var c2 = new Colour(0.7f, 0.1f, 0.25f);
        Assert.That(c1 - c2 == new Colour(0.2f, 0.5f, 0.5f));
    }
    
    [Test]
    public void ScalarMultiplication()
    {
        var c1 = new Colour(0.2f, 0.3f, 0.4f);
        Assert.That(c1 * 2 == new Colour(0.4f, 0.6f, 0.8f));
    }
    
    [Test]
    public void ColourMultiplication()
    {
        var c1 = new Colour(1f, 0.2f, 0.4f);
        var c2 = new Colour(0.9f, 1f, 0.1f);
        Assert.That(c1 * c2 == new Colour(0.9f, 0.2f, 0.04f));
    }
}