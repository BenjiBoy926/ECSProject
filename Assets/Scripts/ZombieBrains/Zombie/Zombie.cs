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
        private float _brainMargin;

        public Zombie(float riseSpeed, float walkSpeed, float swayAmplitude, float swayFrequency, float brainMargin)
        {
            _riseSpeed = riseSpeed;
            _walkSpeed = walkSpeed;
            _swayAmplitude = swayAmplitude;
            _swayFrequency = swayFrequency;
            _brainMargin = brainMargin;
        }
    }
}
