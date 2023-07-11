using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ZombieBrains
{
    public struct Graveyard : IComponentData
    {
        public int TotalTombstones => _totalTombstones;
        public float TombstoneRotationMin => _tombstoneRotation.x;
        public float TombstoneRotationMax => _tombstoneRotation.y;
        public float TombstoneScaleMin => _tombstoneScale.x;
        public float TombstoneScaleMax => _tombstoneScale.y;
        public float TombstoneBrainMargin => _tombstoneBrainMargin;
        public Entity TombstonePrefab => _tombstonePrefab;
        public float ZombieSpawnDelay => _zombieSpawnDelay;

        [SerializeField]
        private int _totalTombstones;
        [SerializeField]
        private float2 _tombstoneRotation;
        [SerializeField]
        private float2 _tombstoneScale;
        [SerializeField]
        private float _tombstoneBrainMargin;
        [SerializeField]
        private Entity _tombstonePrefab;
        [SerializeField]
        private float _zombieSpawnDelay;

        public Graveyard(int totalTombstones, 
            float2 tombstoneRotation,
            float2 tombstoneScale,
            float tombstoneBrainMargin,
            Entity tombstonePrefab,
            float zombieSpawnDelay)
        {
            _totalTombstones = totalTombstones;
            _tombstoneRotation = tombstoneRotation;
            _tombstoneScale = tombstoneScale;
            _tombstoneBrainMargin = tombstoneBrainMargin;
            _tombstonePrefab = tombstonePrefab;
            _zombieSpawnDelay = zombieSpawnDelay;
        }
    }
}
