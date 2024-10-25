using System.Drawing;
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
        Assert.That(ppm.Contains("P3\n10 20\n255"));
    }
    
    // Visual Test. No actual assert used.
    [Test]
    public void PpmExport2()
    {
        var canvas = new Canvas(3, 5);
        var c1 = new Colour
        {
            Red = 1.5f,
            Blue = 0,
            Green = 0
        };
        var c2 = new Colour
        {
            Red = 0,
            Blue = 0.5f,
            Green = 0
        };
        var c3 = new Colour
        {
            Red = -0.5f,
            Blue = 0,
            Green = 1
        };
        canvas.Write(0, 0, c1);
        canvas.Write(1, 2, c2);
        canvas.Write(2, 4, c3);
        var ppm2 = canvas.ExportAsPpm();
        Console.WriteLine(ppm2);
    }
    
    // Visual Test. No actual assert used.
    [Test]
    public void PpmExport3()
    {
        var canvas = new Canvas(3, 6);
        var ppm = canvas.ExportAsPpm();
        Console.WriteLine(ppm);
    }
    
    // Visual Test. No actual assert used.
    [Test]
    public void PpmExport4()
    {
        var canvas = new Canvas(3, 7);
        var ppm = canvas.ExportAsPpm();
        Console.WriteLine(ppm);
    }
    
    // Visual Test. No actual assert used.
    [Test]
    public void PpmExport5()
    {
        var canvas = new Canvas(3, 7);
        canvas.SetBackground(DisplayFactory.CreateColour(1f, 0.8f, 0.6f));
        var ppm = canvas.ExportAsPpm();
        Console.WriteLine(ppm);
    }
    
    // Visual Test. No actual assert used.
    [Test]
    public void PpmExport6()
    {
        var canvas = new Canvas(3, 22);
        canvas.SetBackground(DisplayFactory.CreateColour(1f, 0.8f, 0.6f));
        var ppm = canvas.ExportAsPpm();
        Console.WriteLine(ppm);
    }

    // Write the canvas to a text file.
    [Test]
    public void PpmToTextFile()
    {
        var canvas = new Canvas(550, 900);
        var ppmString = canvas.ExportAsPpm();
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        File.WriteAllText(Path.Combine(docPath, "CanvasExport.ppm"), ppmString);
    }
}