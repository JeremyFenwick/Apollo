using Apollo.Display;
using Apollo.Display.AbstractClasses;
using Apollo.Display.ColourPresets;

namespace Apollo.Lighting;

public class Material
{
    public AbstractColour Colour { get; set; }
    public float Ambient { get; set; }
    public float Diffuse { get; set; }
    public float Specular { get; set; }
    public float Shininess { get; set; }

    public Material(AbstractColour colour, float ambient, float diffuse, float specular, float shininess)
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