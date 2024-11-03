namespace Apollo.Math;

public class AbstractTuple(float x, float y, float z)
{
    public float X { get; } = x;
    public float Y { get; } = y;
    public float Z { get; } = z;
    public virtual float W { get; } = -1;
    protected const float Epsilon = 0.00001f;
    
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
    
    public static AbstractTuple operator *(AbstractTuple a, float scalar)
    {
        return new ATuple(a.X * scalar, a.Y * scalar, a.Z * scalar, a.W * scalar);
    }
    
    public static AbstractTuple operator *(float scalar, AbstractTuple a)
    {
        return new ATuple(a.X * scalar, a.Y * scalar, a.Z * scalar, a.W * scalar);
    }
    
    public static AbstractTuple operator /(AbstractTuple a, float scalar)
    {
        return new ATuple(a.X / scalar, a.Y / scalar, a.Z / scalar, a.W / scalar);
    }
    
    public static AbstractTuple operator /(float scalar, AbstractTuple a)
    {
        return new ATuple(a.X / scalar, a.Y / scalar, a.Z / scalar, a.W / scalar);
    }
    
    public float Magnitude()
    {
        return (float) System.Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
    }
    
    public AbstractTuple Normalize()
    {
        var magnitude = Magnitude();
        return new ATuple(X / magnitude, Y / magnitude, Z / magnitude, W / magnitude);
    }

    public float Dot(AbstractTuple b)
    {
        return X * b.X + Y * b.Y + Z * b.Z + W * b.W;
    }

    public AbstractTuple Cross(AbstractTuple b)
    {
        return new Vector(Y * b.Z - Z * b.Y, Z * b.X - X * b.Z, X * b.Y - Y * b.X);
    }
}