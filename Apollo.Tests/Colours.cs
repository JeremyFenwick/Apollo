using Apollo.Display;

namespace Apollo.Tests;

public class Colours
{
    [Test]
    public void CreateColour()
    {
        var colour = new Colour(-0.5f, 0.4f, 1.7f);
        Assert.That(colour.Red, Is.EqualTo(-0.5f));
        Assert.That(colour.Green, Is.EqualTo(0.4f));
        Assert.That(colour.Blue, Is.EqualTo(1.7f));
    }

    [Test]
    public void AddColours()
    {
        var c1 = new Colour(0.9f, 0.6f, 0.75f);
        var c2 = new Colour(0.7f, 0.1f, 0.25f);
        var c3 = c1.Add(c2);
        Assert.True(System.Math.Abs(c3.Red - 1.6f) < 0.00001f);
        Assert.True(System.Math.Abs(c3.Green - 0.7f) < 0.00001f);
        Assert.True(System.Math.Abs(c3.Blue - 1f) < 0.00001f);
    }

    [Test]
    public void SubtractColours()
    {
        var c1 = new Colour(0.9f, 0.6f, 0.75f);
        var c2 = new Colour(0.7f, 0.1f, 0.25f);
        var c3 = c1.Subtract(c2);
        Assert.True(System.Math.Abs(c3.Red - 0.2f) < 0.00001f);
        Assert.True(System.Math.Abs(c3.Green - 0.5f) < 0.00001f);
        Assert.True(System.Math.Abs(c3.Blue - 0.5f) < 0.00001f);
    }

    [Test]
    public void MultiplyColours()
    {
        var c1 = new Colour(0.2f, 0.3f, 0.4f);
        var c2 = c1.Multiply(2);
        Assert.That(c2.Red, Is.EqualTo(0.4f));
        Assert.That(c2.Green, Is.EqualTo(0.6f));
        Assert.That(c2.Blue, Is.EqualTo(0.8f));
    }

    [Test]
    public void HadamardProduct()
    {
        var c1 = new Colour(1f, 0.2f, 0.4f);
        var c2 = new Colour(0.9f, 1f, 0.1f);
        var c3 = c1.HadamardProduct(c2);
        Assert.True(System.Math.Abs(c3.Red - 0.9f) < 0.00001f);
        Assert.True(System.Math.Abs(c3.Green - 0.2f) < 0.00001f);
        Assert.True(System.Math.Abs(c3.Blue - 0.04f) < 0.00001f);
    }
}