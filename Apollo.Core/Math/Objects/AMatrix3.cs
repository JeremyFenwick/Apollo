﻿namespace Apollo.Math.Objects;

/// <summary> 
/// A 3x3 matrix of floating point numbers.
/// </summary>
public readonly struct AMatrix3
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

    public AMatrix3(float[,] matrix)
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
    public bool Equals(AMatrix3 other)
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
    /// Returns the sub matrix with the specified row and column removed.
    /// https://en.wikipedia.org/wiki/Matrix_(mathematics)
    /// </summary>
    public AMatrix2 SubMatrix(int removeRow, int removeCol)
    {
        var result = new float[2, 2];
        var rowAdded = 0;
        var colAdded = 0;
        for (int row = 0; row < 3; row++)
        {
            // Skip the removeRow
            if (row == removeRow) continue;
            for (int col = 0; col < 3; col++)
            {
                // Skip the removeCol
                if (col == removeCol) continue;
                result[rowAdded, colAdded] = _matrix[row, col];
                colAdded++;
            }
            colAdded = 0;
            rowAdded++;
        }
        return new AMatrix2(result);
    }
}