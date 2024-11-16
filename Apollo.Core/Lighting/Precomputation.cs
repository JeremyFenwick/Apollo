using Apollo.Geometry.Interfaces;
using Apollo.Math.AbstractClasses;

namespace Apollo.Lighting;

public class Precomputation
{
    public double Time { get; }
    public IShape Object { get; }
    public AbstractTuple Point { get; }
    public AbstractTuple OverPoint { get; }
    public AbstractTuple UnderPoint { get; }
    public AbstractTuple EyeV { get; }
    public AbstractTuple NormalV { get; }
    public AbstractTuple ReflectV { get; }
    public double N1 { get; }
    public double N2 { get; }
    public bool Inside { get; }

    public Precomputation(double time, IShape item, AbstractTuple point, AbstractTuple overPoint, AbstractTuple underPoint, AbstractTuple eyev,
        AbstractTuple normalV, bool inside, AbstractTuple reflectV, double n1, double n2)
    {
        Time = time;
        Object = item;
        Point = point;
        OverPoint = overPoint;
        UnderPoint = underPoint;
        EyeV = eyev;
        NormalV = normalV;
        Inside = inside;
        ReflectV = reflectV;
        N1 = n1;
        N2 = n2;
    }
}