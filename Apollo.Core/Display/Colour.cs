using Apollo.Display.AbstractClasses;

namespace Apollo.Display;

public class Colour : AbstractColour
{
    public override double R { get; }
    public override double G { get; }
    public override double B { get; }
    
    public Colour(double red, double green, double blue)
    {
        (R, G, B) = (red, green, blue);
    }
}