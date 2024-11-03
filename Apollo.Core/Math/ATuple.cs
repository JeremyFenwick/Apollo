using Apollo.Math.AbstractClasses;

namespace Apollo.Math;

public class ATuple : AbstractTuple
{
    public override float W { get; }
    
    public ATuple(float x, float y, float z, float w) : base(x, y, z)
    {
        W = w;
    }
}