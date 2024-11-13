using Apollo.Display.AbstractClasses;
using Apollo.Geometry.Interfaces;
using Apollo.Math;
using Apollo.Math.AbstractClasses;

namespace Apollo.Geometry.Patterns;

public class Stripe : IPattern
{
    public Matrix Transform { get; set; }
    private readonly AbstractColour _c1;
    private readonly AbstractColour _c2;

    public AbstractColour ColourAt(AbstractTuple point)
    {
        return System.Math.Floor(point.X) % 2 == 0 ? _c1 : _c2;
    }

    public Stripe(AbstractColour c1, AbstractColour c2)
    {
        (this._c1, this._c2) = (c1, c2);
        Transform = Matrix.Identity();
    }
}