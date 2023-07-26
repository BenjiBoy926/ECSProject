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
            GetAspect<BrainAspect>(GetSingletonEntity<Brain>()).TakeBufferedDamage();
        }
    }
}
