using Apollo.Geometry.Interfaces;

namespace Apollo.Lighting;

public class Intersect : IComparable<Intersect>
{
    public GeometricObject Object { get; }
    public float Time { get; }

    public Intersect(GeometricObject obj, float time)
    {
        (Object, Time) = (obj, time);
    }

    public int CompareTo(Intersect? other)
    {
        if (other == null || this.Time > other.Time)
        {
            return 1;
        }
        else if (this.Time < other.Time)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}