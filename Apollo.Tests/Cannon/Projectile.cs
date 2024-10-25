using System.Drawing;
using Apollo.Math;
using Apollo.Math.Objects;

namespace Apollo.Tests.Cannon;

public class Projectile(ATuple position, ATuple velocity)
{
    public ATuple Position { get; init; } = position;
    public ATuple Velocity { get; init; } = velocity;
}