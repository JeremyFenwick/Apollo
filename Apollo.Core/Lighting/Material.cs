﻿using Apollo.Display;
using Apollo.Display.AbstractClasses;
using Apollo.Display.ColourPresets;

namespace Apollo.Lighting;

public class Material
{
    public AbstractColour Colour { get; }
    public float Ambient { get; }
    public float Diffuse { get; }
    public float Specular { get; }
    public float Shininess { get; }

    public Material(AbstractColour colour, float ambient, float diffuse, float specular, float shininess)
    {
        (Colour, Ambient, Diffuse, Specular, Shininess) = (colour, ambient, diffuse, specular, shininess);
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