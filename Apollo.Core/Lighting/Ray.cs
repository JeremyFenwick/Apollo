using System.ComponentModel;
using Apollo.Display.AbstractClasses;
using Apollo.Display.ColourPresets;
using Apollo.Geometry;
using Apollo.Geometry.Interfaces;
using Apollo.Math;
using Apollo.Math.AbstractClasses;

namespace Apollo.Lighting;

public class Ray
{
    public AbstractTuple Origin { get; }
    public AbstractTuple Direction { get; }
    private const double Epsilon = 0.00001;

    public Ray(AbstractTuple origin, AbstractTuple direction)
    {
        (Origin, Direction) = (origin, direction);
    }

    public Point Position(double time)
    {
        return new Point(Origin + (Direction * time));
    }

    public Intersections WorldIntersect(World world)
    {
        var result = new Intersections();
        foreach (var item in world.Contents)
        {
            var intersects = item.Intersect(this);
            foreach (var intersection in intersects.Intersects)
            {
                result.Intersects.Add(intersection);
            }
        }

        result.Intersects.Sort();
        return result;
    }

    public static Intersect? Hit(Intersections intersections)
    {
        intersections.Intersects.Sort();
        return intersections.Intersects.FirstOrDefault(item => item.Time >= 0);
    }
    
    public Ray Translate(double x, double y, double z)
    {
        var tMatrix = Matrix.Translation(x, y, z);
        return new Ray(Origin * tMatrix,Direction * tMatrix);
    }
    
    public Ray Scale(double x, double y, double z)
    {
        var sMatrix = Matrix.Scaling(x, y, z);
        return new Ray(Origin * sMatrix,Direction * sMatrix);
    }
    
    public Ray XRotate(double radians)
    {
        var xMatrix = Matrix.XRotation(radians);
        return new Ray(Origin * xMatrix,Direction * xMatrix);
    }
    
    public Ray YRotate(double radians)
    {
        var yMatrix = Matrix.YRotation(radians);
        return new Ray(Origin * yMatrix,Direction * yMatrix);
    }
    
    public Ray ZRotate(double radians)
    {
        var zMatrix = Matrix.ZRotation(radians);
        return new Ray(Origin * zMatrix,Direction * zMatrix);
    }
    
    public Ray Shear(double xy, double xz, double yx, double yz, double zx, double zy)
    {
        var sMatrix = Matrix.Shear(xy, xz, yx, yz, zx, zy);
        return new Ray(Origin * sMatrix,Direction * sMatrix);
    }

    public Precomputation Precompute(Intersect intersect, Intersections intersections = null)
    {
        if (intersections == null)
        {
            intersections = new Intersections(intersect);
        }
        intersections.Intersects.Sort();
        
        double n1 = 1.0;
        double n2 = 1.0;
        var containers = new List<IShape>();
        // var hit = Hit(intersections);
        foreach (var item in intersections.Intersects)
        {
            // Set n1
            if (item == intersect)
            {
                if (containers.Count == 0)
                {
                    n1 = 1.0;
                }
                else
                {
                    n1 = containers.Last().Material.RefractiveIndex;
                }
            }

            if (containers.Contains(item.Object))
            {
                containers.Remove(item.Object);
            }
            else
            {
                containers.Add(item.Object);
            }

            if (item == intersect)
            {
                if (containers.Count == 0)
                {
                    n2 = 1.0;
                }
                else
                {
                    n2 = containers.Last().Material.RefractiveIndex;
                }
                break;
            }
        }
        
        var point = Position(intersect.Time);
        var eyeV = -Direction;
        var normalV = intersect.Object.NormalAt(point);
        var inside = false;
        
        if (normalV.Dot(eyeV) < 0)
        {
            normalV = -normalV;
            inside = true;
        }

        var overPoint = point + (normalV * Epsilon);
        var underPoint = point - (normalV * Epsilon);
        var reflectV = this.Direction.Reflect(normalV);
        
        return new Precomputation(intersect.Time, intersect.Object, point, overPoint, underPoint, eyeV, normalV, inside, reflectV, n1, n2);
    }

    public AbstractColour ColourAt(World world, int remaining = 5)
    {
        if (remaining <= 0)
        {
            return new Black();
        }
        var intersections = this.WorldIntersect(world);
        var hit = Hit(intersections);
        if (hit == null)
        {
            return new Black();
        }
        var comp = Precompute(hit, intersections);
        var shadowed = world.IsShadowed(comp.OverPoint);
        
        var shadeHit = Shading.Lighting(comp.Object.Material, world.LightSource, comp.OverPoint, comp.EyeV, comp.NormalV, shadowed, comp.Object);
        var reflected = world.ReflectedColour(comp, remaining);
        var refracted = world.RefractedColour(comp, remaining);

        if (comp.Object.Material is { Reflectivity: > 0, Transparency: > 0 })
        {
            var reflectance = Shading.Shclick(comp);
            return shadeHit + (reflected * reflectance) + (refracted * (1 - reflectance));
        }

        return shadeHit + reflected + refracted;
        
    }
}