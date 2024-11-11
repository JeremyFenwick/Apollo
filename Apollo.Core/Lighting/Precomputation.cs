using Apollo.Geometry.Interfaces;
using Apollo.Math.AbstractClasses;

namespace Apollo.Lighting;

public class Precomputation
{
    public double Time { get; }
    public IShape Object { get; }
    public AbstractTuple Point { get; }
    public AbstractTuple OverPoint { get; }
    public AbstractTuple EyeV { get; }
    public AbstractTuple NormalV { get; }
    public bool Inside { get; }

    public Precomputation(double time, IShape item, AbstractTuple point, AbstractTuple overPoint, AbstractTuple eyev,
        AbstractTuple normalV, bool inside)
    {
        (Time, Object, Point, OverPoint, EyeV, NormalV, Inside) = (time, item, point, overPoint, eyev, normalV, inside);
    }
}