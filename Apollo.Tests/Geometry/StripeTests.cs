using Apollo.Display;
using Apollo.Display.ColourPresets;
using Apollo.Geometry;
using Apollo.Geometry.Patterns;
using Apollo.Lighting;
using Apollo.Math;

namespace Apollo.Tests.Geometry;

public class StripeTests
{
    [Test]
    public void StripeTest()
    {
        var stripe = new Stripe(new White(), new Black());
        Assert.That(stripe.ColourAt(new Point(0, 0, 0) )== new White());
        Assert.That(stripe.ColourAt(new Point(0, 1, 0) )== new White());
        Assert.That(stripe.ColourAt(new Point(0, 2, 0) )== new White());
        Assert.That(stripe.ColourAt(new Point(0, 0, 1) )== new White());
        Assert.That(stripe.ColourAt(new Point(0, 0, 2) )== new White());
        Assert.That(stripe.ColourAt(new Point(0.9, 0, 0) )== new White());
        Assert.That(stripe.ColourAt(new Point(1, 0, 0) )== new Black());
        Assert.That(stripe.ColourAt(new Point(-0.1, 0, 0) )== new Black());
        Assert.That(stripe.ColourAt(new Point(-1, 0, 0) )== new Black());
        Assert.That(stripe.ColourAt(new Point(-1.1, 0, 0) )== new White());
    }

    [Test]
    public void StripeLighting()
    {
        var stripe = new Stripe(new White(), new Black());
        var material = new Material();
        material.Pattern = stripe;
        material.Ambient = 1;
        material.Diffuse = 0;
        material.Specular = 0;
        var sphere = new Sphere();
        sphere.Material = material;
        var eyeV = new Vector(0, 0, -1);
        var normalV = new Vector(0, 0, -1);
        var light = new PointLight(new Point(0, 0, -10), new Colour(1, 1, 1));
        var c1 = Shading.Lighting(material, light, new Point(0.9, 0, 0), eyeV, normalV, false, sphere);
        var c2 = Shading.Lighting(material, light, new Point(1.1, 0, 0), eyeV, normalV, false, sphere);
        Assert.That(c1 == new White());
        Assert.That(c2 == new Black());
    }
}