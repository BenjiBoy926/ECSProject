using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieBrains
{
    public class ZombieAuthor : MonoBehaviour
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
        private float _stoppingRange = 0.5f;

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
        private float _eatingRange = 1;
    }
}
