using Apollo.Math.AbstractClasses;

namespace Apollo.Math;

public class ATuple : AbstractTuple
{
    public override double W { get; }
    
    public ATuple(double x, double y, double z, double w) : base(x, y, z)
    {
        W = w;
    }
}