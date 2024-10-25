using Apollo.Math;
using Apollo.Math.Objects;

namespace Apollo.Tests.Cannon;

public class FEnvironment(ATuple gravity, ATuple wind)
{
    public ATuple Gravity { get; init; } = gravity;
    public ATuple Wind { get; init; } = wind;
}