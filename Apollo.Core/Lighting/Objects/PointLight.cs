using Apollo.Display.Objects;
using Apollo.Math.Objects;

namespace Apollo.Lighting.Objects;

public class PointLight
{
    public Colour Colour { get; }
    public ATuple Point { get; }

    public PointLight(Colour colour, ATuple point)
    {
        Colour = colour;
        Point = point;
    }
}