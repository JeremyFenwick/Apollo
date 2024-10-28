namespace Apollo.Math.Objects;

/// <summary> 
/// A tuple for three dimension co-ordinate systems. 
/// </summary>
public readonly struct ATuple
{
    public float X { get; }
    public float Y { get; }
    public float Z { get; }
    public float W { get; }

    public ATuple(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }
    
    /// <summary> 
    /// Returns true is a tuple is a point (a.W ~ 1.0)
    /// </summary>
    public bool IsPoint()
    {
        return System.Math.Abs(W - 1.0f) < 0.00001;
    }
    
    /// <summary> 
    /// Returns true is a tuple is a vector (a.W == 0.0)
    /// </summary>
    public bool IsVector()
    {
        return W == 0.0f;
    }
    /// <summary> 
    /// Add two tuples together. Note W should always be 0.0 or 1.0.
    /// </summary>
    public ATuple Add(ATuple b)
    {
        return new ATuple(X + b.X, Y + b.Y, Z + b.Z, W + b.W);
    }
    
    /// <summary> 
    /// Subtracts the second tuple from the first. Note W should always be 0.0 or 1.0.
    /// </summary>
    public ATuple Subtract(ATuple b)
    {
        return new ATuple(X - b.X, Y - b.Y, Z - b.Z, W - b.W);
    }
    
    /// <summary> 
    /// Negates a tuple. Note W is also negated.
    /// </summary>
    public ATuple Negate()
    {
        return new ATuple(-X, -Y, -Z, -W);
    }

    /// <summary> 
    /// Multiplies a tuple by a scalar. Note W is also multiplied.
    /// </summary>
    public ATuple Multiply(float scalar)
    {
        return new ATuple(X * scalar, Y * scalar, Z * scalar, W * scalar);
    }
    
    /// <summary> 
    /// Divides a tuple by a scalar. Note W is also divided.
    /// </summary>
    public ATuple Divide(float scalar)
    {
        return new ATuple(X / scalar, Y / scalar, Z / scalar, W / scalar);
    }

    /// <summary> 
    /// Takes the magnitude of a vector. Note this cannot be used on points!
    /// </summary>
    public float Magnitude()
    {
        var temp = System.Math.Pow(X, 2) + System.Math.Pow(Y, 2) + System.Math.Pow(Z, 2) + System.Math.Pow(W, 2);
        return (float) System.Math.Sqrt(temp);
    }

    /// <summary> 
    /// Returns the normal of a vector.
    /// </summary>
    public ATuple Normalize()
    {
        var magnitude = Magnitude();
        return new ATuple(X / magnitude, Y /magnitude, Z / magnitude, W / magnitude);
    }

    /// <summary> 
    /// Returns a scalar. The inner product of two tuples.
    /// </summary>
    public float DotProduct(ATuple b)
    {
        return (X * b.X) + (Y * b.Y) + (Z * b.Z) + (W * b.W);
    }
    
    /// <summary> 
    /// Returns a tuple. The cross product of two tuples.
    /// </summary>
    public ATuple CrossProduct(ATuple b)
    {
        return new ATuple((Y * b.Z) - (Z * b.Y), (Z * b.X) - (X * b.Z), (X * b.Y) - (Y * b.X), 0.0f);
    }

    /// <summary> 
    /// Compares two tuples for equality within 0.00001 precision.
    /// </summary>
    public bool Equals(ATuple b)
    {
        if (System.Math.Abs(X - b.X) > 0.00001f || System.Math.Abs(Y - b.Y) > 0.00001f )
        {
            return false;
        }
        if (System.Math.Abs(Z - b.Z) > 0.00001f || System.Math.Abs(W - b.W) > 0.00001f)
        {
            return false;
        }
        return true;
    }
    
    /// <summary> 
    /// Translates this tuple.
    /// </summary>
    public ATuple Translate(float x, float y, float z)
    {
        var tempMatrix = AMatrix4.TranslationMatrix4(x, y, z);
        return tempMatrix.Multiply(this);
    }

    /// <summary> 
    /// Scales this tuple.
    /// </summary>
    public ATuple Scale(float x, float y, float z)
    {
        var tempMatrix = AMatrix4.ScalingMatrix4(x, y, z);
        return tempMatrix.Multiply(this);
    }
    
    /// <summary> 
    /// Rotates this tuple across the X axis.
    /// </summary>
    public ATuple XRotate(double radians)
    {
        var tempMatrix = AMatrix4.XRotationMatrix4(radians);
        return tempMatrix.Multiply(this);
    }
    
    /// <summary> 
    /// Rotates this tuple across the Y axis.
    /// </summary>
    public ATuple YRotate(double radians)
    {
        var tempMatrix = AMatrix4.YRotationMatrix4(radians);
        return tempMatrix.Multiply(this);
    }
    
    /// <summary> 
    /// Rotates this tuple across the Z axis.
    /// </summary>
    public ATuple ZRotate(double radians)
    {
        var tempMatrix = AMatrix4.ZRotationMatrix4(radians);
        return tempMatrix.Multiply(this);
    }

    /// <summary> 
    /// Shears this tuple.
    /// </summary>
    public ATuple Shear(float xy, float xz, float yx, float yz, float zx, float zy)
    {
        var tempMatrix = AMatrix4.ShearMatrix4(xy, xz, yx, yz, zx, yz);
        return tempMatrix.Multiply(this);
    }
}