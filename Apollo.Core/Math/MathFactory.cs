namespace Apollo.Math;

public static class MathFactory
{
    public static ATuple Point(double x, double y, double z)
    {
        return new ATuple() { X = x, Y = y, Z = z, W = 1.0 };
    }

    public static ATuple Vector(double x, double y, double z)
    {
        return new ATuple() { X = x, Y = y, Z = z, W = 0.0 };
    }
}