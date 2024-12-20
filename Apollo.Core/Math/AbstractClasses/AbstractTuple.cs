﻿namespace Apollo.Math.AbstractClasses;

public class AbstractTuple
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }
    public virtual double W { get; }
    private const double Epsilon = 0.00001f;

    protected AbstractTuple(double x, double y, double z)
    {
     (X, Y, Z, W) = (x, y, z, 0);
    }

    protected AbstractTuple(AbstractTuple tuple)
    {
        (X, Y, Z, W) = (tuple.X, tuple.Y, tuple.Z, tuple.W);
    }

    protected AbstractTuple()
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(AbstractTuple a, AbstractTuple b)
    {
        if (System.Math.Abs(a.X - b.X) > Epsilon)
        {
            return false;
        }
        if (System.Math.Abs(a.Y - b.Y) > Epsilon)
        {
            return false;
        }
        if (System.Math.Abs(a.Z - b.Z) > Epsilon)
        {
            return false;
        }
        if (System.Math.Abs(a.W - b.W) > Epsilon)
        {
            return false;
        }
        return true;
    }
    
    public override bool Equals(Object? obj)
    {
        if (obj is not AbstractTuple tuple)
        {
            return false;
        }
        return this == tuple;
    }
    
    public static bool operator !=(AbstractTuple a, AbstractTuple b)
    {
        if (System.Math.Abs(a.X - b.X) > Epsilon)
        {
            return true;
        }
        if (System.Math.Abs(a.Y - b.Y) > Epsilon)
        {
            return true;
        }
        if (System.Math.Abs(a.Z - b.Z) > Epsilon)
        {
            return true;
        }
        if (System.Math.Abs(a.W - b.W) > Epsilon)
        {
            return true;
        }
        return false;
    }

    public static AbstractTuple operator +(AbstractTuple a, AbstractTuple b)
    {
        return new ATuple(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
    }
    
    public static AbstractTuple operator -(AbstractTuple a, AbstractTuple b)
    {
        return new ATuple(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
    }
    
    public static AbstractTuple operator -(AbstractTuple a)
    {
        return new ATuple(-a.X, -a.Y, -a.Z, -a.W);
    }
    
    public static AbstractTuple operator *(AbstractTuple a, double scalar)
    {
        return new ATuple(a.X * scalar, a.Y * scalar, a.Z * scalar, a.W * scalar);
    }
    
    public static AbstractTuple operator *(double scalar, AbstractTuple a)
    {
        return new ATuple(a.X * scalar, a.Y * scalar, a.Z * scalar, a.W * scalar);
    }
    
    public static AbstractTuple operator /(AbstractTuple a, double scalar)
    {
        return new ATuple(a.X / scalar, a.Y / scalar, a.Z / scalar, a.W / scalar);
    }
    
    public static AbstractTuple operator /(double scalar, AbstractTuple a)
    {
        return new ATuple(a.X / scalar, a.Y / scalar, a.Z / scalar, a.W / scalar);
    }
    
    public double Magnitude()
    {
        return (double) System.Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
    }
    
    public AbstractTuple Normalize()
    {
        var magnitude = Magnitude();
        return new ATuple(X / magnitude, Y / magnitude, Z / magnitude, W / magnitude);
    }

    public double Dot(AbstractTuple b)
    {
        return X * b.X + Y * b.Y + Z * b.Z + W * b.W;
    }

    public AbstractTuple Cross(AbstractTuple b)
    {
        return new Vector(Y * b.Z - Z * b.Y, Z * b.X - X * b.Z, X * b.Y - Y * b.X);
    }
    
    public AbstractTuple Translate(double x, double y, double z)
    {
        var tMatrix = Matrix.Translation(x, y, z);
        return this * tMatrix;
    }
    
    public AbstractTuple Scale(double x, double y, double z)
    {
        var sMatrix = Matrix.Scaling(x, y, z);
        return this * sMatrix;
    }

    public AbstractTuple XRotate(double radians)
    {
        var xMatrix = Matrix.XRotation(radians);
        return this * xMatrix;
    }
    
    public AbstractTuple YRotate(double radians)
    {
        var yMatrix = Matrix.YRotation(radians);
        return this * yMatrix;
    }
    
    public AbstractTuple ZRotate(double radians)
    {
        var zMatrix = Matrix.ZRotation(radians);
        return this * zMatrix;
    }
    
    public AbstractTuple Shear(double xy, double xz, double yx, double yz, double zx, double zy)
    {
        var sMatrix = Matrix.Shear(xy, xz, yx, yz, zx, zy);
        return this * sMatrix;
    }

    public AbstractTuple Reflect(AbstractTuple normal)
    {
        return this - (normal * 2 * Dot(normal));
    }
}