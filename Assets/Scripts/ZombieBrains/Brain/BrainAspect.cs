
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ZombieBrains
{
    public readonly partial struct BrainAspect : IAspect
    {
        public float3 Position => _localToWorldMatrix.ValueRO.Position;

        private readonly RefRO<LocalToWorld> _localToWorldMatrix;
        private readonly RefRO<Brain> _brain;
    }
}
