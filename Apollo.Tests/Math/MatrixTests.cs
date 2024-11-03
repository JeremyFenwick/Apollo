using Apollo.Math;

namespace Apollo.Tests.Math;

public class MatrixTests
{
    [Test]
    public void CreateMatrix4()
    {
        var matrix = new Matrix(1f, 2f, 3f, 4f, 5.5f, 6.5f, 7.5f, 8.5f, 9, 10, 11, 12, 13.5f, 14.5f, 15.5f, 16.5f);
        Assert.That(System.Math.Abs(matrix.Get(0, 0) - 1) < 0.00001);
        Assert.That(System.Math.Abs(matrix.Get(0, 3) - 4) < 0.00001);
        Assert.That(System.Math.Abs(matrix.Get(1, 0) - 5.5) < 0.00001);
        Assert.That(System.Math.Abs(matrix.Get(1, 2) - 7.5) < 0.00001);
        Assert.That(System.Math.Abs(matrix.Get(2, 2) - 11) < 0.00001);
        Assert.That(System.Math.Abs(matrix.Get(3, 0) - 13.5) < 0.00001);
        Assert.That(System.Math.Abs(matrix.Get(3, 2) - 15.5) < 0.00001);
    }

    [Test]
    public void CreateMatrix2()
    {
        var matrix = new Matrix(-3, 5, 1, -2);
        Assert.That(System.Math.Abs(matrix.Get(0, 0) - -3) < 0.00001);
        Assert.That(System.Math.Abs(matrix.Get(0, 1) - 5) < 0.00001);
        Assert.That(System.Math.Abs(matrix.Get(1, 0) - 1) < 0.00001);
        Assert.That(System.Math.Abs(matrix.Get(1, 1) - -2) < 0.00001);
    }

    [Test]
    public void CreateMatrix3()
    {
        var matrix = new Matrix(-3, 5, 0, 1, -2, -7, 0, 1, 1);
        Assert.That(System.Math.Abs(matrix.Get(0, 0) - -3) < 0.00001);
        Assert.That(System.Math.Abs(matrix.Get(1, 1) - -2) < 0.00001);
        Assert.That(System.Math.Abs(matrix.Get(2, 2) - 1) < 0.00001);
    }

    [Test]
    public void Equality()
    {
        var matrix1 = new Matrix(1f, 2f, 3f, 4f, 5.5f, 6.5f, 7.5f, 8.5f, 9, 10, 11, 12, 13.5f, 14.5f, 15.5f, 16.5f);
        var matrix2 = new Matrix(1f, 2f, 3f, 4f, 5.5f, 6.5f, 7.5f, 8.5f, 9, 10, 11, 12, 13.5f, 14.5f, 15.5f, 16.5f);
        Assert.That(matrix1 == matrix2);
    }

    [Test]
    public void Inequality()
    {
        var matrix1 = new Matrix(1f, 2f, 3f, 4f, 5.5f, 6.5f, 7.5f, 8.5f, 9, 10, 11, 12, 13.5f, 14.5f, 15.5f, 16.6f);
        var matrix2 = new Matrix(1f, 2f, 3f, 4f, 5.5f, 6.5f, 7.5f, 8.5f, 9, 10, 11, 12, 13.5f, 14.5f, 15.5f, 16.5f);
        Assert.That(matrix1 != matrix2);
    }

    [Test]
    public void DifferentDimensions()
    {
        var matrix1 = new Matrix(1f, 2f, 3f, 4f, 5.5f, 6.5f, 7.5f, 8.5f, 9, 10, 11, 12, 13.5f, 14.5f, 15.5f, 16.6f);
        var matrix2 = new Matrix(1f, 2f, 3f, 4f);
        Assert.That(matrix1 != matrix2);
    }

    [Test]
    public void MatMul()
    {
        var matrix1 = new Matrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
        var matrix2 = new Matrix(-2, 1, 2, 3, 3, 2, 1, -1, 4, 3, 6, 5, 1, 2, 7, 8);
        var mMatrix = matrix1 * matrix2;
        var expectedMatrix = new Matrix(20, 22, 50, 48, 44, 54, 114, 108, 40, 58, 110, 102, 16, 26, 46, 42);
        Assert.That(mMatrix == expectedMatrix);
    }

    [Test]
    public void TupleMultiplication()
    {
        var matrix = new Matrix(1, 2, 3, 4, 2, 4, 4, 2, 8, 6, 4, 1, 0, 0, 0, 1);
        var tuple = new ATuple(1, 2, 3, 1);
        Assert.That(matrix * tuple == new ATuple(18, 24, 33, 1));
    }

