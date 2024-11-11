using Apollo.Geometry;
using Apollo.Lighting;
using Apollo.Math;

namespace Apollo.Tests.Geometry;

public class SphereTests
{
    [Test]
    public void DefaultTransform()
    {
        var sphere = new Sphere();
        Assert.That(sphere.Transform == Matrix.Identity());
    }

    [Test]
    public void ScaledSphere()
    {
        var sphere = new Sphere();
        sphere.Transform = Matrix.Scaling(2, 2, 2);
        var ray = new Ray(new Point(0, 0, -5), new Vector(0, 0, 1));
        var result = sphere.Intersect(ray);
        Assert.That(result.Intersects.Count == 2);
        Assert.That(System.Math.Abs(result.Intersects[0].Time - 3f) < 0.00001);
        Assert.That(System.Math.Abs(result.Intersects[1].Time - 7f) < 0.00001);
    }
    
    [Test]
    public void TranslatedSphere()
    {
        var sphere = new Sphere();
        sphere.Transform = Matrix.Translation(5, 0, 0);
        var ray = new Ray(new Point(0, 0, -5), new Vector(0, 0, 1));
        var result = sphere.Intersect(ray);
        Assert.That(result.Intersects.Count == 0);
    }
}