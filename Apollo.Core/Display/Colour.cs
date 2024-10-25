namespace Apollo.Display;

/// <summary> 
/// A tuple for three colour systems -> Red, Blue, Green.
/// </summary>
public struct Colour
{
    public float Red { get; }
    public float Green { get;  }
    public float Blue { get;  }

    public Colour(float red, float green, float blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }
    
    /// <summary> 
    /// Add two colours together.
    /// </summary>
    public Colour Add(Colour c2)
    {
        return new Colour(Red + c2.Red, Green + c2.Green, Blue + c2.Blue);
    }
    
    /// <summary> 
    /// Subtracts two colours.
    /// </summary>
    public Colour Subtract(Colour c2)
    {
        return new Colour(Red - c2.Red, Green - c2.Green, Blue - c2.Blue);
    }
    
    /// <summary> 
    /// Multiplies a colour by a scalar.
    /// </summary>
    public Colour Multiply(float scalar)
    {
        return new Colour(Red * scalar, Green * scalar, Blue  * scalar);
    }

    /// <summary> 
    /// Returns the Hadamard Product of two colours.
    /// </summary>
    public Colour HadamardProduct(Colour c2)
    {
        return new Colour(Red * c2.Red, Green * c2.Green, Blue * c2.Blue);

    }

}