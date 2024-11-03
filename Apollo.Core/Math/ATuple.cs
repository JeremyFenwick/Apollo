namespace Apollo.Math;

public class ATuple(float x, float y, float z, float w) : AbstractTuple(x, y, z)
{
    public override float W { get; } = w;
}