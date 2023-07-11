
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ZombieBrains
{
    public readonly partial struct BrainAspect : IAspect
    {
        public float3 Position => _transform.ValueRO.Position;

        private readonly RefRO<LocalToWorld> _transform;
        private readonly RefRO<Brain> _brain;

        public bool Contains(float3 point)
        {
            float3 toPoint = point - _transform.ValueRO.Position;
            return math.length(toPoint) <= _brain.ValueRO.Radius;
        }
    }
}
