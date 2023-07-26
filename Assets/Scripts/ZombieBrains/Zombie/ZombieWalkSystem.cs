using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Core;
using Unity.Entities;
using UnityEditor.IMGUI.Controls;
using static Unity.Entities.SystemAPI;

namespace ZombieBrains
{
    [BurstCompile]
    public partial struct ZombieWalkSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<ZombieWalkTag>();
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
            BrainAspect.Snapshot brain = GetAspect<BrainAspect>(GetSingletonEntity<Brain>()).GetSnapshot();
            var commandWriter = GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(state.WorldUnmanaged)
                .AsParallelWriter();

            ZombieWalkJob job = new ZombieWalkJob();
            job.SetCurrentTime(Time);
            job.SetBrain(brain);
            job.SetCommandWriter(commandWriter);
            job.ScheduleParallel();
        }
    }

    [BurstCompile]
    public partial struct ZombieWalkJob : IJobEntity
    {
        private TimeData _currentTime;
        private BrainAspect.Snapshot _brain;
        private EntityCommandBuffer.ParallelWriter _commandWriter;

        public void SetCurrentTime(TimeData current)
        {
            _currentTime = current;
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
        private void Execute(ZombieWalkAspect zombie, [ChunkIndexInQuery] int sortKey)
        {
            zombie.Walk(_brain, _currentTime);
            if (zombie.IsInStoppingRange(_brain))
            {
                _commandWriter.RemoveComponent<ZombieWalkTag>(sortKey, zombie.Entity);
                _commandWriter.AddComponent<ZombieEatTag>(sortKey, zombie.Entity);
            }
        }
    }
}
