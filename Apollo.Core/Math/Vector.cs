﻿using Apollo.Math.AbstractClasses;

namespace Apollo.Math;

public class Vector : AbstractTuple
{
    public override float W { get; } = 0;

    public Vector(float x, float y, float z) : base(x, y, z)
    {
    }
    
    public Vector(AbstractTuple tuple) : base(tuple)
    {
    }
}