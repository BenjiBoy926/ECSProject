using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using static Unity.Entities.SystemAPI;

[BurstCompile]
public partial struct CubeSpawnsSphereSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<Cube>();
    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        Cube cube = GetSingleton<Cube>();
        EntityCommandBuffer commandBuffer = new EntityCommandBuffer(TestConstants.CommandBufferAllocator);
        Entity sphere = commandBuffer.Instantiate(cube.SpherePrefab);
        commandBuffer.SetComponent(sphere, new LocalTransform
        {
            Position = Vector3.right * 2f
        });
        commandBuffer.Playback(state.EntityManager);

        state.Enabled = false;
    }
}
