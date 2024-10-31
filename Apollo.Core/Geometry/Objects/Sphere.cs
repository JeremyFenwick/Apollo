using System.ComponentModel.DataAnnotations.Schema;
using Apollo.Geometry.Interfaces;
using Apollo.Lighting.Objects;
using Apollo.Math;
using Apollo.Math.Objects;

namespace Apollo.Geometry.Objects;

/// <summary> 
/// Creates a sphere with its associated transform matrix. By default, this is the identity matrix.
/// </summary>
public class Sphere : Shape
{
    public AMatrix4 Transform { get; set;  }
    public Material Material { get; set; } 
    
    public Sphere()
    {
        Transform = AMatrix4.IdentityMatrix4();
        Material = new Material();
    }

    /// <summary> 
    /// Returns the normal (vector perpendicular to the surface) of a point on this sphere.
    /// </summary>
    public ATuple NormalAt(ATuple point)
    {
        var iTransform = Transform.Inverse();
        var objectPoint = Transform.Inverse().Multiply(point);
        var objectNormal = objectPoint.Subtract(MathFactory.Point(0, 0, 0));
        var worldNormal = Transform.Inverse().Transpose().Multiply(objectNormal);
        // This last line is a hack to force W to be zero, as transposing can move it off zero
        return MathFactory.Vector(worldNormal.X, worldNormal.Y, worldNormal.Z).Normalize();
        // return point.Subtract(MathFactory.Point(0, 0, 0)).Normalize();
    }
}