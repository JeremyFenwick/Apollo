using Apollo.Geometry.Interfaces;

namespace Apollo.Rays.Objects;

public class Intersect : IComparable<Intersect>
{
    public Shape Object { get; }
    public float Location { get; }

    public Intersect(Shape shape, float location)
    {
        Object = shape;
        Location = location;
    }

    public int CompareTo(Intersect? other)
    {
        if (other == null) return 1;
        return (int) System.Math.Round(this.Location - other.Location, 0);
    }
}