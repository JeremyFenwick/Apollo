using Apollo.Math.Objects;

namespace Apollo.Tests.Math;

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

    [Test]
    public void TransposeMatrix()
    {
        var matrix = new AMatrix4(0, 9, 3, 0, 9, 8, 0, 8, 1, 8, 5, 3, 0, 0, 5, 8);
        var tMatrix = new AMatrix4(0, 9, 1, 0, 9, 8, 8, 0, 3, 0, 5, 5, 0, 8, 3, 8);
        Assert.That(matrix.Transpose().Equals(tMatrix));
    }

    [Test]
    public void Determinant()
    {
        var matrix = new AMatrix2(1, 5, -3, 2);
        Assert.That(matrix.Determinant(), Is.EqualTo(17));
    }

    [Test]
    public void SubMatrix()
    {
        var matrix = new AMatrix3(1, 5, 0, -3, 2, 7, 0, 6, -3);
        var subMatrix = matrix.SubMatrix(0, 2);
        var expectedSubMatrix = new AMatrix2(-3, 2, 0, 6);
        Assert.That(subMatrix.Equals(expectedSubMatrix));
    }

    [Test]
    public void SubMatrix2()
    {
        var matrix = new AMatrix4(-6, 1, 1, 6, -8, 5, 8, 6, -1, 0, 8, 2, -7, 1, -1, 1);
        var subMatrix = matrix.SubMatrix(2, 1);
        var expectedSubMatrix = new AMatrix3(-6, 1, 6, -8, 8, 6, -7, -1, 1);
        Assert.That(subMatrix.Equals(expectedSubMatrix));
    }

    [Test]
    public void Minor()
    {
        var matrix = new AMatrix3(3, 5, 0, 2, -1, -7, 6, -1, 5);
        Assert.That(matrix.Minor(1, 0), Is.EqualTo(25));
    }

    [Test]
    public void Cofactor()
    {
        var matrix = new AMatrix3(3, 5, 0, 2, -1, -7, 6, -1, 5);
        var cofactor1 = matrix.Cofactor(0, 0);
        Assert.That(cofactor1, Is.EqualTo(-12));
        var cofactor2 = matrix.Cofactor(1, 0);
        Assert.That(cofactor2, Is.EqualTo(-25));
    }

    [Test]
    public void Determinant2()
    {
        var matrix = new AMatrix3(1, 2, 6, -5, 8, -4, 2, 6, 4);
        Assert.That(matrix.Determinant(), Is.EqualTo(-196));
    }

    [Test]
    public void Determinant3()
    {
        var matrix = new AMatrix4(-2, -8, 3, 5, -3, 1, 7, 3, 1, 2, -9, 6, -6, 7, 7, -9);
        var det = matrix.Determinant();
        Assert.That(det, Is.EqualTo(-4071));
    }

    [Test]
    public void Invertible()
    {
        var matrix1 = new AMatrix4(6, 4, 4, 4, 5, 5, 7, 6, 4, -9, 3, -7, 9, 1, 7, -6);
        var det1 = matrix1.Determinant();
        Assert.True(matrix1.Invertable());
        var matrix2 = new AMatrix4(-4, 2, -2, -3, 9, 6, 2, 6, 0, -5, 1, -5, 0, 0, 0, 0);
        var det2 = matrix2.Determinant();
        Assert.True(!matrix2.Invertable());
    }

    [Test]
    public void Inversion()
    {
        var matrix = new AMatrix4(-5, 2, 6, -8, 1, -5, 1, 8, 7, 7, -6, -7, 1, -3, 7, 4);
        var iMatrix = matrix.Inverse();
        Assert.That(System.Math.Abs(iMatrix.Get(0,0)) - 0.21805, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(1,1)) - 1.45677, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(2,2)) - 0.05263, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(3,3)) - 0.30639, Is.LessThan(0.00001));
    }

    [Test]
    public void Inversion2()
    {
        var matrix = new AMatrix4(8, -5, 9, 2, 7, 5, 6, 1, -6, 0, 9, 6, -3, 0, -9, -4);
        var iMatrix = matrix.Inverse();
        Assert.That(System.Math.Abs(iMatrix.Get(0,3)) - 0.53846, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(1,2)) - 0.02564, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(2,1)) - 0.35897, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(3,0)) - 0.69231, Is.LessThan(0.00001));
    }

    [Test]
    public void Inversion3()
    {
        var matrix = new AMatrix4(9, 3, 0, 9, -5, -2, -6, -3, -4, 9, 6, 4, -7, 6, 6, 2);
        var iMatrix = matrix.Inverse();
        Assert.That(System.Math.Abs(iMatrix.Get(1,0)) - 0.07778, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(1,1)) - 0.03333, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(1,2)) - 0.36667, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(1,3)) - 0.33333, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(2,0)) - 0.02901, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(2,1)) - 0.14630, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(2,2)) - 0.10926, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(2,3)) - 0.12963, Is.LessThan(0.00001));
    }

    [Test]
    public void Inversion4()
    {
        var matrixA = new AMatrix4(3, -9, 7, 3, 3, -8, 2, -9, -4, 4, 4, 1, -6, 5, -1, 1);
        var matrixB = new AMatrix4(8, 2, 2, 2, 3, -1, 7, 0, 7, 0, 5, 4, 6, -2, 0, 5);
        var matrixC = matrixA.Multiply(matrixB);
        var recoveredMatrixA = matrixC.Multiply(matrixB.Inverse());
        Assert.True(recoveredMatrixA.Equals(matrixA));
    }
}