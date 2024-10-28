namespace Apollo.Rays.Objects;

public class Intersect
{
    public bool Intersected { get; }
    public float LocationOne { get; }
    public float LocationTwo { get; }

    public Intersect(bool intersected, float locationOne, float locationTwo)
    {
        Intersected = intersected;
        LocationOne = locationOne;
        LocationTwo = locationTwo;
    }
}