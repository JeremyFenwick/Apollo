using Apollo.Display.AbstractClasses;
using Apollo.Display.ColourPresets;

namespace Apollo.Geometry;

public class Material
{
    public AbstractColour Colour { get; set; }
    public double Ambient { get; set; }
    public double Diffuse { get; set; }
    public double Specular { get; set; }
    public double Shininess { get; set; }

    public Material(AbstractColour colour, double ambient, double diffuse, double specular, double shininess)
    {
        (Colour, Ambient, Diffuse, Specular, Shininess) = (colour, ambient, diffuse, specular, shininess);
    }

    public Material(AbstractColour colour)
    {
        Colour = colour;
        Ambient = 0.1f;
        Diffuse = 0.9f;
        Specular = 0.9f;
        Shininess = 200f;
    }

    public Material()
    {
        Colour = new White();
        Ambient = 0.1f;
        Diffuse = 0.9f;
        Specular = 0.9f;
        Shininess = 200f;
    }
}