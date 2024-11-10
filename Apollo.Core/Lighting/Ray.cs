﻿using Apollo.Display;
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

    public Ray(AbstractTuple origin, AbstractTuple direction)
    {
        (Origin, Direction) = (origin, direction);
    }

    public Point Position(float time)
    {
        return new Point(Origin + (Direction * time));
    }

    public Intersections Intersect(GeometricObject item)
    {
        var tOrigin = Origin * item.Transform.Inverse();
        var tDirection = Direction * item.Transform.Inverse();
        
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
            return new Intersections(new Intersect(item, t1), new Intersect(item, t2));
        }
    }

    public Intersections WorldIntersect(World world)
    {
        var result = new Intersections();
        foreach (var item in world.Contents)
        {
            var intersects = Intersect(item);
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

        return new Precomputation(intersect.Time, intersect.Object, point, eyeV, normalV, inside);
    }

    public AbstractColour ColourAt(World world)
    {
        var intersections = this.WorldIntersect(world);
        var hit = Hit(intersections);
        if (hit == null)
        {
            return new Black();
        }
        var comp = Precompute(hit);
        var shadeHit = Shading.Lighting(comp.Object.Material, world.LightSource, comp.Point, comp.EyeV, comp.NormalV);
        return shadeHit;
    }
}