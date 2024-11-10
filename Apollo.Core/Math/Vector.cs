using Apollo.Math.AbstractClasses;

namespace Apollo.Math;

public class Vector : AbstractTuple
{
    public override double W { get; } = 0;

    public Vector(double x, double y, double z) : base(x, y, z)
    {
        W = 0;
    }

    public Vector(AbstractTuple tuple) : base(tuple)
    {
        W = 0;
    }
}