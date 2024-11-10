using Apollo.Display;
using Apollo.Display.AbstractClasses;
using Apollo.Display.ColourPresets;
using Apollo.Lighting.Interfaces;
using Apollo.Math.AbstractClasses;

namespace Apollo.Lighting;

public static class Shading
{
    public static AbstractColour Lighting(Material material, ILight light, AbstractTuple point, AbstractTuple eyeV,
        AbstractTuple normalV, bool inShadow)
    {
        AbstractColour ambient, diffuse, specular;
        
        var effectiveColour = material.Colour * light.Intensity;
        var lightV = (light.Position - point).Normalize();
        ambient = effectiveColour * material.Ambient;

        if (inShadow)
        {
            return ambient;
        }
        
        var lightDotNormal = lightV.Dot(normalV);
        if (lightDotNormal < 0)
        {
            diffuse = new Black();
            specular = new Black();
        }
        else
        {
            diffuse = effectiveColour * material.Diffuse * lightDotNormal;
            
            var reflectV = (-lightV).Reflect(normalV);
            var reflectDotEye = reflectV.Dot(eyeV);

            if (reflectDotEye <= 0)
            {
                specular = new Black();
            }
            else
            {
                var factor = (float) System.Math.Pow(reflectDotEye, material.Shininess);
                specular = light.Intensity * material.Specular * factor;
            }
        }
        return ambient + diffuse + specular;
    }
}