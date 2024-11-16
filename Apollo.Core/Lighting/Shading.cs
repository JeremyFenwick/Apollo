using Apollo.Display;
using Apollo.Display.AbstractClasses;
using Apollo.Display.ColourPresets;
using Apollo.Geometry;
using Apollo.Geometry.Interfaces;
using Apollo.Lighting.Interfaces;
using Apollo.Math.AbstractClasses;

namespace Apollo.Lighting;

public static class Shading
{
    public static AbstractColour Lighting(Material material, ILight light, AbstractTuple point, AbstractTuple eyeV, AbstractTuple normalV, bool inShadow, IShape shape)
    {
        AbstractColour ambient, diffuse, specular, colour;
        colour = shape.ColourAt(point);
        
        var effectiveColour = colour * light.Intensity;
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

    public static double Shclick(Precomputation comps)
    {
        var cos = comps.EyeV.Dot(comps.NormalV);

        if (comps.N1 > comps.N2)
        {
            var ratio = comps.N1 / comps.N2;
            var sin2T = (ratio * ratio) * (1.0 - (cos * cos));
            if (sin2T > 1)
            {
                return 1;
            }
            cos = System.Math.Sqrt(1 - sin2T);
        }
        var r0 = System.Math.Pow((comps.N1 - comps.N2) / (comps.N1 + comps.N2), 2);
        return r0 + (1 - r0) * System.Math.Pow((1 - cos), 5);
    }
}