using Unity.Core;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ZombieBrains
{
    public readonly partial struct ZombieEatAspect : IAspect
    {
        public readonly Entity Entity;

        private readonly RefRW<LocalTransform> _transform;
        private readonly RefRO<Zombie> _zombie;
        private readonly RefRO<ZombieEatTag> _tag;
        private readonly RefRW<Timer> _timer;
    }
}
