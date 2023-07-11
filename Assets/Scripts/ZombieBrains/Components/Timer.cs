using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ZombieBrains
{
    public struct Timer : IComponentData
    {
        public bool IsRunning => _isRunning;
        public float TimeElapsed
        {
            get
            {
                if (!_isRunning)
                {
                    return 0;
                }
                return Time.time - _startTime;
            }
        }

        [SerializeField]
        private bool _isRunning;
        [SerializeField]
        private float _startTime;

        public void Start()
        {
            _isRunning = true;
            _startTime = Time.time;
        }
        public bool IsTimeElapsed(float time)
        {
            if (!_isRunning)
            {
                return false;
            }
            return TimeElapsed >= time;
        }
    }
}
