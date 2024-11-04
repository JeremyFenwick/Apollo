using Apollo.Lighting;
using Apollo.Math;

namespace Apollo.Geometry.Interfaces;

public interface GeometricObject
{
    public Material Material { get; set; }
    public Matrix Transform { get; set; }
}