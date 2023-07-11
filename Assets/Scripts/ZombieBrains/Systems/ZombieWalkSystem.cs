using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
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
            job.SetDelta(Time.DeltaTime);
            job.ScheduleParallel();
        }
    }

    [BurstCompile]
    public partial struct ZombieWalkJob : IJobEntity
    {
        private float _delta;

        public void SetDelta(float delta)
        {
            _delta = delta;
        }

        [BurstCompile]
        private void Execute(ZombieWalkAspect zombie)
        {
            zombie.Walk(_delta);
        }
    }
}
