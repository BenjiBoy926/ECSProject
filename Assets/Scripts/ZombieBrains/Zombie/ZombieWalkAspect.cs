using Unity.Core;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ZombieBrains
{
    public readonly partial struct ZombieWalkAspect : IAspect
    {
        private readonly RefRW<LocalTransform> _transform;
        private readonly RefRO<Zombie> _zombie;
        private readonly RefRO<ZombieWalkTag> _tag;
        private readonly RefRW<Timer> _timer;

        public void Walk(TimeData current)
        {
            LocalTransform transformRO = _transform.ValueRO;
            Zombie zombieRO = _zombie.ValueRO;
            Timer timerRO = _timer.ValueRO;
            float3 forward = transformRO.Forward();

            _transform.ValueRW.Position += forward * zombieRO.WalkSpeed * current.DeltaTime;

            if (!timerRO.IsRunning)
            {
                _timer.ValueRW.Start(current);
            }
            float sway = zombieRO.SwayAmplitude * (float)math.sin(zombieRO.SwayFrequency * timerRO.TimeSince(current));
            float3 up = math.up() + transformRO.Right() * sway;
            _transform.ValueRW.Rotation = quaternion.LookRotation(forward, up);
        }
    }
}
