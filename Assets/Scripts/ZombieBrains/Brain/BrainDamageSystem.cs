using Unity.Burst;
using Unity.Entities;
using static Unity.Entities.SystemAPI;

namespace ZombieBrains
{
    [BurstCompile]
    [UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
    [UpdateAfter(typeof(EndSimulationEntityCommandBufferSystem))]
    public partial struct BrainDamageSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<Brain>();
        }
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            if (!HasSingleton<Brain>())
            {
                state.Enabled = false;
                return;
            }

            BrainAspect brain = GetAspect<BrainAspect>(GetSingletonEntity<Brain>());
            brain.TakeBufferedDamage();
            if (!brain.IsAlive)
            {
                EntityCommandBuffer commandBuffer = GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
                commandBuffer.DestroyEntity(brain.Entity);
            }
        }
    }
}
