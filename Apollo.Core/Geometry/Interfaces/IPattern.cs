using Apollo.Display.AbstractClasses;
using Apollo.Math;
using Apollo.Math.AbstractClasses;

namespace Apollo.Geometry.Interfaces;

public interface IPattern
{
    public Matrix Transform { get; set; }
    public AbstractColour ColourAt(AbstractTuple point);
}