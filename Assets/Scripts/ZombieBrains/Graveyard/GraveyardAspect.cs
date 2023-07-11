using System.Collections;
using System.Collections.Generic;
using Unity.Core;
using Unity.Entities;
using UnityEngine;

namespace ZombieBrains
{
    public readonly partial struct GraveyardAspect : IAspect
    {
        private readonly RefRO<Graveyard> _graveyard;
        private readonly RefRW<Timer> _timer;

        public void StartTimer(TimeData current)
        {
            _timer.ValueRW.Start(current);
        }
        public bool IsTimeToSpawnZombie(TimeData current)
        {
            if (!_timer.ValueRO.IsRunning)
            {
                StartTimer(current);
            }
            return _timer.ValueRO.IsTimeElapsed(current, _graveyard.ValueRO.ZombieSpawnDelay);
        }
    }
}
