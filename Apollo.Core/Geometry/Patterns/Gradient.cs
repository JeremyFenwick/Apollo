using Apollo.Display.AbstractClasses;
using Apollo.Geometry.Interfaces;
using Apollo.Math;
using Apollo.Math.AbstractClasses;

namespace Apollo.Geometry.Patterns;

public class Gradient : IPattern
{
    public Matrix Transform { get; set; }
    private readonly AbstractColour _c1;
    private readonly AbstractColour _c2;

    public AbstractColour ColourAt(AbstractTuple point)
    {
        var distance = _c2 - _c1;
        var fraction = point.X - System.Math.Floor(point.X);
        return _c1 + (distance * fraction);
    }
    
    public Gradient(AbstractColour c1, AbstractColour c2)
    {
        (this._c1, this._c2) = (c1, c2);
        Transform = Matrix.Identity();
    }
}