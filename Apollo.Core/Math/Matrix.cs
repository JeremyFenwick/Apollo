using System.Text.Json.Serialization;

namespace Apollo.Math;

public class Matrix
{
    private readonly float[,] _data;
    public int Size { get; }
    private const float Epsilon = 0.00001f;

    public Matrix(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31,
        float m32, float m33, float m34, float m41, float m42, float m43, float m44)
    {
        _data = new float[4, 4];
        _data[0, 0] = m11;
        _data[0, 1] = m12;
        _data[0, 2] = m13;
        _data[0, 3] = m14;
        _data[1, 0] = m21;
        _data[1, 1] = m22;
        _data[1, 2] = m23;
        _data[1, 3] = m24;
        _data[2, 0] = m31;
        _data[2, 1] = m32;
        _data[2, 2] = m33;
        _data[2, 3] = m34;
        _data[3, 0] = m41;
        _data[3, 1] = m42;
        _data[3, 2] = m43;
        _data[3, 3] = m44;
        Size = _data.GetLength(0);
    }
    
    public Matrix(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
    {
        _data = new float[3, 3];
        _data[0, 0] = m11;
        _data[0, 1] = m12;
        _data[0, 2] = m13;
        _data[1, 0] = m21;
        _data[1, 1] = m22;
        _data[1, 2] = m23;
        _data[2, 0] = m31;
        _data[2, 1] = m32;
        _data[2, 2] = m33;
        Size = _data.GetLength(0);
    }
    
    public Matrix(float m11, float m12, float m21, float m22)
    {
        _data = new float[2, 2];
        _data[0, 0] = m11;
        _data[0, 1] = m12;
        _data[1, 0] = m21;
        _data[1, 1] = m22;
        Size = _data.GetLength(0);
    }
    
    public Matrix(float[,] matrix)
    {
        _data = matrix;
        Size = _data.GetLength(0);
    }
    
    public float Get(int row, int column)
    {
        return _data[row, column];
    }

    public static bool operator ==(Matrix a, Matrix b)
    {
        if (a.Size != b.Size)
        {
            return false;
        }

        for (int row = 0; row < a.Size; row++)
        {
            for (int col = 0; col < a.Size; col++)
            {
                if (System.Math.Abs(a._data[row, col] - b._data[row, col]) > Epsilon) return false;
            }
        }
        return true;
    }
    
    public static bool operator !=(Matrix a, Matrix b)
    {
        if (a.Size != b.Size)
        {
            return true;
        }

        for (int row = 0; row < a.Size; row++)
        {
            for (int col = 0; col < a.Size; col++)
            {
                if (System.Math.Abs(a._data[row, col] - b._data[row, col]) > Epsilon) return true;
            }
        }
        return false;
    }
    
    public static Matrix operator *(Matrix m1, Matrix m2)
    {
        if (m1.Size != 4 || m2.Size != 4)
        {
            throw new Exception("Matrix multiplication only implemented for 4x4 matrices!");
        }
        var result = new float[4, 4];
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                result[row, col] = (m1._data[row, 0] * m2._data[0, col]) +
                                   (m1._data[row, 1] * m2._data[1, col]) +
                                   (m1._data[row, 2] * m2._data[2, col]) +
                                   (m1._data[row, 3] * m2._data[3, col]);
            }
        }
        return new Matrix(result);
    }
    
    public static AbstractTuple operator *(Matrix m, AbstractTuple t)
    {
        if (m.Size != 4 )
        {
            throw new Exception("Matrix multiplication only implemented for 4x4 matrices!");
        }
        var x = (t.X * m._data[0, 0]) + (t.Y * m._data[0, 1]) + (t.Z * m._data[0, 2]) + (t.W * m._data[0, 3]);
        var y = (t.X * m._data[1, 0]) + (t.Y * m._data[1, 1]) + (t.Z * m._data[1, 2]) + (t.W * m._data[1, 3]);
        var z = (t.X * m._data[2, 0]) + (t.Y * m._data[2, 1]) + (t.Z * m._data[2, 2]) + (t.W * m._data[2, 3]);
        var w = (t.X * m._data[3, 0]) + (t.Y * m._data[3, 1]) + (t.Z * m._data[3, 2]) + (t.W * m._data[3, 3]);
        return new ATuple(x, y, z, w);
    }
    
    public static AbstractTuple operator *(AbstractTuple t, Matrix m)
    {
        if (m.Size != 4 )
        {
            throw new Exception("Matrix multiplication only implemented for 4x4 matrices!");
        }
        var x = (t.X * m._data[0, 0]) + (t.Y * m._data[0, 1]) + (t.Z * m._data[0, 2]) + (t.W * m._data[0, 3]);
        var y = (t.X * m._data[1, 0]) + (t.Y * m._data[1, 1]) + (t.Z * m._data[1, 2]) + (t.W * m._data[1, 3]);
        var z = (t.X * m._data[2, 0]) + (t.Y * m._data[2, 1]) + (t.Z * m._data[2, 2]) + (t.W * m._data[2, 3]);
        var w = (t.X * m._data[3, 0]) + (t.Y * m._data[3, 1]) + (t.Z * m._data[3, 2]) + (t.W * m._data[3, 3]);
        return new ATuple(x, y, z, w);
    }
    
    /// <summary> 
    /// Returns the 4X4 identity matrix.
    /// https://en.wikipedia.org/wiki/Identity_matrix
    /// </summary>
    public static Matrix Identity()
    {
        var result = new float[4, 4];
        result[0, 0] = 1;
        result[1, 1] = 1;
        result[2, 2] = 1;
        result[3, 3] = 1;
        return new Matrix(result);
    }
    
    /// <summary> 
    /// Returns the transpose of this matrix.
    /// https://en.wikipedia.org/wiki/Transpose
    /// </summary>
    public Matrix Transpose()
    {
        var result = new float[Size, Size];
        for (int row = 0; row < Size; row++)
        {
            for (int col = 0; col < Size; col++)
            {
                result[col, row] = _data[row, col];
            }
        }
        return new Matrix(result);
    }
    
    /// <summary> 
    /// Returns the sub matrix with the specified row and column removed.
    /// https://en.wikipedia.org/wiki/Matrix_(mathematics)
    /// </summary>
    public Matrix SubMatrix( int removeRow, int removeCol)
    {
        var result = new float[Size - 1, Size - 1];
        var rowAdded = 0;
        var colAdded = 0;
        for (int row = 0; row < Size; row++)
        {
            // Skip the removeRow
            if (row == removeRow) continue;
            for (int col = 0; col < Size; col++)
            {
                // Skip the removeCol
                if (col == removeCol) continue;
                result[rowAdded, colAdded] = _data[row, col];
                colAdded++;
            }

            colAdded = 0;
            rowAdded++;
        }
        return new Matrix(result);
    }
    
    /// <summary> 
    /// Returns minor of a matrix. The minor is the determinant of a smaller sub matrix given a row and column to remove.
    /// https://en.wikipedia.org/wiki/Minor_(linear_algebra)
    /// </summary>
    public float Minor(int row, int col)
    {
        var subMatrix = this.SubMatrix(row, col);
        return subMatrix.Determinant();
    }
    
    /// <summary> 
    /// Returns the cofactor (signed minor) of a matrix given a row and column to remove.
    /// https://en.wikipedia.org/wiki/Minor_(linear_algebra)
    /// </summary>
    public float Cofactor(int row, int col)
    {
        var subMatrix = this.SubMatrix(row, col);
        var determinant = subMatrix.Determinant();
        // If row + col is odd, we reverse the sign of the minor.
        if ((row + col) % 2 != 0)
        {
            return -determinant;
        }
        else
        {
            return determinant;
        }
    }

    /// <summary> 
    /// Returns the determinant of a matrix.
    /// https://en.wikipedia.org/wiki/Determinant
    /// </summary>
    public float Determinant()
    {
        var det = 0f;
        if (Size == 2)
        {
            det = (_data[0, 0] * _data[1, 1]) - (_data[0, 1] * _data[1, 0]);
        }
        else
        {
            for (int col = 0; col < Size; col++)
            {
                det += _data[0, col] * Cofactor(0, col);
            }
        }

        return det;
    }

    public Matrix Inverse()
    {
        var det = this.Determinant();
        var result = new float[Size, Size];
        if (det == 0)
        {
            throw new Exception("Attempting to invert a non-invertible matrix!");
        }

        for (int row = 0; row < Size; row++)
        {
            for (int col = 0; col < Size; col++)
            {
                var cofactor = Cofactor(row, col);
                result[col, row] = cofactor / det;
            }
        }
        return new Matrix(result);
    }

    public bool Invertable()
    {
        return this.Determinant() != 0;
    }

    public static Matrix Translation(float x, float y, float z)
    {
        var result = new float[4, 4];
        result[0, 0] = 1;
        result[1, 1] = 1;
        result[2, 2] = 1;
        result[3, 3] = 1;
        result[0, 3] = x;
        result[1, 3] = y;
        result[2, 3] = z;
        return new Matrix(result);
    }
    
    public static Matrix Scaling(float x, float y, float z)
    {
        var result = new float[4, 4];
        result[0, 0] = x;
        result[1, 1] = y;
        result[2, 2] = z;
        result[3, 3] = 1;
        return new Matrix(result);
    }

    public static Matrix XRotation(double radians)
    {
        var result = new float[4, 4];
        result[0, 0] = 1;
        result[1, 1] = (float) System.Math.Cos(radians);
        result[1, 2] = (float) - System.Math.Sin(radians);
        result[2, 1] = (float) System.Math.Sin(radians);
        result[2, 2] = (float) System.Math.Cos(radians);
        result[3, 3] = 1;
        return new Matrix(result);
    }
    
    public static Matrix YRotation(double radians)
    {
        var result = new float[4, 4];
        result[0, 0] = (float) System.Math.Cos(radians);;
        result[0, 2] = (float) System.Math.Sin(radians);
        result[1, 1] = 1;
        result[2, 0] = (float) - System.Math.Sin(radians);
        result[2, 2] = (float) System.Math.Cos(radians);
        result[3, 3] = 1;
        return new Matrix(result);
    }

    public static Matrix ZRotation(double radians)
    {
        var result = new float[4, 4];
        result[0, 0] = (float) System.Math.Cos(radians);
        result[0, 1] = (float) - System.Math.Sin(radians);
        result[1, 0] = (float) System.Math.Sin(radians);
        result[1, 1] = (float) System.Math.Cos(radians);
        result[2, 2] = 1;
        result[3, 3] = 1;
        return new Matrix(result);
    }

    public static Matrix Shear(float xy, float xz, float yx, float yz, float zx, float zy)
    {
        var result = new float[4, 4];
        result[0, 0] = 1;
        result[0, 1] = xy;
        result[0, 2] = xz;
        result[1, 0] = yx;
        result[1, 1] = 1;
        result[1, 2] = yz;
        result[2, 0] = zx;
        result[2, 1] = zy;
        result[2, 2] = 1;
        result[3, 3] = 1;
        return new Matrix(result);
    }
}