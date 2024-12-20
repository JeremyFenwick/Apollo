﻿using System.Text.Json.Serialization;
using Apollo.Math.AbstractClasses;

namespace Apollo.Math;

public class Matrix
{
    private readonly double[,] _data;
    public int Size { get; }
    private const double Epsilon = 0.00001;

    public Matrix(double m11, double m12, double m13, double m14, double m21, double m22, double m23, double m24, double m31,
        double m32, double m33, double m34, double m41, double m42, double m43, double m44)
    {
        _data = new double[4, 4];
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
    
    public Matrix(double m11, double m12, double m13, double m21, double m22, double m23, double m31, double m32, double m33)
    {
        _data = new double[3, 3];
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
    
    public Matrix(double m11, double m12, double m21, double m22)
    {
        _data = new double[2, 2];
        _data[0, 0] = m11;
        _data[0, 1] = m12;
        _data[1, 0] = m21;
        _data[1, 1] = m22;
        Size = _data.GetLength(0);
    }
    
    public Matrix(double[,] matrix)
    {
        _data = matrix;
        Size = _data.GetLength(0);
    }
    
    public double Get(int row, int column)
    {
        return _data[row, column];
    }
    
    public override bool Equals(Object? obj)
    {
        if (obj is not Matrix matrix)
        {
            return false;
        }
        return this == matrix;
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
        var result = new double[4, 4];
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
        var result = new double[4, 4];
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
        var result = new double[Size, Size];
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
        var result = new double[Size - 1, Size - 1];
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
    public double Minor(int row, int col)
    {
        var subMatrix = this.SubMatrix(row, col);
        return subMatrix.Determinant();
    }
    
    /// <summary> 
    /// Returns the cofactor (signed minor) of a matrix given a row and column to remove.
    /// https://en.wikipedia.org/wiki/Minor_(linear_algebra)
    /// </summary>
    public double Cofactor(int row, int col)
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
    public double Determinant()
    {
        double det = 0;
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
        var result = new double[Size, Size];
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

    public static Matrix Translation(double x, double y, double z)
    {
        var result = new double[4, 4];
        result[0, 0] = 1;
        result[1, 1] = 1;
        result[2, 2] = 1;
        result[3, 3] = 1;
        result[0, 3] = x;
        result[1, 3] = y;
        result[2, 3] = z;
        return new Matrix(result);
    }
    
    public static Matrix Scaling(double x, double y, double z)
    {
        var result = new double[4, 4];
        result[0, 0] = x;
        result[1, 1] = y;
        result[2, 2] = z;
        result[3, 3] = 1;
        return new Matrix(result);
    }

    public static Matrix XRotation(double radians)
    {
        var result = new double[4, 4];
        result[0, 0] = 1;
        result[1, 1] = (double) System.Math.Cos(radians);
        result[1, 2] = (double) - System.Math.Sin(radians);
        result[2, 1] = (double) System.Math.Sin(radians);
        result[2, 2] = (double) System.Math.Cos(radians);
        result[3, 3] = 1;
        return new Matrix(result);
    }
    
    public static Matrix YRotation(double radians)
    {
        var result = new double[4, 4];
        result[0, 0] = (double) System.Math.Cos(radians);;
        result[0, 2] = (double) System.Math.Sin(radians);
        result[1, 1] = 1;
        result[2, 0] = (double) - System.Math.Sin(radians);
        result[2, 2] = (double) System.Math.Cos(radians);
        result[3, 3] = 1;
        return new Matrix(result);
    }

    public static Matrix ZRotation(double radians)
    {
        var result = new double[4, 4];
        result[0, 0] = (double) System.Math.Cos(radians);
        result[0, 1] = (double) - System.Math.Sin(radians);
        result[1, 0] = (double) System.Math.Sin(radians);
        result[1, 1] = (double) System.Math.Cos(radians);
        result[2, 2] = 1;
        result[3, 3] = 1;
        return new Matrix(result);
    }

    public static Matrix Shear(double xy, double xz, double yx, double yz, double zx, double zy)
    {
        var result = new double[4, 4];
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

    public static Matrix ViewTransform(AbstractTuple from, AbstractTuple to, AbstractTuple up)
    {
        var result = new double[4, 4];
        var forward = (to - from).Normalize();
        var upN = up.Normalize();
        var left = forward.Cross(upN);
        var trueUp = left.Cross(forward);

        result[0, 0] = left.X;
        result[0, 1] = left.Y;
        result[0, 2] = left.Z;
        result[1, 0] = trueUp.X;
        result[1, 1] = trueUp.Y;
        result[1, 2] = trueUp.Z;
        result[2, 0] = -forward.X;
        result[2, 1] = -forward.Y;
        result[2, 2] = -forward.Z;
        result[3, 3] = 1;
        
        var temp = new Matrix(result);
        return temp * Translation(-from.X, -from.Y, -from.Z);
    }
}