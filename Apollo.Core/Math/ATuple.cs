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
        var result = new ATuple
        {
            X = a.X + b.X,
            Y = a.Y + b.Y,
            Z = a.Z + b.Z,
            W = a.W + b.W
        };
        // W should always be either a vector or a point
        Debug.Assert(IsPoint(result) || IsVector(result));
        return result;
    }
    
    /// <summary> 
    /// Subtracts the second tuple from the first. Note W should always be 0.0 or 1.0.
    /// </summary>
    public static ATuple Subtract(ATuple a, ATuple b)
    {
        var result = new ATuple
        {
            X = a.X - b.X,
            Y = a.Y - b.Y,
            Z = a.Z - b.Z,
            W = a.W - b.W
        };
        // W should always be either 0.0 or 1.0
        Debug.Assert(IsPoint(result) || IsVector(result));
        return result;
    }
}