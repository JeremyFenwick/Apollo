using Apollo.Math;

namespace Apollo.Tests.Cannon;

public class Environment(ATuple gravity, ATuple wind)
{
    public ATuple Gravity { get; init; } = gravity;
    public ATuple Wind { get; init; } = wind;
}