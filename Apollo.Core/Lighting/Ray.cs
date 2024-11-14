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
    
    public Precomputation Precompute(Intersect intersect)
    {
        var point = Position(intersect.Time);
        var eyeV = -Direction;
        var normalV = intersect.Object.NormalAt(point);
        var inside = false;
        
        if (normalV.Dot(eyeV) < 0)
        {
            normalV = -normalV;
            inside = true;
        }

        var overPoint = point + normalV * Epsilon;
        var reflectV = this.Direction.Reflect(normalV);
        
        return new Precomputation(intersect.Time, intersect.Object, point, overPoint, eyeV, normalV, inside, reflectV);
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
        var comp = Precompute(hit);
        var shadowed = world.IsShadowed(comp.OverPoint);
        var shadeHit = Shading.Lighting(comp.Object.Material, world.LightSource, comp.OverPoint, comp.EyeV, comp.NormalV, shadowed, hit.Object);
        var reflected = world.ReflectedColour(comp, remaining - 1);
        
        return shadeHit + reflected;
    }
}