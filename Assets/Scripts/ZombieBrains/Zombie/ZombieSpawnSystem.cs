using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Entities.SystemAPI;

namespace ZombieBrains
{
    [BurstCompile]
    public partial struct ZombieSpawnSystem : ISystem
    {
        private Random _random;
        private EntityQuery _tombstoneQuery;
        private TombstoneAspect _randomlySelectedTombstone;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<Graveyard>();
            state.RequireForUpdate<Tombstone>();
            state.RequireForUpdate<Brain>();

            _random = Random.CreateFromIndex(1000);
            _tombstoneQuery = new EntityQueryBuilder(Allocator.Temp)
                .WithAll<Tombstone>()
                .Build(ref state);
        }
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            if (!HasSingleton<Brain>())
            {
                state.Enabled = false;
                return;
            }
            Entity graveyardEntity = GetSingletonEntity<Graveyard>();
            GraveyardAspect graveyard = GetAspect<GraveyardAspect>(graveyardEntity);

            if (graveyard.IsTimeToSpawnZombie(Time))
            {
                SpawnZombie(ref state);
                graveyard.StartTimer(Time);
            }
        }
        
        private void SpawnZombie(ref SystemState state)
        {
            _randomlySelectedTombstone = GetRandomTombstone(ref state);
            EntityCommandBuffer commandBuffer = GetCommandBuffer(ref state);
            Entity newZombie = commandBuffer.Instantiate(_randomlySelectedTombstone.ZombiePrefab);
            commandBuffer.SetComponent(newZombie, new LocalTransform
            {
                Position = _randomlySelectedTombstone.ZombieSpawnPosition,
                Rotation = GetZombieRotation(ref state),
                Scale = _randomlySelectedTombstone.Scale
            });
        }
        private TombstoneAspect GetRandomTombstone(ref SystemState state)
        {
            NativeArray<Entity> tombstones = _tombstoneQuery.ToEntityArray(Allocator.Temp);
            int randomIndex = _random.NextInt(tombstones.Length);
            Entity randomEntity = tombstones[randomIndex];
            return GetAspect<TombstoneAspect>(randomEntity);
        }
        private EntityCommandBuffer GetCommandBuffer(ref SystemState state)
        {
            var bufferSystemSingleton = GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();
            return bufferSystemSingleton.CreateCommandBuffer(state.WorldUnmanaged);
        }
        private quaternion GetZombieRotation(ref SystemState state)
        {
            BrainAspect brain = GetAspect<BrainAspect>(GetSingletonEntity<Brain>());
            float3 toBrain = brain.Position - _randomlySelectedTombstone.ZombieSpawnPosition;
            toBrain.y = 0;
            return quaternion.LookRotation(toBrain, math.up());
        }
    }
}
