using Apollo.Display.Objects;
using Apollo.Lighting.Objects;
using Apollo.Math;

namespace Apollo.Tests.LightAndShading;

public class Lights
{
    [Test]
    public void PointLight()
    {
        var colour = new Colour(1, 1, 1);
        var point = MathFactory.Point(0, 0, 0);
        var pLight = new PointLight(colour, point);
        Assert.That(pLight.Colour.Equals(colour));
        Assert.That(pLight.Point.Equals(point));
    }
}