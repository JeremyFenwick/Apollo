namespace Apollo.Math.Objects;

/// <summary> 
/// A 4x4 matrix of floating point numbers.
/// </summary>
public class AMatrix4
{
    private readonly float[,] _matrix;

    public AMatrix4(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31,
        float m32, float m33, float m34, float m41, float m42, float m43, float m44)
    {
        _matrix = new float[4, 4];
        _matrix[0, 0] = m11;
        _matrix[0, 1] = m12;
        _matrix[0, 2] = m13;
        _matrix[0, 3] = m14;
        _matrix[1, 0] = m21;
        _matrix[1, 1] = m22;
        _matrix[1, 2] = m23;
        _matrix[1, 3] = m24;
        _matrix[2, 0] = m31;
        _matrix[2, 1] = m32;
        _matrix[2, 2] = m33;
        _matrix[2, 3] = m34;
        _matrix[3, 0] = m41;
        _matrix[3, 1] = m42;
        _matrix[3, 2] = m43;
        _matrix[3, 3] = m44;
    }

    private AMatrix4(float[,] matrix)
    {
        _matrix = matrix;
    }

    /// <summary> 
    /// Get the value within the matrix at ROW, COLUMN.
    /// </summary>
    public float Get(int row, int col)
    {
        return _matrix[row, col];
    }
    
