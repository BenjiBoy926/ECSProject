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

        public float Eat(BrainAspect.Snapshot brain, TimeData current)
        {
            _transform.ValueRW.Rotation = NextRotation(brain, current);
            return _zombie.ValueRO.EatDamagePerSecond * current.DeltaTime;
        }
        private quaternion NextRotation(BrainAspect.Snapshot brain, TimeData current)
        {
            LocalTransform transformRO = _transform.ValueRO;
            Zombie zombieRO = _zombie.ValueRO;
            Timer timerRO = _timer.ValueRO;

            if (!timerRO.IsRunning)
            {
                _timer.ValueRW.Start(current);
            }
            float sway = zombieRO.EatAmplitude * (float)math.sin(zombieRO.EatFrequency * timerRO.TimeSince(current));
            float3 forward = brain.Position - transformRO.Position + math.up() * sway;
            return quaternion.LookRotation(forward, math.up());
        }
        public bool IsInEatingRange(BrainAspect.Snapshot brain)
        {
            return brain.Contains(_transform.ValueRO.Position, _zombie.ValueRO.EatingRange);
        }
    }
}
