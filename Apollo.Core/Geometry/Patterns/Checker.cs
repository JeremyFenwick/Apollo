using Apollo.Display.AbstractClasses;
using Apollo.Geometry.Interfaces;
using Apollo.Math;
using Apollo.Math.AbstractClasses;

namespace Apollo.Geometry.Patterns;

public class Checker : IPattern
{
    public Matrix Transform { get; set; }
    private readonly AbstractColour _c1;
    private readonly AbstractColour _c2;
    
    public Checker(AbstractColour c1, AbstractColour c2)
    {
        (this._c1, this._c2) = (c1, c2);
        Transform = Matrix.Identity();
    }
    
    public AbstractColour ColourAt(AbstractTuple point)
    {
        var temp = System.Math.Floor(point.X) + System.Math.Floor(point.Y) + System.Math.Floor(point.Z);
        return temp % 2 == 0 ? _c1 : _c2;
    }
}