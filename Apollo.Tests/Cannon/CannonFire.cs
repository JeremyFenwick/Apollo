namespace Apollo.Tests.Cannon;

public static class CannonFire
{
    public static Projectile Tick(Projectile proj, Environment env)
    {
        var position = proj.Position.Add(proj.Velocity);
        var velocity = proj.Velocity.Add(env.Gravity).Add(env.Wind);
        return new Projectile(position, velocity);
    }
}