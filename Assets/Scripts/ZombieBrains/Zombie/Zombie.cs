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
        public float SwayAmplitude => _swayAmplitude;
        public float SwayFrequency => _swayFrequency;
        public float EatDamagePerSecond => _eatDamagePerSecond;
        public float EatAmplitude => _eatAmplitude;
        public float EatFrequency => _eatFrequency;
        public float BrainMargin => _brainMargin;

        [SerializeField]
        private float _riseSpeed;
        [SerializeField]
        private float _walkSpeed;
        [SerializeField]
        private float _swayAmplitude;
        [SerializeField]
        private float _swayFrequency;
        [SerializeField]
        private float _eatDamagePerSecond;
        [SerializeField]
        private float _eatAmplitude;
        [SerializeField]
        private float _eatFrequency;
        [SerializeField]
        private float _brainMargin;

        public Zombie(float riseSpeed, 
            float walkSpeed, 
            float swayAmplitude, 
            float swayFrequency,
            float eatDamagePerSecond,
            float eatAmplitude,
            float eatFrequency,
            float brainMargin)
        {
            _riseSpeed = riseSpeed;
            _walkSpeed = walkSpeed;
            _swayAmplitude = swayAmplitude;
            _swayFrequency = swayFrequency;
            _eatDamagePerSecond = eatDamagePerSecond;
            _eatAmplitude = eatAmplitude;
            _eatFrequency = eatFrequency;
            _brainMargin = brainMargin;
        }
    }
}
