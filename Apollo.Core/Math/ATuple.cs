using System.Diagnostics;

namespace Apollo.Math;

/// <summary> 
/// A tuple for three dimension co-ordinate systems. Always on the stack.
/// </summary>
public ref struct ATuple()
{
    public required double X { get; init; }
    public required double Y { get; init; }
    public required double Z { get; init; }
    public required double W { get; init; }
    
    /// <summary> 
    /// Returns true is a tuple is a point (a.W ~ 1.0)
    /// </summary>
    public static bool IsPoint(ATuple a)
    {
        return System.Math.Abs(a.W - 1.0) < 0.00001;
    }
    
    /// <summary> 
    /// Returns true is a tuple is a vector (a.W == 0.0)
    /// </summary>
    public static bool IsVector(ATuple a)
    {
        return a.W == 0.0;
    }
    /// <summary> 
    /// Add two tuples together. Note W should always be 0.0 or 1.0.
    /// </summary>
    public static ATuple Add(ATuple a, ATuple b)
    {
        return new ATuple
        {
            X = a.X + b.X,
            Y = a.Y + b.Y,
            Z = a.Z + b.Z,
            W = a.W + b.W
        };
    }
    
    /// <summary> 
    /// Subtracts the second tuple from the first. Note W should always be 0.0 or 1.0.
    /// </summary>
    public static ATuple Subtract(ATuple a, ATuple b)
    {
        return new ATuple
        {
            X = a.X - b.X,
            Y = a.Y - b.Y,
            Z = a.Z - b.Z,
            W = a.W - b.W
        };
    }
    
    /// <summary> 
    /// Negates a tuple. Note W is also negated.
    /// </summary>
    public static ATuple Negate(ATuple a)
    {
        return new ATuple
        {
            X = -a.X,
            Y = -a.Y,
            Z = -a.Z,
            W = -a.W,
        };
    }

    /// <summary> 
    /// Multiplies a tuple by a scalar. Note W is also multiplied.
    /// </summary>
    public static ATuple Multiply(ATuple a, double scalar)
    {
        return new ATuple
        {
            X = a.X * scalar,
            Y = a.Y * scalar,
            Z = a.Z * scalar,
            W = a.W * scalar,
        };
    }
    
    /// <summary> 
    /// Divides a tuple by a scalar. Note W is also divided.
    /// </summary>
    public static ATuple Divide(ATuple a, double scalar)
    {
        return new ATuple
        {
            X = a.X / scalar,
            Y = a.Y / scalar,
            Z = a.Z / scalar,
            W = a.W / scalar,
        };
    }

    /// <summary> 
    /// Takes the magnitude of a vector. Note this cannot be used on points!
    /// </summary>
    public static double Magnitude(ATuple a)
    {
        var temp = System.Math.Pow(a.X, 2) + System.Math.Pow(a.Y, 2) + System.Math.Pow(a.Z, 2) + System.Math.Pow(a.W, 2);
        return System.Math.Sqrt(temp);
    }

    /// <summary> 
    /// Returns the normal of a vector.
    /// </summary>
    public static ATuple Normalize(ATuple a)
    {
        var magnitude = Magnitude(a);
        return new ATuple
        {
            X = a.X / magnitude,
            Y = a.Y / magnitude,
            Z = a.Z / magnitude,
            W = a.W / magnitude,
        };
    }

    /// <summary> 
    /// Returns a scalar. The inner product of two tuples.
    /// </summary>
    public static double DotProduct(ATuple a, ATuple b)
    {
        return a.X * b.X + a.Y * b.Y + a.Z * b.Z + a.W * b.W;
    }
    
    /// <summary> 
    /// Returns a tuple. The cross product of two tuples.
    /// </summary>
    public static ATuple CrossProduct(ATuple a, ATuple b)
    {
        return new ATuple
        {
            X = (a.Y * b.Z) - (a.Z * b.Y),
            Y = (a.Z * b.X) - (a.X * b.Z),
            Z = (a.X * b.Y) - (a.Y * b.X),
            W = 0.0,
        };    
    }

    /// <summary> 
    /// Compares two tuples for equality within 0.00001 precision.
    /// </summary>
    public static bool Equals(ATuple a, ATuple b)
    {
        if (System.Math.Abs(a.X - b.X) > 0.0001 || System.Math.Abs(a.Y - b.Y) > 0.0001 )
        {
            return false;
        }
        else if (System.Math.Abs(a.Z - b.Z) > 0.0001 || System.Math.Abs(a.W - b.W) > 0.0001)
        {
            return false;
        }
        return true;
    }
}