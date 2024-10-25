using Apollo.Math.Interfaces;

namespace Apollo.Math.Objects;

/// <summary> 
/// A 2x2 matrix of floating point numbers.
/// </summary>
public readonly struct AMatrix2 : Matrix
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
    
    /// <summary> 
    /// Get the value within the matrix at ROW, COLUMN.
    /// </summary>
    public float Get(int row, int col)
    {
        return _matrix[row, col];
    }
}