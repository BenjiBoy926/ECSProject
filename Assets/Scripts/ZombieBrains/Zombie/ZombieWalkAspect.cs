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

        public void Walk(BrainAspect.Snapshot brain, TimeData current)
        {
            _transform.ValueRW.Position = NextPosition(brain, current);
            _transform.ValueRW.Rotation = NextRotation(brain, current);
        }
        private float3 NextPosition(BrainAspect.Snapshot brain, TimeData current)
        {
            LocalTransform transformRO = _transform.ValueRO;
            Zombie zombieRO = _zombie.ValueRO;
            return transformRO.Position + DirectionToBrain(brain) * zombieRO.WalkSpeed * current.DeltaTime; 
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
            float sway = zombieRO.SwayAmplitude * (float)math.sin(zombieRO.SwayFrequency * timerRO.TimeSince(current));
            float3 up = math.up() + transformRO.Right() * sway;
            return quaternion.LookRotation(DirectionToBrain(brain), up);
        }
        private float3 DirectionToBrain(BrainAspect.Snapshot brain)
        {
            float3 direction = brain.Position - _transform.ValueRO.Position;
            direction.y = 0;
            return math.normalize(direction);
        }
        public bool IsInStoppingRange(BrainAspect.Snapshot brain)
        {
            return brain.Contains(_transform.ValueRO.Position, _zombie.ValueRO.StoppingRange);
        }
    }
}
