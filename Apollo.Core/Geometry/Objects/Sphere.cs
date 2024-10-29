using Apollo.Geometry.Interfaces;
using Apollo.Math.Objects;

namespace Apollo.Geometry.Objects;

public class Sphere : Shape
{
    public AMatrix4 Transform { get; set;  }
    
    public Sphere()
    {
        Transform = AMatrix4.IdentityMatrix4();
    }
}