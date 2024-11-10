using Apollo.Display;
using Apollo.Geometry;
using Apollo.Math;

namespace Apollo.Tests.Display;

public class CameraTests
{
    [Test]
    public void BuildCamera()
    {
        var camera = new Camera(200, 125, System.Math.PI/2);
         Assert.That(System.Math.Abs(camera.PixelSize - 0.01f) < 0.00001);
    }
    
    [Test]
    public void BuildCamera2()
    {
        var camera = new Camera(125, 200, System.Math.PI/2);
        Assert.That(System.Math.Abs(camera.PixelSize - 0.01f) < 0.00001);
    }
    
    [Test]
    public void RayForPixel()
    {
        var camera = new Camera(201, 101, System.Math.PI/2);
        var ray = camera.RayForPixel(100, 50);
        Assert.That(ray.Origin == new Point(0, 0, 0));
        Assert.That(ray.Direction == new Vector(0, 0, -1));
    }
    
    [Test]
    public void RayForPixel2()
    {
        var camera = new Camera(201, 101, System.Math.PI/2);
        var ray = camera.RayForPixel(0, 0);
        Assert.That(ray.Origin == new Point(0, 0, 0));
        Assert.That(ray.Direction == new Vector(0.66519f, 0.33259f, -0.66851f));
    }
    
    [Test]
    public void RayForPixel3()
    {
        var camera = new Camera(201, 101, System.Math.PI/2);
        camera.Transform = Matrix.YRotation(System.Math.PI / 4) * Matrix.Translation(0, -2, 5);
        var elem = (float) System.Math.Sqrt(2) / 2;
        var ray = camera.RayForPixel(100, 50);
        Assert.That(ray.Origin == new Point(0, 2, -5));
        Assert.That(ray.Direction == new Vector(elem, 0, -elem));
    }

    [Test]
    public void Render()
    {
        var world = World.Default();
        var camera = new Camera(11, 11, System.Math.PI / 2);
        var from = new Point(0, 0, -5);
        var to = new Vector(0, 0, 0);
        var up = new Vector(0, 1, 0);
        camera.Transform = Matrix.ViewTransform(from, to, up);
        var image = camera.Render(world);
        Assert.That(image.Get(5, 5) == new Colour(0.38066f, 0.47583f, 0.2855f));
    }
}