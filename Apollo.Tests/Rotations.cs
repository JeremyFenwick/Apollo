using Apollo.Display.Objects;
using Apollo.Math;
using Apollo.Math.Objects;

namespace Apollo.Tests;

public class Rotations
{
    [Test]
    public void XRotation()
    {
        var halfQuarter = AMatrix4.XRotationMatrix4(System.Math.PI / 4);
        var fullQuarter = AMatrix4.XRotationMatrix4(System.Math.PI / 2);
        var point = MathFactory.Point(0, 1, 0);
        var halfPoint = halfQuarter.Multiply(point);
        var fullPoint = fullQuarter.Multiply(point);
        var calc = (float) System.Math.Sqrt(2) / 2;
        Assert.That(MathFactory.Point(0, calc, calc).Equals(halfPoint));
        Assert.That(MathFactory.Point(0, 0, 1).Equals(fullPoint));
    }

    [Test]
    public void YRotation()
    {
        var halfQuarter = AMatrix4.YRotationMatrix4(System.Math.PI / 4);
        var fullQuarter = AMatrix4.YRotationMatrix4(System.Math.PI / 2);
        var point = MathFactory.Point(0, 0, 1);
        var halfPoint = halfQuarter.Multiply(point);
        var fullPoint = fullQuarter.Multiply(point);
        var calc = (float) System.Math.Sqrt(2) / 2;
        Assert.That(MathFactory.Point(calc, 0, calc).Equals(halfPoint));
        Assert.That(MathFactory.Point(1, 0, 0).Equals(fullPoint));
    }
    
    [Test]
    public void ZRotation()
    {
        var halfQuarter = AMatrix4.ZRotationMatrix4(System.Math.PI / 4);
        var fullQuarter = AMatrix4.ZRotationMatrix4(System.Math.PI / 2);
        var point = MathFactory.Point(0, 1, 0);
        var halfPoint = halfQuarter.Multiply(point);
        var fullPoint = fullQuarter.Multiply(point);
        var calc = (float) System.Math.Sqrt(2) / 2;
        Assert.That(MathFactory.Point(-calc, calc, 0).Equals(halfPoint));
        Assert.That(MathFactory.Point(-1, 0, 0).Equals(fullPoint));
    }

    [Test]
    public void Shearing()
    {
        var shearMatrix = AMatrix4.ShearMatrix4(1, 0, 0, 0, 0, 0);
        var point = MathFactory.Point(2, 3, 4);
        Assert.That(shearMatrix.Multiply(point).Equals(MathFactory.Point(5, 3, 4)));
    }
    
    [Test]
    public void Shearing2()
    {
        var shearMatrix = AMatrix4.ShearMatrix4(0, 1, 0, 0, 0, 0);
        var point = MathFactory.Point(2, 3, 4);
        Assert.That(shearMatrix.Multiply(point).Equals(MathFactory.Point(6, 3, 4)));
    }
    
    [Test]
    public void Shearing3()
    {
        var shearMatrix = AMatrix4.ShearMatrix4(0, 0, 1, 0, 0, 0);
        var point = MathFactory.Point(2, 3, 4);
        Assert.That(shearMatrix.Multiply(point).Equals(MathFactory.Point(2, 5, 4)));
    }
    
    [Test]
    public void Shearing4()
    {
        var shearMatrix = AMatrix4.ShearMatrix4(0, 0, 0, 1, 0, 0);
        var point = MathFactory.Point(2, 3, 4);
        Assert.That(shearMatrix.Multiply(point).Equals(MathFactory.Point(2, 7, 4)));
    }
    
    [Test]
    public void Shearing5()
    {
        var shearMatrix = AMatrix4.ShearMatrix4(0, 0, 0, 0, 1, 0);
        var point = MathFactory.Point(2, 3, 4);
        Assert.That(shearMatrix.Multiply(point).Equals(MathFactory.Point(2, 3, 6)));
    }
    
    [Test]
    public void Shearing6()
    {
        var shearMatrix = AMatrix4.ShearMatrix4(0, 0, 0, 0, 0, 1);
        var point = MathFactory.Point(2, 3, 4);
        Assert.That(shearMatrix.Multiply(point).Equals(MathFactory.Point(2, 3, 7)));
    }

    [Test]
    public void Sequences()
    {
        var point = MathFactory.Point(1, 0, 1).XRotate(System.Math.PI / 2).Scale(5, 5, 5).Translate(10, 5, 7);
        Assert.That(MathFactory.Point(15, 0, 7).Equals(point));
    }
    
    // This test exports an image file
    [Test]
    public void GenerateClockFace()
    {
        var canvas = new Canvas(500, 500);
        var point = MathFactory.Point(0, 0, 1);
        var clockColour = new Colour(255, 165, 0);
        for (int i = 0; i < 12; i++)
        {
            point = point.YRotate(System.Math.PI / 6);
            var scaledX = (int) System.Math.Round((point.X * 200) + 250, 0);
            var scaledY = (int) System.Math.Round((point.Z * 200) + 250, 0);
            canvas.Write(scaledY, scaledX, clockColour);
        }
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        File.WriteAllText(Path.Combine(docPath, "Clock.ppm"), canvas.ExportAsPpm());
    }
}