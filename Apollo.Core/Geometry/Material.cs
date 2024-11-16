using Apollo.Display.AbstractClasses;
using Apollo.Display.ColourPresets;
using Apollo.Geometry.Interfaces;

namespace Apollo.Geometry;

public class Material
{
    public AbstractColour Colour { get; set; }
    public double Ambient { get; set; }
    public double Diffuse { get; set; }
    public double Specular { get; set; }
    public double Shininess { get; set; }
    public double Reflectivity { get; set; }
    public double Transparency { get; set; }
    public double RefractiveIndex { get; set; }
    public IPattern? Pattern { get; set; }

    public Material(AbstractColour colour, double ambient, double diffuse, double specular, double shininess, double reflectivity, double transparency, double refractiveIndex)
    {
        Colour = colour;
        Ambient = ambient;
        Diffuse = diffuse;
        Specular = specular;
        Shininess = shininess;
        Reflectivity = reflectivity;
        Transparency = transparency;
        RefractiveIndex = refractiveIndex;
    }

    public Material(AbstractColour colour)
    {
        Colour = colour;
        Ambient = 0.1;
        Diffuse = 0.9;
        Specular = 0.9;
        Shininess = 200;
        Reflectivity = 0;
        Transparency = 0;
        RefractiveIndex = 1;
    }

    public Material()
    {
        Colour = new White();
        Ambient = 0.1;
        Diffuse = 0.9;
        Specular = 0.9;
        Shininess = 200;
        Reflectivity = 0;
        Transparency = 0;
        RefractiveIndex = 1;
    }
}