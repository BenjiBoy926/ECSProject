using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ZombieBrains
{
    public struct Timer : IComponentData
    {
        public float TimeElapsed => Time.time - _startTime;

        [SerializeField]
        private float _startTime;

        public void Start()
        {
            _startTime = Time.time;
        }
        public bool IsTimeElapsed(float time)
        {
            return TimeElapsed >= time;
        }
    }
}
