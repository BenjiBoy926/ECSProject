using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ZombieBrains
{
    public readonly partial struct GraveyardAspect : IAspect
    {
        private readonly RefRO<Graveyard> _graveyard;
        private readonly RefRW<Timer> _timer;

        public void StartTimer()
        {
            _timer.ValueRW.Start();
        }
        public bool IsTimeToSpawnZombie()
        {
            return _timer.ValueRO.IsTimeElapsed(_graveyard.ValueRO.ZombieSpawnDelay);
        }
    }
}
