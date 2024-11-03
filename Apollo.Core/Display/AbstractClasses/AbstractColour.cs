namespace Apollo.Display.AbstractClasses;

public abstract class AbstractColour
{
    public virtual float R { get; } = 0;
    public virtual float G { get; } = 0;
    public virtual float B { get; } = 0;
    private const float Epsilon = 0.00001f;

    
    public override bool Equals(Object? obj)
    {
        if (obj is not AbstractColour colour)
        {
            return false;
        }
        return this == colour;
    }
    
    public static bool operator ==(AbstractColour c1, AbstractColour c2)
    {
        if (System.Math.Abs(c1.R - c2.R) > Epsilon)
        {
            return false;
        }
        if (System.Math.Abs(c1.G - c2.G) > Epsilon)
        {
            return false;
        }
        if (System.Math.Abs(c1.B - c2.B) > Epsilon)
        {
            return false;
        }
        return true;
    }
    
    public static bool operator !=(AbstractColour c1, AbstractColour c2)
    {
        if (System.Math.Abs(c1.R - c2.R) > Epsilon)
        {
            return true;
        }
        if (System.Math.Abs(c1.G - c2.G) > Epsilon)
        {
            return true;
        }
        if (System.Math.Abs(c1.B - c2.B) > Epsilon)
        {
            return true;
        }
        return false;
    }
    
    public static AbstractColour operator +(AbstractColour c1, AbstractColour c2)
    {
        return new Colour(c1.R + c2.R, c1.G + c2.G, c1.B + c2.B);
    }
    
    public static AbstractColour operator -(AbstractColour c1, AbstractColour c2)
    {
        return new Colour(c1.R - c2.R, c1.G - c2.G, c1.B - c2.B);
    }
    
    public static AbstractColour operator *(AbstractColour c1, int scalar)
    {
        return new Colour(c1.R * scalar, c1.G * scalar, c1.B * scalar);
    }
    
    public static AbstractColour operator *(AbstractColour c1, AbstractColour c2)
    {
        return new Colour(c1.R * c2.R, c1.G * c2.G, c1.B * c2.B);
    }
}