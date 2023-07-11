using System.Collections;
using System.Collections.Generic;
using Unity.Core;
using Unity.Entities;
using UnityEngine;

namespace ZombieBrains
{
    public struct Timer : IComponentData
    {
        public bool IsRunning => _isRunning;

        [SerializeField]
        private bool _isRunning;
        [SerializeField]
        private double _startTime;

        public void Start(TimeData timeData)
        {
            _isRunning = true;
            _startTime = timeData.ElapsedTime;
        }
        public double TimeSince(TimeData timeData)
        {
            if (!_isRunning)
            {
                return 0;
            }
            return timeData.ElapsedTime - _startTime;
        }
        public bool IsTimeElapsed(TimeData current, double elapsed)
        {
            if (!_isRunning)
            {
                return false;
            }
            return TimeSince(current) >= elapsed;
        }
    }
}
