using System.Text;
using Apollo.Display.AbstractClasses;
using Apollo.Display.ColourPresets;

namespace Apollo.Display;

public class Canvas
{
    private readonly AbstractColour[,] _pixels;
    private readonly int _rows;
    private readonly int _columns;
    private const int Colours = 255;

    public Canvas(int columns, int rows)
    {
        _pixels = new AbstractColour[columns, rows];
        (_columns, _rows) = (columns, rows);
        Fill(new Black());
    }

    public void Fill(AbstractColour colour)
    {
        for (int col = 0; col < _columns; col++)
        {
            for (int row = 0; row < _rows; row++)
            {
                _pixels[col, row] = colour;
            }
        }
    }

    public AbstractColour Get(int col, int row)
    {
        return _pixels[col, row];
    }

    public bool Set(int col, int row, AbstractColour value)
    {
        if (col < 0 || col >= _pixels.GetLength(0) || row < 0 || row >= _pixels.GetLength(1))
        {
            return false;
        }
        _pixels[col, row] = value;
        return true;
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
                var colour = _pixels[col, row];
                builder.Append(System.Math.Ceiling(NormalizedDouble(colour.R) * 255));
                builder.Append(' ');
                builder.Append(System.Math.Ceiling(NormalizedDouble(colour.G) * 255));
                builder.Append(' ');
                builder.Append(System.Math.Ceiling(NormalizedDouble(colour.B) * 255));
                builder.Append(' ');
                // Add a newline every 5th column, only if the number of columns is greater than 5
                if ((col + 1) % 5 == 0 && _columns > 5)
                {
                    builder.Append($"{Environment.NewLine}");
                }
            }
            // Add a newline at the end of each row
            builder.Append($"{Environment.NewLine}");
        }
        return builder.ToString();
    }
    
    private static double NormalizedDouble(double value)
    {
        return value switch
        {
            <= 0f => 0f,
            >= 1f => 1f,
            _ => value
        };
    }
}