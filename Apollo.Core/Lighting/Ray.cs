using Apollo.Geometry;
using Apollo.Math;
using Apollo.Math.AbstractClasses;

namespace Apollo.Lighting;

public class Ray
{
    public AbstractTuple Origin { get; }
    public AbstractTuple Direction { get; }

    public Ray(AbstractTuple origin, AbstractTuple direction)
    {
        (Origin, Direction) = (origin, direction);
    }

    public Point Position(float time)
    {
        return new Point(Origin + (Direction * time));
    }

    public Intersections Intersect(Sphere sphere)
    {
        var tOrigin = Origin * sphere.Transform.Inverse();
        var tDirection = Direction * sphere.Transform.Inverse();
        
        var sphereToRay = tOrigin - new Point(0, 0, 0);
        
        var a = tDirection.Dot(tDirection);
        var b = 2 * tDirection.Dot(sphereToRay);
        var c = sphereToRay.Dot(sphereToRay) - 1;
        
        var discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
        {
            return new Intersections();
        }
        else
        {
            var t1 = (float) (-b - System.Math.Sqrt(discriminant)) / (2 * a);
            var t2 = (float) (-b + System.Math.Sqrt(discriminant)) / (2 * a);
            return new Intersections(new Intersections.Intersect(sphere, t1), new Intersections.Intersect(sphere, t2));
        }
    }

    public static Intersections.Intersect? Hit(Intersections intersections)
    {
        intersections.Intersects.Sort();
        return intersections.Intersects.FirstOrDefault(item => item.Time >= 0);
    }
    
    public Ray Translate(float x, float y, float z)
    {
        var tMatrix = Matrix.Translation(x, y, z);
        return new Ray(Origin * tMatrix,Direction * tMatrix);
    }
    
    public Ray Scale(float x, float y, float z)
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
    //
    public Ray Shear(float xy, float xz, float yx, float yz, float zx, float zy)
    {
        var sMatrix = Matrix.Shear(xy, xz, yx, yz, zx, zy);
        return new Ray(Origin * sMatrix,Direction * sMatrix);
    }
}