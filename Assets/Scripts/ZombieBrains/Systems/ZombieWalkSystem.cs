using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Core;
using Unity.Entities;
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
        }
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            ZombieWalkJob job = new ZombieWalkJob();
            job.SetCurrentTime(Time);
            job.ScheduleParallel();
        }
    }

    [BurstCompile]
    public partial struct ZombieWalkJob : IJobEntity
    {
        private TimeData _current;

        public void SetCurrentTime(TimeData current)
        {
            _current = current;
        }

        [BurstCompile]
        private void Execute(ZombieWalkAspect zombie)
        {
            zombie.Walk(_current);
        }
    }
}
