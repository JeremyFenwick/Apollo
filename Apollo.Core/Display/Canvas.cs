using System.Text;

namespace Apollo.Display;

/// <summary> 
/// Creates a canvas, which contains the pixels used for image generation and manipulation in a ROWS * COLUMNS grid.
/// </summary>
public class Canvas
{
    private readonly Colour[,] _colours;
    private readonly int _rows;
    private readonly int _columns;
    private const int Colours = 255;

    public Canvas(int rows, int columns)
    {
        _colours = new Colour[rows,columns];
        _rows = rows;
        _columns = columns;
    }
    
    /// <summary> 
    /// Writes a new colour to the location ROW, COLUMN.
    /// </summary>
    public void Write(int row, int col, Colour colour)
    {
        _colours[row, col] = colour;
    }
    
    /// <summary> 
    /// Returns the colour at the location ROW, COLUMN.
    /// </summary>
    public Colour Read(int row, int col)
    {
        return _colours[row, col];
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
                var colour = _colours[row, col];
                builder.Append(NormalizeFloat(colour.Red * 255));
                builder.Append(NormalizeFloat(colour.Blue * 255));
                builder.Append(NormalizeFloat(colour.Green * 255));
                // Add a newline every 6th column
                if (col % 5 == 0)
                {
                    builder.Append('\n');
                }
            }
            // Add a newline at the end of each row
            builder.Append('\n');
        }
        return builder.ToString();
    }

    private float NormalizeFloat(float value)
    {
        return value switch
        {
            <= 0f => 0f,
            >= 1f => 1f,
            _ => value
        };
    }
}