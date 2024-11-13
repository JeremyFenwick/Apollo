using Apollo.Display.AbstractClasses;
using Apollo.Lighting;
using Apollo.Math;
using Apollo.Math.AbstractClasses;

namespace Apollo.Geometry.Interfaces;

public interface IShape
{
    public Material Material { get; set; }
    public Matrix Transform { get; set; }
    public AbstractTuple NormalAt(Point p);
    public Intersections Intersect(Ray ray);
    public AbstractColour ColourAt(AbstractTuple p);
}