using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ZombieBrains
{
    public class TombstoneBaker : Baker<TombstoneAuthor>
    {
        public override void Bake(TombstoneAuthor authoring)
        {
            Entity tombstoneEntity = GetEntity(TransformUsageFlags.Renderable);
            Entity zombiePrefabEntity = GetEntity(authoring.ZombiePrefab, TransformUsageFlags.Dynamic);
            Tombstone tombstone = new Tombstone(zombiePrefabEntity, authoring.ZombieSpawnLocalPosition);
            AddComponent(tombstoneEntity, tombstone);
        }
    }
}
