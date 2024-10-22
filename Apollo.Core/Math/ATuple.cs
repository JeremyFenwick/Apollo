namespace Apollo.Math;

/// <summary> 
/// A tuple for three dimension co-ordinate systems. 
/// </summary>
public struct ATuple()
{
    public required float X { get; init; }
    public required float Y { get; init; }
    public required float Z { get; init; }
    public required float W { get; init; }
    
    /// <summary> 
    /// Returns true is a tuple is a point (a.W ~ 1.0)
    /// </summary>
    public bool IsPoint()
    {
        return System.Math.Abs(W - 1.0f) < 0.00001;
    }
    
    /// <summary> 
    /// Returns true is a tuple is a vector (a.W == 0.0)
    /// </summary>
    public bool IsVector()
    {
        return W == 0.0f;
    }
    /// <summary> 
    /// Add two tuples together. Note W should always be 0.0 or 1.0.
    /// </summary>
    public ATuple Add(ATuple b)
    {
        return new ATuple
        {
            X = X + b.X,
            Y = Y + b.Y,
            Z = Z + b.Z,
            W = W + b.W
        };
    }
    
    /// <summary> 
    /// Subtracts the second tuple from the first. Note W should always be 0.0 or 1.0.
    /// </summary>
    public ATuple Subtract(ATuple b)
    {
        return new ATuple
        {
            X = X - b.X,
            Y = Y - b.Y,
            Z = Z - b.Z,
            W = W - b.W
        };
    }
    
    /// <summary> 
    /// Negates a tuple. Note W is also negated.
    /// </summary>
    public ATuple Negate()
    {
        return new ATuple
        {
            X = -X,
            Y = -Y,
            Z = -Z,
            W = -W,
        };
    }

    /// <summary> 
    /// Multiplies a tuple by a scalar. Note W is also multiplied.
    /// </summary>
    public ATuple Multiply(float scalar)
    {
        return new ATuple
        {
            X = X * scalar,
            Y = Y * scalar,
            Z = Z * scalar,
            W = W * scalar,
        };
    }
    
    /// <summary> 
    /// Divides a tuple by a scalar. Note W is also divided.
    /// </summary>
    public ATuple Divide(float scalar)
    {
        return new ATuple
        {
            X = X / scalar,
            Y = Y / scalar,
            Z = Z / scalar,
            W = W / scalar,
        };
    }

    /// <summary> 
    /// Takes the magnitude of a vector. Note this cannot be used on points!
    /// </summary>
    public float Magnitude()
    {
        var temp = System.Math.Pow(X, 2) + System.Math.Pow(Y, 2) + System.Math.Pow(Z, 2) + System.Math.Pow(W, 2);
        return (float) System.Math.Sqrt(temp);
    }

    /// <summary> 
    /// Returns the normal of a vector.
    /// </summary>
    public ATuple Normalize()
    {
        var magnitude = Magnitude();
        return new ATuple
        {
            X = X / magnitude,
            Y = Y / magnitude,
            Z = Z / magnitude,
            W = W / magnitude,
        };
    }

    /// <summary> 
    /// Returns a scalar. The inner product of two tuples.
    /// </summary>
    public double DotProduct(ATuple b)
    {
        return (X * b.X) + (Y * b.Y) + (Z * b.Z) + (W * b.W);
    }
    
    /// <summary> 
    /// Returns a tuple. The cross product of two tuples.
    /// </summary>
    public ATuple CrossProduct(ATuple b)
    {
        return new ATuple
        {
            X = (Y * b.Z) - (Z * b.Y),
            Y = (Z * b.X) - (X * b.Z),
            Z = (X * b.Y) - (Y * b.X),
            W = 0.0f,
        };    
    }

    /// <summary> 
    /// Compares two tuples for equality within 0.00001 precision.
    /// </summary>
    public bool Equals(ATuple b)
    {
        if (System.Math.Abs(X - b.X) > 0.00001f || System.Math.Abs(Y - b.Y) > 0.00001f )
        {
            return false;
        }
        if (System.Math.Abs(Z - b.Z) > 0.00001f || System.Math.Abs(W - b.W) > 0.00001f)
        {
            return false;
        }
        return true;
    }
}