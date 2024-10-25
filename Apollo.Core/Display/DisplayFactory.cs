using System.Drawing;

namespace Apollo.Display;

public static class DisplayFactory
{
    public static Colour CreateColour(float red, float green, float blue)
    {
        return new Colour
        {
            Red = red,
            Blue = blue,
            Green = green
        };
    }
}