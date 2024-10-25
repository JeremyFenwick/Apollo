using Apollo.Math.Interfaces;

namespace Apollo.Math.Objects;

/// <summary> 
/// A 4x4 matrix of floating point numbers.
/// </summary>
public readonly struct AMatrix4 : Matrix
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

    /// <summary> 
    /// Get the value within the matrix at ROW, COLUMN.
    /// </summary>
    public float Get(int row, int col)
    {
        return _matrix[row, col];
    }
}