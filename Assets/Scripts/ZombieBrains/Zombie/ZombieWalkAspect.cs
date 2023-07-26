using Unity.Core;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ZombieBrains
{
    public readonly partial struct ZombieWalkAspect : IAspect
    {
        public readonly Entity Entity;

        private readonly RefRW<LocalTransform> _transform;
        private readonly RefRO<Zombie> _zombie;
        private readonly RefRO<ZombieWalkTag> _tag;
        private readonly RefRW<Timer> _timer;

        public void Walk(TimeData current)
        {
            _transform.ValueRW.Position = NextPosition(current);
            _transform.ValueRW.Rotation = NextRotation(current);
        }
        private float3 NextPosition(TimeData current)
        {
            LocalTransform transformRO = _transform.ValueRO;
            Zombie zombieRO = _zombie.ValueRO;
            return transformRO.Position + transformRO.Forward() * zombieRO.WalkSpeed * current.DeltaTime; 
        }
        private quaternion NextRotation(TimeData current)
        {
            LocalTransform transformRO = _transform.ValueRO;
            Zombie zombieRO = _zombie.ValueRO;
            Timer timerRO = _timer.ValueRO;

            if (!timerRO.IsRunning)
            {
                _timer.ValueRW.Start(current);
            }
            float sway = zombieRO.SwayAmplitude * (float)math.sin(zombieRO.SwayFrequency * timerRO.TimeSince(current));
            float3 up = math.up() + transformRO.Right() * sway;
            return quaternion.LookRotation(transformRO.Forward(), up);
        }
        public bool IsInStoppingRange(BrainAspect.Snapshot brain)
        {
            return brain.Contains(_transform.ValueRO.Position, _zombie.ValueRO.StoppingRange);
        }
    }
}
