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
}