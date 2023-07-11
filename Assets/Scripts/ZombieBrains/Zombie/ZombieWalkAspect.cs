using System.Collections;
using System.Collections.Generic;
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

        public void Walk(float delta)
        {
            LocalTransform transformRO = _transform.ValueRO;
            Zombie zombieRO = _zombie.ValueRO;
            Timer timerRO = _timer.ValueRO;
            float3 forward = transformRO.Forward();

            _transform.ValueRW.Position += forward * zombieRO.WalkSpeed * delta;

            //if (!timerRO.IsRunning)
            //{
            //    _timer.ValueRW.Start();
            //}
            //float swayAngle = zombieRO.SwayAmplitude * math.sin(zombieRO.SwayFrequency * timerRO.TimeElapsed);
            //_transform.ValueRW.Rotation = quaternion.AxisAngle(forward, swayAngle);
        }
    }
}
