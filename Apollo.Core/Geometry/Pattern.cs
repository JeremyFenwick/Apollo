using Apollo.Display.AbstractClasses;
using Apollo.Geometry.Interfaces;
using Apollo.Math.AbstractClasses;

namespace Apollo.Geometry;

public class Pattern
{
    private readonly IPattern _pattern;

    public Pattern(IPattern pattern)
    {
        _pattern = pattern;
    }

    public AbstractColour ColourAt(AbstractTuple point)
    {
        return _pattern.ColourAt(point);
    }
}