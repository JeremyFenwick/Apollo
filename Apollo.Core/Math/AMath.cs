namespace Apollo.Math;

public static class AMath
{
    /// <summary> 
    /// Converts degrees to radians.
    /// https://en.wikipedia.org/wiki/Radian
    /// </summary>
    public static float Radians(float degrees)
    {
        return (degrees / 180) * (float)System.Math.PI;
    }
    
    public static double Radians(double degrees)
    {
        return (degrees / 180) * System.Math.PI;
    }
}