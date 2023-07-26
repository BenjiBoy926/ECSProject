using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ZombieBrains
{
    [System.Serializable]
    public struct Zombie : IComponentData
    {
        public float RiseSpeed => _riseSpeed;
        public float WalkSpeed => _walkSpeed;
        public float StoppingRange => _stoppingRange;

        public float SwayAmplitude => _swayAmplitude;
        public float SwayFrequency => _swayFrequency;

        public float EatDamagePerSecond => _eatDamagePerSecond;
        public float EatAmplitude => _eatAmplitude;
        public float EatFrequency => _eatFrequency;
        public float EatingRange => _eatingRange;

        [SerializeField]
        private float _riseSpeed;
        [SerializeField]
        private float _walkSpeed;
        [SerializeField]
        private float _stoppingRange;

        [Space]
        [SerializeField]
        private float _swayAmplitude;
        [SerializeField]
        private float _swayFrequency;

        [Space]
        [SerializeField]
        private float _eatDamagePerSecond;
        [SerializeField]
        private float _eatAmplitude;
        [SerializeField]
        private float _eatFrequency;
        [SerializeField]
        private float _eatingRange;

        public Zombie(float riseSpeed, 
            float walkSpeed,
            float stoppingRange,
            float swayAmplitude, 
            float swayFrequency,
            float eatDamagePerSecond,
            float eatAmplitude,
            float eatFrequency,
            float eatingRange)
        {
            _riseSpeed = riseSpeed;
            _walkSpeed = walkSpeed;
            _stoppingRange = stoppingRange;
            _swayAmplitude = swayAmplitude;
            _swayFrequency = swayFrequency;
            _eatDamagePerSecond = eatDamagePerSecond;
            _eatAmplitude = eatAmplitude;
            _eatFrequency = eatFrequency;
            _eatingRange = eatingRange;
        }
    }
}
