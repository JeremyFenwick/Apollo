namespace Apollo.Math;

public static class MathFactory
{
    /// <summary> 
    /// Creates a point. (W = 1.0)
    /// </summary>
    public static ATuple Point(float x, float y, float z)
    {
        return new ATuple() { X = x, Y = y, Z = z, W = 1.0f };
    }
    
    /// <summary> 
    /// Creates a vector. (W = 0.0)
    /// </summary>
    public static ATuple Vector(float x, float y, float z)
    {
        return new ATuple() { X = x, Y = y, Z = z, W = 0.0f };
    }
}