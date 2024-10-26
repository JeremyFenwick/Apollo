namespace Apollo.Math.Objects;

/// <summary> 
/// A 4x4 matrix of floating point numbers.
/// </summary>
public readonly struct AMatrix4
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
}