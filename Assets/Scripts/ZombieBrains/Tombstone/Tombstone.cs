using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ZombieBrains
{
    public struct Tombstone : IComponentData
    {
        public Entity ZombiePrefab => _zombiePrefab;
        public float3 ZombieSpawnLocalPosition => _zombieSpawnLocalPosition;

        [SerializeField]
        private Entity _zombiePrefab;
        [SerializeField]
        private float3 _zombieSpawnLocalPosition;

        public Tombstone(Entity zombiePrefab, float3 zombieSpawnLocalPosition)
        {
            _zombiePrefab = zombiePrefab;
            _zombieSpawnLocalPosition = zombieSpawnLocalPosition;
        }
    }
}
