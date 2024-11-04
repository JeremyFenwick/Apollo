using Apollo.Display.AbstractClasses;
using Apollo.Lighting.Interfaces;
using Apollo.Math.AbstractClasses;

namespace Apollo.Lighting;

public class PointLight : ILight
{
    public AbstractTuple Position { get; }
    public AbstractColour Intensity { get; }

    public PointLight(AbstractTuple position, AbstractColour intensity)
    {
        (Position, Intensity) = (position, intensity);
    }
}