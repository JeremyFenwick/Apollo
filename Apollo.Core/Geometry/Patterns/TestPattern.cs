using Apollo.Display;
using Apollo.Display.AbstractClasses;
using Apollo.Geometry.Interfaces;
using Apollo.Math;
using Apollo.Math.AbstractClasses;

namespace Apollo.Geometry.Patterns;

public class TestPattern : IPattern
{
    public Matrix Transform { get; set; }
    
    public TestPattern()
    {
        Transform = Matrix.Identity();
    }
    
    public AbstractColour ColourAt(AbstractTuple point)
    {
        return new Colour(point.X, point.Y, point.Z);
    }
}