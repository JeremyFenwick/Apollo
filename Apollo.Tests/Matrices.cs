using Apollo.Math;
using Apollo.Math.Objects;

namespace Apollo.Tests;

public class Matrices
{
    [Test]
    public void Matrix4X4()
    {
        var matrix = new AMatrix4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
        Assert.That(matrix.Get(1, 0), Is.EqualTo(5));
    }

    [Test]
    public void Matrix4X4_2()
    {
        var matrix = new AMatrix4(1, 2, 3, 4, 5.5f, 6.5f, 7.5f, 8.5f, 9, 10, 11, 12, 13.5f, 14.5f, 15.5f, 16.5f);
        Assert.That(matrix.Get(0, 0), Is.EqualTo(1));
        Assert.That(matrix.Get(0, 3), Is.EqualTo(4));
        Assert.That(matrix.Get(1, 0), Is.EqualTo(5.5f));
        Assert.That(matrix.Get(1, 2), Is.EqualTo(7.5f));
        Assert.That(matrix.Get(2, 2), Is.EqualTo(11));
        Assert.That(matrix.Get(3, 0), Is.EqualTo(13.5f));
        Assert.That(matrix.Get(3, 2), Is.EqualTo(15.5f));
    }
    
    [Test]
    public void Matrix3X3()
    {
        var matrix = new AMatrix3(-3, -5, 0, 1, -2, -7, 0, 1, 1);
        Assert.That(matrix.Get(0, 0), Is.EqualTo(-3));
        Assert.That(matrix.Get(1, 1), Is.EqualTo(-2));
        Assert.That(matrix.Get(2, 2), Is.EqualTo(1));
    }
    
    [Test]
    public void Matrix2X2()
    {
        var matrix = new AMatrix2(-3, 5, 1, -2);
        Assert.That(matrix.Get(0, 0), Is.EqualTo(-3));
        Assert.That(matrix.Get(0, 1), Is.EqualTo(5));
        Assert.That(matrix.Get(1, 0), Is.EqualTo(1));
        Assert.That(matrix.Get(1, 1), Is.EqualTo(-2));
    }

    [Test]
    public void MatrixEquality()
    {
        var matrix = new AMatrix4(1, 2, 3, 4, 5.5f, 6.5f, 7.5f, 8.5f, 9, 10, 11, 12, 13.5f, 14.5f, 15.5f, 16.5f);
        var matrix2 = new AMatrix4(1, 2, 3, 4, 5.5f, 6.5f, 7.5f, 8.5f, 9, 10, 11, 12, 13.5f, 14.5f, 15.5f, 16.5f);
        Assert.True(matrix.Equals(matrix2));
    }
    
    [Test]
    public void MatrixInequality()
    {
        var matrix = new AMatrix4(1, 2, 3, 4, 5.5f, 6.5f, 6.5f, 8.5f, 9, 10, 11, 12, 13.5f, 14.5f, 15.5f, 16.5f);
        var matrix2 = new AMatrix4(1, 2, 3, 4, 5.5f, 6.5f, 7.5f, 8.5f, 9, 10, 11, 12, 13.5f, 14.5f, 15.5f, 16.5f);
        Assert.That(!matrix.Equals(matrix2));
    }
    
    [Test]
    public void MatrixMultiply()
    {
        var matrix = new AMatrix4(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
        var matrix2 = new AMatrix4(-2, 1, 2, 3, 3, 2, 1, -1, 4, 3, 6, 5, 1, 2, 7, 8);
        var expectedMatrix = new AMatrix4(20, 22, 50, 48, 44, 54, 114, 108, 40, 58, 110, 102, 16, 26, 46, 42);
        Assert.That(matrix.Multiply(matrix2).Equals(expectedMatrix));
    }

    [Test]
    public void MatrixMultiply2()
    {
        var matrix = new AMatrix4(1, 2, 3, 4, 2, 4, 4, 2, 8, 6, 4, 1, 0, 0, 0, 1);
        var tuple = new ATuple(1, 2, 3, 1);
        var expectedTuple = new ATuple(18, 24, 33, 1);
        Assert.That(matrix.Multiply(tuple).Equals(expectedTuple));
    }

    [Test]
    public void IdentityMatrix()
    {
        var matrix = new AMatrix4(0, 1, 2, 4, 1, 2, 4, 8, 2, 4, 8, 16, 4, 8, 16, 32);
        var iMatrix = AMatrix4.IdentityMatrix4();
        Assert.That(matrix.Multiply(iMatrix).Equals(matrix));
    }
}