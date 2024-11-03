using Apollo.Display;
using Apollo.Display.ColourPresets;

namespace Apollo.Tests.Display;

public class CanvasTests
{
    [Test]
    public void CreateCanvas()
    {
        var canvas = new Canvas(10, 20);
        for (int col = 0; col < 10; col++)
        {
            for (int row = 0; row < 20; row++)
            {
                Assert.That(canvas.Get(col, row) == new Black());
            }
        }
    }

    [Test]
    public void DrawToCanvas()
    {
        var canvas = new Canvas(10, 20);
        canvas.Set(1, 0, new Red());
        Assert.That(canvas.Get(1, 0) == new Red());
    }

    [Test]
    public void PPMExport()
    {
        var canvas = new Canvas(10, 20);
        var c1 = new Colour(1.5f, 0, 0);
        var c2 = new Colour(0, 0.5f, 0);
        var c3 = new Colour(-0.5f, 0, 1);
        canvas.Set(0, 0, c1);
        canvas.Set(2, 1, c2);
        canvas.Set(4, 2, c3);
        Console.Write(canvas.ExportAsPpm());
    }

    [Test]
    public void Fill()
    {
        var canvas = new Canvas(10, 20);
        canvas.Fill(new Colour(1f, 0.8f, 0.6f));
        Console.Write(canvas.ExportAsPpm());
    }
}