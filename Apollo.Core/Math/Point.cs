using Apollo.Math.AbstractClasses;

namespace Apollo.Math;

public class Point : AbstractTuple
{
    public override double W { get; }

    public Point(double x, double y, double z) : base(x, y, z)
    {
        W = 1;
    }

    public Point(AbstractTuple tuple) : base(tuple)
    {
        W = 1;
    }
}