namespace Apollo.Math;

public class Point(float x, float y, float z) : AbstractTuple(x, y, z)
{
    public override float W { get; } = 1;

}