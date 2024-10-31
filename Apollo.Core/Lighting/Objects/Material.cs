using Apollo.Display.Objects;

namespace Apollo.Lighting.Objects;

public class Material
{
    public Colour Colour { get; }
    public float Ambient { get; }
    public float Diffuse { get; }
    public float Specular { get; }
    public float Shininess { get; }

    public Material(Colour colour, float ambient, float diffuse, float specular, float shininess)
    {
        Colour = colour;
        Ambient = ambient;
        Diffuse = diffuse;
        Specular = specular;
        Shininess = shininess;
    }

    public Material()
    {
        Colour = new Colour(1, 1, 1);
        Ambient = 0.1f;
        Diffuse = 0.9f;
        Specular = 0.9f;
        Shininess = 0.9f;
    }
}