    [Test]
    public void Identity()
    {
        var matrix = new Matrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
        Assert.That(matrix * Matrix.Identity() == matrix);
    }

    [Test]
    public void Identity2()
    {
        var tuple = new ATuple(1, 2, 3, 4);
        Assert.That(Matrix.Identity() * tuple == tuple);
    }

    [Test]
    public void Transpose()
    {
        Assert.That(Matrix.Identity().Transpose() == Matrix.Identity());
    }

    [Test]
    public void SubMatrix1()
    {
        var matrix = new Matrix(1, 5, 0, -3, 2, 7, 0, 6, -3);
        Assert.That(matrix.SubMatrix(0, 2) == new Matrix(-3, 2, 0, 6));
    }
    
    [Test]
    public void SubMatrix2()
    {
        var matrix = new Matrix(-6, 1, 1, 6, -8, 5, 8, 6, -1, 0, 8, 2, -7, 1, -1, 1);
        Assert.That(matrix.SubMatrix(2, 1) == new Matrix(-6, 1, 6, -8, 8, 6, -7, -1, 1));
    }
    
    [Test]
    public void Minor()
    {
        var matrix = new Matrix(3, 5, 0, 2, -1, -7, 6, -1, 5);
        Assert.That(System.Math.Abs(matrix.Minor(1, 0) - 25) < 0.00001);
    }
    
    [Test]
    public void Cofactor()
    {
        var matrix = new Matrix(3, 5, 0, 2, -1, -7, 6, -1, 5);
        Assert.That(System.Math.Abs(matrix.Minor(0, 0) - (-12)) < 0.00001);
        Assert.That(System.Math.Abs(matrix.Cofactor(0, 0) - (-12)) < 0.00001);
        Assert.That(System.Math.Abs(matrix.Minor(1, 0) - (25)) < 0.00001);
        Assert.That(System.Math.Abs(matrix.Cofactor(1, 0) - (-25)) < 0.00001);
    }

    [Test]
    public void Determinant()
    {
        var matrix = new Matrix(1, 2, 6, -5, 8, -4, 2, 6, 4);
        Assert.That(System.Math.Abs(matrix.Determinant() - (-196)) < 0.00001);
    }
    
    [Test]
    public void Determinant2()
    {
        var matrix = new Matrix(-2, -8, 3, 5, -3, 1, 7, 3, 1, 2, -9, 6, -6, 7, 7, -9);
        Assert.That(System.Math.Abs(matrix.Determinant() - (-4071)) < 0.00001);
    }

    [Test]
    public void Invertible()
    {
        var matrix1 = new Matrix(6, 4, 4, 4, 5, 5, 7, 6, 4, -9, 3, -7, 9, 1, 7, -6);
        var det1 = matrix1.Determinant();
        Assert.True(matrix1.Invertable());
        var matrix2 = new Matrix(-4, 2, -2, -3, 9, 6, 2, 6, 0, -5, 1, -5, 0, 0, 0, 0);
        Assert.True(!matrix2.Invertable());
    }
    
