using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ZombieBrains
{
    public class GraveyardBaker : Baker<GraveyardAuthor>
    {
        public override void Bake(GraveyardAuthor authoring)
        {
            Entity graveyardEntity = GetEntity(TransformUsageFlags.None);
            Entity tombstonePrefabEntity = GetEntity(authoring.TombstonePrefab, TransformUsageFlags.Renderable);
            Graveyard graveyard = new Graveyard(
                authoring.TotalTombstones,
                authoring.TombstoneRotation,
                authoring.TombstoneScale,
                authoring.TombstoneBrainMargin,
                tombstonePrefabEntity,
                authoring.ZombieSpawnDelay);
            AddComponent(graveyardEntity, graveyard);
            AddComponent(graveyardEntity, new Timer());
        }
    }
}
