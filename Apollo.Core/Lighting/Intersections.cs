using Apollo.Geometry.Interfaces;

namespace Apollo.Lighting;

public class Intersections
{
    public List<Intersect> Intersects { get; }

    public Intersections()
    {
        Intersects = [];
    }
    
    public Intersections(Intersect first, Intersect second)
    {
        Intersects = [first, second];
    }

    public Intersections(Intersect first)
    {
        Intersects = [first];
    }

    public Intersections(Intersect[] intersects)
    {
        Intersects = new List<Intersect>(intersects);
    }
    
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
}