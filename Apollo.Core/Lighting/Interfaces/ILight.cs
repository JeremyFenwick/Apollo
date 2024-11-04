using Apollo.Display.AbstractClasses;
using Apollo.Math.AbstractClasses;

namespace Apollo.Lighting.Interfaces;

public interface ILight
{
    public AbstractTuple Position { get; }
    public AbstractColour Intensity { get; }
}