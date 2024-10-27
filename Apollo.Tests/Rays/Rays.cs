using Apollo.Math;
using Apollo.Rays.Objects;

namespace Apollo.Tests.Rays;

public class Rays
{
    [Test]
    public void CreateRay()
    {
        var origin = MathFactory.Point(1, 2, 3);
        var direction = MathFactory.Vector(4, 5, 6);
        var ray = new Ray(origin, direction);
        Assert.That(ray.Origin.Equals(origin));
        Assert.That(ray.Direction.Equals(direction));
    }

    [Test]
    public void RayPosition()
    {
        var origin = MathFactory.Point(2, 3, 4);
        var direction = MathFactory.Vector(1, 0, 0);
        var ray = new Ray(origin, direction);
        Assert.That(ray.Position(0).Equals(MathFactory.Point(2, 3, 4)));
        Assert.That(ray.Position(1).Equals(MathFactory.Point(3, 3, 4)));
        Assert.That(ray.Position(-1).Equals(MathFactory.Point(1, 3, 4)));
        Assert.That(ray.Position(2.5f).Equals(MathFactory.Point(4.5f, 3, 4)));
    }
}