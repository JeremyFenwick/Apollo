using Apollo.Display.AbstractClasses;
using Apollo.Geometry.Interfaces;
using Apollo.Math;
using Apollo.Math.AbstractClasses;

namespace Apollo.Geometry.Patterns;

public class Ring : IPattern
{
    public Matrix Transform { get; set; }
    private readonly AbstractColour _c1;
    private readonly AbstractColour _c2;
    
    public Ring(AbstractColour c1, AbstractColour c2)
    {
        (this._c1, this._c2) = (c1, c2);
        Transform = Matrix.Identity();
    }
    
    public AbstractColour ColourAt(AbstractTuple point)
    {
        var temp = System.Math.Sqrt(System.Math.Pow(point.X, 2) + System.Math.Pow(point.Z, 2));
        return System.Math.Floor(temp) % 2 == 0 ? _c1 : _c2;
    }
}