    /// <summary> 
    /// Compares two matrices for equality by the contained values.
    /// </summary>
    public bool Equals(AMatrix4 other)
    {
        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            for (int j = 0; j < _matrix.GetLength(1); j++)
            {
                if (System.Math.Abs(_matrix[i, j] - other._matrix[i, j]) > 0.00001)
                {
                    return false;
                }
            }
        }
        return true;
    }

    /// <summary> 
    /// Multiples this matrix by another and returns the resulting matrix.
    /// https://en.wikipedia.org/wiki/Matrix_multiplication
    /// Note this is just a simple algorithm implementation and is not optimized.
    /// </summary>
    public AMatrix4 Multiply(AMatrix4 other)
    {
        var result = new float[4, 4];
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                result[row, col] = (_matrix[row, 0] * other._matrix[0, col]) +
                                   (_matrix[row, 1] * other._matrix[1, col]) +
                                   (_matrix[row, 2] * other._matrix[2, col]) +
                                   (_matrix[row, 3] * other._matrix[3, col]);
            }
        }
        return new AMatrix4(result);
    }

    /// <summary> 
    /// Multiples this matrix by a tuple and returns the result.
    /// https://en.wikipedia.org/wiki/Matrix_multiplication
    /// Note this is just a simple algorithm implementation and is not optimized.
    /// </summary>
    public ATuple Multiply(ATuple other)
    {
        var x = (_matrix[0, 0] * other.X) + (_matrix[0, 1] * other.Y) + (_matrix[0, 2] * other.Z) + (_matrix[0, 3] * other.W);
        var y = (_matrix[1, 0] * other.X) + (_matrix[1, 1] * other.Y) + (_matrix[1, 2] * other.Z) + (_matrix[1, 3] * other.W);
        var z = (_matrix[2, 0] * other.X) + (_matrix[2, 1] * other.Y) + (_matrix[2, 2] * other.Z) + (_matrix[2, 3] * other.W);
        var w = (_matrix[3, 0] * other.X) + (_matrix[3, 1] * other.Y) + (_matrix[3, 2] * other.Z) + (_matrix[3, 3] * other.W);
        return new ATuple(x, y, z, w);
    }
    
    /// <summary> 
    /// Returns the 4X4 identity matrix.
    /// https://en.wikipedia.org/wiki/Identity_matrix
    /// </summary>
    public static AMatrix4 IdentityMatrix4()
    {
        var result = new float[4, 4];
        result[0, 0] = 1;
        result[1, 1] = 1;
        result[2, 2] = 1;
        result[3, 3] = 1;
        return new AMatrix4(result);
    }

    /// <summary> 
    /// Returns the transpose of this matrix.
    /// https://en.wikipedia.org/wiki/Transpose
    /// </summary>
    public AMatrix4 Transpose()
    {
        var result = new float[4, 4];
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                result[col, row] = _matrix[row, col];
            }
        }
        return new AMatrix4(result);
    }


    /// <summary> 
    /// Returns the sub matrix with the specified row and column removed.
    /// https://en.wikipedia.org/wiki/Matrix_(mathematics)
    /// </summary>
    public AMatrix3 SubMatrix(int removeRow, int removeCol)
    {
        var result = new float[3, 3];
        var rowAdded = 0;
        var colAdded = 0;
        for (int row = 0; row < 4; row++)
        {
            // Skip the removeRow
            if (row == removeRow) continue;
            for (int col = 0; col < 4; col++)
            {
                // Skip the removeCol
                if (col == removeCol) continue;
                result[rowAdded, colAdded] = _matrix[row, col];
                colAdded++;
            }

            colAdded = 0;
            rowAdded++;
        }

        return new AMatrix3(result);
    }
    
    /// <summary> 
    /// Returns the determinant of this matrix.
    /// https://en.wikipedia.org/wiki/Determinant
    /// </summary>
    public float Determinant()
    {
        return (this.SubMatrix(0, 0).Determinant() * _matrix[0, 0]) +
               (-this.SubMatrix(0, 1).Determinant() * _matrix[0, 1]) +
               (this.SubMatrix(0, 2).Determinant() * _matrix[0, 2]) +
               (-this.SubMatrix(0, 3).Determinant() * _matrix[0, 3]);
    }

    /// <summary> 
    /// Returns whether the matrix is invertible (whether the determinant is zero).
    /// </summary>
    public bool Invertable()
    {
        return Determinant() != 0;
    }

    /// <summary> 
    /// Returns the inverse of this matrix.
    /// https://en.wikipedia.org/wiki/Multiplicative_inverse
    /// </summary>
    public AMatrix4 Inverse()
    {
        var det = Determinant();
        if (det == 0)
        {
            throw new Exception("Attempting to invert a non-invertible Matrix!");
        }
        var result = new float[4, 4];
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                // We need to apply the appropriate sign to the determinant
                var minor = this.SubMatrix(row, col).Determinant();
                if ((row + col) % 2 != 0)
                {
                    result[col, row] = -minor / det;
                }
                else
                {
                    result[col, row] = minor / det;
                }
            }
        }
        return new AMatrix4(result);
    }

    /// <summary> 
    /// Returns a translation matrix given the floating point numbers x, y and z.
    /// A translation matrix moves a point but does not affect vectors.
    /// https://en.wikipedia.org/wiki/Translation_(geometry)
    /// </summary>
    public static AMatrix4 TranslationMatrix4(float x, float y, float z)
    {
        var result = new float[4, 4];
        result[0, 0] = 1;
        result[0, 3] = x;
        result[1, 1] = 1;
        result[1, 3] = y;
        result[2, 2] = 1;
        result[2, 3] = z;
        result[3, 3] = 1;
        return new AMatrix4(result);
    }
    
    /// <summary> 
    /// Returns a scaling matrix given the floating point numbers x, y and z.
    /// Scales X by x, Y by y and Z by z.
    /// https://en.wikipedia.org/wiki/Scaling_(geometry)
    /// </summary>
    public static AMatrix4 ScalingMatrix4(float x, float y, float z)
    {
        var result = new float[4, 4];
        result[0, 0] = x;
        result[1, 1] = y;
        result[2, 2] = z;
        result[3, 3] = 1;
        return new AMatrix4(result);
    }

    /// <summary> 
    /// Returns a rotation matrix that will rotate the X axis.
    /// https://en.wikipedia.org/wiki/Rotation_matrix
    /// </summary>
    public static AMatrix4 XRotationMatrix4(double degrees)
    {
        var result = new float[4, 4];
        result[0, 0] = 1;
        result[3, 3] = 1;
        result[1, 1] = (float) System.Math.Cos(degrees);
        result[1, 2] = (float) -System.Math.Sin(degrees);
        result[2, 1] = (float) System.Math.Sin(degrees);
        result[2, 2] = (float) System.Math.Cos(degrees);
        return new AMatrix4(result);
    }
    
    /// <summary> 
    /// Returns a rotation matrix that will rotate the Y axis.
    /// https://en.wikipedia.org/wiki/Rotation_matrix
    /// </summary>
    public static AMatrix4 YRotationMatrix4(double degrees)
    {
        var result = new float[4, 4];
        result[1, 1] = 1;
        result[3, 3] = 1;
        result[0, 0] = (float) System.Math.Cos(degrees);
        result[0, 2] = (float) System.Math.Sin(degrees);
        result[2, 0] = (float) -System.Math.Sin(degrees);
        result[2, 2] = (float) System.Math.Cos(degrees);
        return new AMatrix4(result);
    }
    
    /// <summary> 
    /// Returns a rotation matrix that will rotate the Z axis.
    /// https://en.wikipedia.org/wiki/Rotation_matrix
    /// </summary>
    public static AMatrix4 ZRotationMatrix4(double degrees)
    {
        var result = new float[4, 4];
        result[1, 1] = 1;
        result[3, 3] = 1;
        result[0, 0] = (float) System.Math.Cos(degrees);
        result[0, 1] = (float) -System.Math.Sin(degrees);
        result[1, 0] = (float) System.Math.Sin(degrees);
        result[1, 1] = (float) System.Math.Cos(degrees);
        return new AMatrix4(result);
    }
    
    /// <summary> 
    /// Returns a matrix that will shear (skew).
    /// https://en.wikipedia.org/wiki/Transformation_matrix
    /// </summary>
    /// <remarks>The input xy refers to x being moved in proportion to y.</remarks>
    public static AMatrix4 ShearMatrix4(float xy, float xz, float yx, float yz, float zx, float zy)
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
        return new AMatrix4(result);
    }

    /// <summary> 
    /// Translates this matrix.
    /// </summary>
    public AMatrix4 Translate(float x, float y, float z)
    {
        var tempMatrix = TranslationMatrix4(x, y, z);
        return this.Multiply(tempMatrix);
    }

    /// <summary> 
    /// Scales this matrix.
    /// </summary>
    public AMatrix4 Scale(float x, float y, float z)
    {
        var tempMatrix = ScalingMatrix4(x, y, z);
        return this.Multiply(tempMatrix);
    }
    
    /// <summary> 
    /// Rotates this matrix across the X axis.
    /// </summary>
    public AMatrix4 XRotate(double radians)
    {
        var tempMatrix = XRotationMatrix4(radians);
        return this.Multiply(tempMatrix);
    }
    
    /// <summary> 
    /// Rotates this matrix across the Y axis.
    /// </summary>
    public AMatrix4 YRotate(double radians)
    {
        var tempMatrix = YRotationMatrix4(radians);
        return this.Multiply(tempMatrix);
    }
    
    /// <summary> 
    /// Rotates this matrix across the Z axis.
    /// </summary>
    public AMatrix4 ZRotate(double radians)
    {
        var tempMatrix = ZRotationMatrix4(radians);
        return this.Multiply(tempMatrix);
    }

    /// <summary> 
    /// Shears this matrix.
    /// </summary>
    public AMatrix4 Shear(float xy, float xz, float yx, float yz, float zx, float zy)
    {
        var tempMatrix = ShearMatrix4(xy, xz, yx, yz, zx, yz);
        return this.Multiply(tempMatrix);
    }
}