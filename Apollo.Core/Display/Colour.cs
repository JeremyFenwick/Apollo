namespace Apollo.Display;

/// <summary> 
/// A tuple for three colour systems -> Red, Blue, Green.
/// </summary>
public struct Colour
{
    public required float Red { get; init; }
    public required float Blue { get; init; }
    public required float Green { get; init; }

    /// <summary> 
    /// Add two colours together.
    /// </summary>
    public Colour Add(Colour c2)
    {
        return new Colour
        {
            Red = Red + c2.Red,
            Blue = Blue + c2.Blue,
            Green = Green + c2.Green
        };
    }
    
    /// <summary> 
    /// Subtracts two colours.
    /// </summary>
    public Colour Subtract(Colour c2)
    {
        return new Colour
        {
            Red = Red - c2.Red,
            Blue = Blue - c2.Blue,
            Green = Green - c2.Green
        };
    }
    
    /// <summary> 
    /// Multiplies a colour by a scalar.
    /// </summary>
    public Colour Multiply(float scalar)
    {
        return new Colour
        {
            Red = Red * scalar,
            Blue = Blue * scalar,
            Green = Green * scalar
        };
    }

    /// <summary> 
    /// Returns the Hadamard Product of two colours.
    /// </summary>
    public Colour HadamardProduct(Colour c2)
    {
        return new Colour
        {
            Red = Red * c2.Red,
            Blue = Blue * c2.Blue,
            Green = Green * c2.Green
        };
    }

}