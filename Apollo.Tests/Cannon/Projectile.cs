using System.Drawing;
using Apollo.Math;

namespace Apollo.Tests.Cannon;

public class Projectile(ATuple position, ATuple velocity)
{
    public ATuple Position { get; init; } = position;
    public ATuple Velocity { get; init; } = velocity;
}