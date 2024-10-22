using Apollo.Display;
using NuGet.Frameworks;

namespace Apollo.Tests;

public class CanvasTests
{
    [Test]
    public void CreateCanvas()
    {
        var canvas = new Canvas(20, 10);
        Assert.That(canvas, Is.Not.Null);
        Assert.True(canvas.Read(5, 5).Blue == 0f);
        Assert.True(canvas.Read(5, 5).Green == 0f);
        Assert.True(canvas.Read(5, 5).Red == 0f);
    }

    [Test]
    public void WriteToCanvas()
    {
        var canvas = new Canvas(20, 10);
        var red = new Colour
        {
            Red = 1,
            Blue = 0,
            Green = 0
        };
        canvas.Write(3, 2, red);
        Assert.That(canvas.Read(3, 2).Red, Is.EqualTo(1.0f));
    }

    [Test]
    public void PpmExport()
    {
        var canvas = new Canvas(20, 10);
        var ppm = canvas.ExportAsPpm();
        Assert.That(ppm.Equals("P3\n10 20\n255"));
    }
    
    [Test]
    public void PpmExport2()
    {
        var canvas = new Canvas(3, 5);
        var ppm = canvas.ExportAsPpm();
        Assert.That(ppm.Equals("P3\n5 3\n255"));
    }
}