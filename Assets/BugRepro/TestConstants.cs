using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public class TestConstants
{
    public const TransformUsageFlags TransformUsage = TransformUsageFlags.Renderable;
    public const Allocator CommandBufferAllocator = Allocator.Temp;
}
