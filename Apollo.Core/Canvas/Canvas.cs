namespace Apollo.Canvas;

/// <summary> 
/// Creates a canvas, which contains the pixels used for image generation and manipulation in a WIDTH * HEIGHT grid.
/// </summary>
public class Canvas
{
    private Colour[,] _colours;

    public Canvas(int width, int height)
    {
        _colours = new Colour[width,height];
        InitializeColours();
    }

    private void InitializeColours()
    {
        for (int i = 0; i < _colours.GetLength(0); i++)
        {
            for (int j = 0; j < _colours.GetLength(1); j++)
            {
                _colours[i, j] = new Colour
                {
                    Red = 0f,
                    Blue = 0f,
                    Green = 0f
                };
            }
        }
    }
    
    /// <summary> 
    /// Writes a new colour to the location WIDTH, HEIGHT.
    /// </summary>
    public void Write(int width, int height, Colour colour)
    {
        _colours[width, height] = colour;
    }
    
    /// <summary> 
    /// Returns the colour at the location WIDTH, HEIGHT.
    /// </summary>
    public Colour Read(int width, int height)
    {
        return _colours[width, height];
    }
}