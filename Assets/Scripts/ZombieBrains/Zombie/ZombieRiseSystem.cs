using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using static Unity.Entities.SystemAPI;

namespace ZombieBrains
{
    [BurstCompile]
    public partial struct ZombieRiseSystem : ISystem
    {
        private Ground _ground;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<Ground>();
            state.RequireForUpdate<ZombieRiseTag>();
        }
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var commandWriter = GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(state.WorldUnmanaged)
                .AsParallelWriter();

            ZombieRiseJob job = new ZombieRiseJob();
            job.SetDelta(Time.DeltaTime);
            job.SetGroundLevel(GetSingleton<Ground>().SurfaceY);
            job.SetCommandWriter(commandWriter);
            job.ScheduleParallel();
        }
    }

    [BurstCompile]
    public partial struct ZombieRiseJob : IJobEntity
    {
        private float _delta;
        private float _groundLevel;
        private EntityCommandBuffer.ParallelWriter _commandWriter;

        public void SetDelta(float delta)
        {
            _delta = delta;
        }
        public void SetGroundLevel(float groundLevel)
        {
            _groundLevel = groundLevel;
        }
        public void SetCommandWriter(EntityCommandBuffer.ParallelWriter commandWriter)
        {
            _commandWriter = commandWriter;
        }

        [BurstCompile]
        private void Execute(ZombieRiseAspect zombie, [ChunkIndexInQuery] int sortKey)
        {
            zombie.Rise(_delta);

            if (zombie.IsRisenAbove(_groundLevel))
            {
                zombie.SetRiseLevel(_groundLevel);
                _commandWriter.RemoveComponent<ZombieRiseTag>(sortKey, zombie.Entity);
                _commandWriter.AddComponent<ZombieWalkTag>(sortKey, zombie.Entity);
            }
        }
    }
}
