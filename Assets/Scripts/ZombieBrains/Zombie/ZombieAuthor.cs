using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieBrains
{
    public class ZombieAuthor : MonoBehaviour
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
        private float _brainMargin = 0.5f;
    }
}
