using System.Text;

namespace Apollo.Display.Objects;

/// <summary> 
/// Creates a canvas, which contains the pixels used for image generation and manipulation in a ROWS * COLUMNS grid.
/// </summary>
public class Canvas
{
    private readonly Colour[,] _grid;
    private readonly int _rows;
    private readonly int _columns;
    private const int Colours = 255;

    public Canvas(int rows, int columns)
    {
        _grid = new Colour[rows,columns];
        _rows = rows;
        _columns = columns;
    }
    
    /// <summary> 
    /// Writes a new colour to the location ROW, COLUMN.
    /// </summary>
    public void Write(int row, int col, Colour colour)
    {
        if (row < 0 || row > _rows - 1 || col < 0 || col > _columns - 1)
        {
            return;
        }
        _grid[row, col] = colour;
    }
    
    /// <summary> 
    /// Returns the colour at the location ROW, COLUMN.
    /// </summary>
    public Colour Read(int row, int col)
    {
        return _grid[row, col];
    }

    /// <summary> 
    /// Sets every colour in the grid to the colour provided.
    /// </summary>
    public void SetBackground(Colour colour)
    {
        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                _grid[i, j] = colour;
            }
        }
    }

    /// <summary> 
    /// Exports a string of the canvas in the PPM format.
    /// https://netpbm.sourceforge.net/doc/ppm.html
    /// </summary>
    public string ExportAsPpm()
    {
        var builder = new StringBuilder();
        builder.Append("P3\n");
        builder.Append($"{_columns} {_rows}\n");
        builder.Append($"{Colours}\n");
        
        for (var row = 0; row < _rows; row++)
        {
            for (var col = 0; col < _columns; col++)
            {
                var colour = _grid[row, col];
                builder.Append(System.Math.Ceiling(NormalizeFloat(colour.Red) * 255));
                builder.Append(' ');
                builder.Append(System.Math.Ceiling(NormalizeFloat(colour.Green) * 255));
                builder.Append(' ');
                builder.Append(System.Math.Ceiling(NormalizeFloat(colour.Blue) * 255));
                builder.Append(' ');
                // Add a newline every 5th column, only if the number of columns is greater than 5
                if ((col + 1) % 5 == 0 && _columns > 5)
                {
                    builder.Append('\n');
                }
            }
            // Add a newline at the end of each row
            builder.Append('\n');
        }
        return builder.ToString();
    }
    
    private static float NormalizeFloat(float value)
    {
        return value switch
        {
            <= 0f => 0f,
            >= 1f => 1f,
            _ => value
        };
    }
}