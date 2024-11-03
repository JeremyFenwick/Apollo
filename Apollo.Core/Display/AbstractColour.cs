﻿namespace Apollo.Display;

public abstract class AbstractColour
{
    public virtual float R { get; } = 0;
    public virtual float G { get; } = 0;
    public virtual float B { get; } = 0;

    public static bool operator ==(AbstractColour c1, AbstractColour c2)
    {
        if (System.Math.Abs(c1.R - c2.R) > 0.00001)
        {
            return false;
        }
        if (System.Math.Abs(c1.G - c2.G) > 0.00001)
        {
            return false;
        }
        if (System.Math.Abs(c1.B - c2.B) > 0.00001)
        {
            return false;
        }
        return true;
    }
    
    public static bool operator !=(AbstractColour c1, AbstractColour c2)
    {
        if (System.Math.Abs(c1.R - c2.R) > 0.00001)
        {
            return true;
        }
        if (System.Math.Abs(c1.G - c2.G) > 0.00001)
        {
            return true;
        }
        if (System.Math.Abs(c1.B - c2.B) > 0.00001)
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