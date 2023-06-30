using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using static Unity.Entities.SystemAPI;

[BurstCompile]
public partial struct SphereSpawnsCapsuleSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<Sphere>();
    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        Sphere sphere = GetSingleton<Sphere>();
        EntityCommandBuffer commandBuffer = new EntityCommandBuffer(TestConstants.CommandBufferAllocator);
        Entity capsule = commandBuffer.Instantiate(sphere.CapsulePrefab);
        commandBuffer.SetComponent(capsule, new LocalTransform
        {
            Position = Vector3.right * 4f
        });
        commandBuffer.Playback(state.EntityManager);

        state.Enabled = false;
    }
}
