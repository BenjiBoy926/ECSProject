using Unity.Burst;
using Unity.Entities;
using Unity.Collections;
using Unity.Transforms;
using Unity.Mathematics;
using static Unity.Entities.SystemAPI;

namespace ZombieBrains
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct TombstoneSpawnSystem : ISystem
    {
        private const int RandomSeed = 1000;
        private const int MaxRandomPositionAttempts = 10;

        private Graveyard _graveyard;
        private BrainAspect _brain;
        private Ground _ground;
        private Random _random;
        private EntityCommandBuffer _commandBuffer;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<Graveyard>();
            state.RequireForUpdate<Brain>();
            state.RequireForUpdate<Ground>();
        }
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            SetupInstanceVariables(ref state);
            BufferAllNewTombstones();         
            _commandBuffer.Playback(state.EntityManager);

            state.Enabled = false;
        }

        private void SetupInstanceVariables(ref SystemState state)
        {
            _graveyard = GetSingleton<Graveyard>();
            _ground = GetSingleton<Ground>();
            _random = Random.CreateFromIndex(RandomSeed);
            _commandBuffer = new EntityCommandBuffer(Allocator.Temp);

            Entity brainEntity = GetSingletonEntity<Brain>();
            _brain = GetAspect<BrainAspect>(brainEntity);
        }
        private void BufferAllNewTombstones()
        {
            for (int i = 0; i < _graveyard.TotalTombstones; i++)
            {
                BufferNewTombstone();
            }
        }
        private void BufferNewTombstone()
        {
            Entity newTombstone = _commandBuffer.Instantiate(_graveyard.TombstonePrefab);
            LocalTransform newTransform = GetRandomTombstoneTransform();
            _commandBuffer.SetComponent(newTombstone, newTransform);
        }
        private LocalTransform GetRandomTombstoneTransform()
        {
            return new LocalTransform
            {
                Position = GetRandomTombstonePosition(),
                Rotation = GetRandomTombstoneRotation(),
                Scale = GetRandomTombstoneScale()
            };
        }
        private float3 GetRandomTombstonePosition()
        {
            int attempts = 0;
            float3 position;

            do
            {
                position = _random.NextFloat3(_ground.SurfaceMin, _ground.SurfaceMax);
                attempts++;
            } while(_brain.Contains(position) && attempts < MaxRandomPositionAttempts);

            return position;
        }
        private quaternion GetRandomTombstoneRotation()
        {
            float rotationY = _random.NextFloat(_graveyard.TombstoneRotationMin, _graveyard.TombstoneRotationMax);
            return quaternion.RotateY(rotationY);
        }
        private float GetRandomTombstoneScale()
        {
            return _random.NextFloat(_graveyard.TombstoneScaleMin, _graveyard.TombstoneScaleMax);
        }
    }
}
