using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ZombieBrains
{
    public readonly partial struct BrainAspect : IAspect
    {
        public struct Snapshot
        {
            public Entity Entity => _entity;
            public float3 Position => _transform.Position;
            internal float Radius => _brain.Radius;
            internal bool IsAlive => _brain.IsAlive;

            private Entity _entity;
            private LocalToWorld _transform;
            private Brain _brain;

            internal Snapshot(Entity entity, LocalToWorld transform, Brain brain)
            {
                _entity = entity;
                _transform = transform;
                _brain = brain;
            }

            public bool Contains(float3 point, float margin)
            {
                return math.distance(point, Position) <= (Radius + margin);
            }
        }

        public Entity Entity => _entity;
        public float3 Position => GetSnapshot().Position;
        public bool IsAlive => GetSnapshot().IsAlive;

        private readonly Entity _entity;
        private readonly RefRW<LocalToWorld> _transform;
        private readonly RefRW<Brain> _brain;
        private readonly DynamicBuffer<BrainDamageBufferElement> _damageBuffer;

        public Snapshot GetSnapshot()
        {
            return new Snapshot(_entity, _transform.ValueRO, _brain.ValueRO);
        }
        public bool Contains(float3 point, float margin)
        {
            return GetSnapshot().Contains(point, margin);
        }
        public void TakeBufferedDamage()
        {
            for (int i = 0; i < _damageBuffer.Length; i++)
            {
                _brain.ValueRW.TakeDamage(_damageBuffer[i].Damage);
            }
            _damageBuffer.Clear();
            SetScale(_brain.ValueRO.Scale);
        }
        private void SetScale(float3 scale)
        {
            float4x4 matrix = _transform.ValueRO.Value;
            for (int i = 0; i < 3; i++)
            {
                matrix[i][i] = scale[i];
            }
            _transform.ValueRW.Value = matrix;
        }
    }
}
