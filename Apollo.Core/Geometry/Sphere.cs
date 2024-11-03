using Apollo.Geometry.Interfaces;
using Apollo.Math;

namespace Apollo.Geometry;

public class Sphere : GeometricObject
{
    public Matrix Transform { get; set; }
    
    public Sphere()
    {
        Transform = Matrix.Identity();
    }
}