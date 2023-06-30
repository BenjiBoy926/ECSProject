using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

namespace ZombieBrains
{
    public readonly partial struct TombstoneAspect : IAspect
    {
        public Entity ZombiePrefab => _tombstone.ValueRO.ZombiePrefab;
        public float3 ZombieSpawnPosition => _transform.ValueRO.TransformPoint(_tombstone.ValueRO.ZombieSpawnLocalPosition);

        private readonly RefRO<LocalTransform> _transform;
        private readonly RefRO<Tombstone> _tombstone;
    }
}
