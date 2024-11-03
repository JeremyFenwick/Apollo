using Apollo.Math.AbstractClasses;

namespace Apollo.Math;

public class Vector(float x, float y, float z) : AbstractTuple(x, y, z)
{
    public override float W { get; } = 0;
}