using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ZombieBrains
{
    public readonly partial struct ZombieRiseAspect : IAspect
    {
        public readonly Entity Entity;
        private readonly RefRW<LocalTransform> _transform;
        private readonly RefRO<Zombie> _zombie;
        private readonly RefRO<ZombieRiseTag> _tag;

        public void Rise(float delta)
        {
            _transform.ValueRW.Position += math.up() * _zombie.ValueRO.RiseSpeed * delta;
        }
        public bool IsRisenAbove(float level)
        {
            return _transform.ValueRO.Position.y >= level;
        }
        public void SetRiseLevel(float level)
        {
            _transform.ValueRW.Position.y = level;
        }
    }
}
