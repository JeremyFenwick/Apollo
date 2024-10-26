namespace Apollo.Math.Objects;

/// <summary> 
/// A 2x2 matrix of floating point numbers.
/// </summary>
public readonly struct AMatrix2
{
    private readonly float[,] _matrix;

    public AMatrix2(float m11, float m12, float m21, float m22)
    {
        _matrix = new float[2, 2];
        _matrix[0, 0] = m11;
        _matrix[0, 1] = m12;
        _matrix[1, 0] = m21;
        _matrix[1, 1] = m22;
    }

    public AMatrix2(float[,] matrix)
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
    public bool Equals(AMatrix2 other)
    {
        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            for (int j = 0; j < _matrix.GetLength(1); j++)
            {
                if (System.Math.Abs(_matrix[i, j] - other.Get(i, j)) > 0.00001)
                {
                    return false;
                }
            }
        }
        return true;
    }

    /// <summary> 
    /// Returns the determinant of this matrix.
    /// https://en.wikipedia.org/wiki/Determinant
    /// </summary>
    public float Determinant()
    {
        return (_matrix[0, 0] * _matrix[1, 1]) - (_matrix[0, 1] * _matrix[1, 0]);
    }
}