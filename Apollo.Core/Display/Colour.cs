namespace Apollo.Display;

public class Colour : AbstractColour
{
    public override float R { get; }
    public override float G { get; }
    public override float B { get; }
    
    public Colour(float red, float green, float blue)
    {
        (R, G, B) = (red, green, blue);
    }
}