        [Test]
    public void Inversion()
    {
        var matrix = new Matrix(-5, 2, 6, -8, 1, -5, 1, 8, 7, 7, -6, -7, 1, -3, 7, 4);
        var iMatrix = matrix.Inverse();
        Assert.That(System.Math.Abs(iMatrix.Get(0,0)) - 0.21805, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(1,1)) - 1.45677, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(2,2)) - 0.05263, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(3,3)) - 0.30639, Is.LessThan(0.00001));
    }

    [Test]
    public void Inversion2()
    {
        var matrix = new Matrix(8, -5, 9, 2, 7, 5, 6, 1, -6, 0, 9, 6, -3, 0, -9, -4);
        var iMatrix = matrix.Inverse();
        Assert.That(System.Math.Abs(iMatrix.Get(0,3)) - 0.53846, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(1,2)) - 0.02564, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(2,1)) - 0.35897, Is.LessThan(0.00001));
        Assert.That(System.Math.Abs(iMatrix.Get(3,0)) - 0.69231, Is.LessThan(0.00001));
    }

    [Test]
    public void Inversion3()
    {
        var matrix = new Matrix(9, 3, 0, 9, -5, -2, -6, -3, -4, 9, 6, 4, -7, 6, 6, 2);
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
        var matrixA = new Matrix(3, -9, 7, 3, 3, -8, 2, -9, -4, 4, 4, 1, -6, 5, -1, 1);
        var matrixB = new Matrix(8, 2, 2, 2, 3, -1, 7, 0, 7, 0, 5, 4, 6, -2, 0, 5);
        var matrixC = matrixA * matrixB;
        var recoveredMatrixA = matrixC * matrixB.Inverse();
        Assert.True(recoveredMatrixA == matrixA);
    }

    [Test]
    public void Translation()
    {
        var tMatrix = Matrix.Translation(5, -3, 2);
        Assert.That(tMatrix * new Point(-3, 4, 5) == new Point(2, 1, 7));
        Assert.That(new Point(-3, 4, 5).Translate(5, -3, 2) == new Point(2, 1, 7));
    }

    [Test]
    public void Translation2()
    {
        var tMatrix = Matrix.Translation(5, -3, 2);
        var iMatrix = tMatrix.Inverse();
        var point = new Point(-3, 4, 5);
        Assert.That(iMatrix * point == new Point(-8, 7, 3));
    }

    [Test]
    public void Translation3()
    {
        var vector = new Vector(-3, 4, 5);
        Assert.That(vector.Translate(5, -3, 2) == vector);
    }

    [Test]
    public void Scaling()
    {
        Assert.That(new Point(-4, 6, 8).Scale(2, 3, 4) == new Point(-8, 18, 32));
    }
    
    [Test]
    public void Scaling2()
    {
        Assert.That(new Vector(-4, 6, 8).Scale(2, 3, 4) == new Vector(-8, 18, 32));
    }

    [Test]
    public void Scaling3()
    {
        var vector = new Vector(-4, 6, 8);
        var matrix = Matrix.Scaling(2, 3, 4).Inverse();
        Assert.That(vector * matrix == new Vector(-2, 2, 2));
    }

    [Test]
    public void Scaling4()
    {
        Assert.That(new Point(2, 3, 4).Scale(-1, 1, 1) == new Point(-2, 3, 4));
    }

    [Test]
    public void XRotation()
    {
        var elem = (float) System.Math.Sqrt(2) / 2;
        Assert.That(new Point(0, 1, 0).XRotate(System.Math.PI / 4) == new Point(0, elem, elem));
        Assert.That(new Point(0, 1, 0).XRotate(System.Math.PI / 2) == new Point(0, 0, 1));
    }
    
    [Test]
    public void XRotation2()
    {
        var elem = (float) System.Math.Sqrt(2) / 2;
        var xMatrix = Matrix.XRotation(System.Math.PI / 4).Inverse();
        Assert.That(new Point(0, 1 ,0) * xMatrix == new Point(0, elem, -elem));
    }

    [Test]
    public void YRotation()
    {
        var elem = (float) System.Math.Sqrt(2) / 2;
        Assert.That(new Point(0, 0, 1).YRotate(System.Math.PI / 4) == new Point(elem, 0, elem));
        Assert.That(new Point(0, 0, 1).YRotate(System.Math.PI / 2) == new Point(1, 0, 0));
    }

    [Test]
    public void ZRotation()
    {
        var elem = (float) System.Math.Sqrt(2) / 2;
        Assert.That(new Point(0, 1, 0).ZRotate(System.Math.PI / 4) == new Point(-elem, elem, 0));
        Assert.That(new Point(0, 1, 0).ZRotate(System.Math.PI / 2) == new Point(-1, 0, 0));
    }

    [Test]
    public void Shearing()
    {
        Assert.That(new Point(2, 3, 4).Shear(1, 0, 0, 0, 0 ,0) == new Point(5, 3, 4));
    }
    
    [Test]
    public void Shearing2()
    {
        Assert.That(new Point(2, 3, 4).Shear(0, 1, 0, 0, 0 ,0) == new Point(6, 3, 4));
    }
    
    [Test]
    public void Shearing3()
    {
        Assert.That(new Point(2, 3, 4).Shear(0, 0, 1, 0, 0 ,0) == new Point(2, 5, 4));
    }
    
    [Test]
    public void Shearing4()
    {
        Assert.That(new Point(2, 3, 4).Shear(0, 0, 0, 1, 0 ,0) == new Point(2, 7, 4));
    }
    
    [Test]
    public void Shearing5()
    {
        Assert.That(new Point(2, 3, 4).Shear(0, 0, 0, 0, 1 ,0) == new Point(2, 3, 6));
    }
    
    [Test]
    public void Shearing6()
    {
        Assert.That(new Point(2, 3, 4).Shear(0, 0, 0, 0, 0 ,1) == new Point(2, 3, 7));
    }

    [Test]
    public void Chaining()
    {
        Assert.That(new Point(1, 0, 1).XRotate(System.Math.PI / 2).Scale(5, 5, 5).Translate(10, 5, 7) == new Point(15, 0, 7));
    }
}