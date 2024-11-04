using Apollo.Geometry.Interfaces;
using Apollo.Lighting;
using Apollo.Math;
using Apollo.Math.AbstractClasses;

namespace Apollo.Geometry;

public class Sphere : GeometricObject
{
    public Matrix Transform { get; set; }
    public Material Material { get; set; }

    public Sphere()
    {
        Transform = Matrix.Identity();
        Material = new Material();
    }

    public AbstractTuple NormalAt(Point p)
    {
        var objectPoint = this.Transform.Inverse() * p;
        var objectNormal = objectPoint - new Point(0,0,0);
        var worldNormal = (this.Transform.Inverse().Transpose()) * objectNormal;
        var vector = new Vector(worldNormal).Normalize();
        return vector;
    }

}