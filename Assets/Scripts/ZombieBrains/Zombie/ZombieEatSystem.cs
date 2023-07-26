using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Core;
using Unity.Entities;
using static Unity.Entities.SystemAPI;

namespace ZombieBrains
{
    [BurstCompile]
    public partial struct ZombieEatSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<ZombieEatTag>();
            state.RequireForUpdate<Brain>();
        }
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var commandSingleton = GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();
            var commandWriter = commandSingleton.CreateCommandBuffer(state.WorldUnmanaged).AsParallelWriter();
            var brain = GetAspect<BrainAspect>(GetSingletonEntity<Brain>()).GetSnapshot();

            ZombieEatJob job = new ZombieEatJob();
            job.SetCurrentTime(Time);
            job.SetBrain(brain);
            job.SetCommandWriter(commandWriter);
            job.ScheduleParallel();
        }
    }

    [BurstCompile]
    public partial struct ZombieEatJob : IJobEntity
    {
        private TimeData _currentTime;
        private BrainAspect.Snapshot _brain;
        private EntityCommandBuffer.ParallelWriter _commandWriter;
        
        public void SetCurrentTime(TimeData currentTime)
        {
            _currentTime = currentTime;
        }
        public void SetBrain(BrainAspect.Snapshot brain)
        {
            _brain = brain;
        }
        public void SetCommandWriter(EntityCommandBuffer.ParallelWriter commandWriter)
        {
            _commandWriter = commandWriter;
        }

        [BurstCompile]
        private void Execute(ZombieEatAspect zombie, [ChunkIndexInQuery] int sortKey)
        {
            float eatDamage = zombie.Eat(_brain, _currentTime);
            _commandWriter.AppendToBuffer(sortKey, _brain.Entity, new BrainDamageBufferElement(eatDamage));
        }
    }
}
