using Apollo.Lighting;
using Apollo.Math;
using Apollo.Math.AbstractClasses;

namespace Apollo.Geometry.Interfaces;

public interface GeometricObject
{
    public Material Material { get; set; }
    public Matrix Transform { get; set; }
    public AbstractTuple NormalAt(Point p);
}