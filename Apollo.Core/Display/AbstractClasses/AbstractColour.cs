namespace Apollo.Display.AbstractClasses;

public abstract class AbstractColour
{
    public virtual double R { get; } = 0;
    public virtual double G { get; } = 0;
    public virtual double B { get; } = 0;
    private const double Epsilon = 0.0001f;

    
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
    
    public static AbstractColour operator *(AbstractColour c1, double scalar)
    {
        return new Colour(c1.R * scalar, c1.G * scalar, c1.B * scalar);
    }
    
    public static AbstractColour operator *(AbstractColour c1, AbstractColour c2)
    {
        return new Colour(c1.R * c2.R, c1.G * c2.G, c1.B * c2.B);
    }
}