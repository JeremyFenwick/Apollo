using Apollo.Math.AbstractClasses;

namespace Apollo.Math;

public class Point : AbstractTuple
{
    public override float W { get; }

    public Point(float x, float y, float z) : base(x, y, z)
    {
        W = 1;
    }

    public Point(AbstractTuple tuple) : base(tuple)
    {
    }
}