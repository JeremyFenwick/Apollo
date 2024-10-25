using Apollo.Math.Interfaces;

namespace Apollo.Math.Objects;

/// <summary> 
/// A 3x3 matrix of floating point numbers.
/// </summary>
public readonly struct AMatrix3 : Matrix
{
    private readonly float[,] _matrix;

    public AMatrix3(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
    {
        _matrix = new float[3, 3];
        _matrix[0, 0] = m11;
        _matrix[0, 1] = m12;
        _matrix[0, 2] = m13;
        _matrix[1, 0] = m21;
        _matrix[1, 1] = m22;
        _matrix[1, 2] = m23;
        _matrix[2, 0] = m31;
        _matrix[2, 1] = m32;
        _matrix[2, 2] = m33;
    }
    
    /// <summary> 
    /// Get the value within the matrix at ROW, COLUMN.
    /// </summary>
    public float Get(int row, int col)
    {
        return _matrix[row, col];
    }
}