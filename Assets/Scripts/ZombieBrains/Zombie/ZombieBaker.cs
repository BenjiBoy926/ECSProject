using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ZombieBrains
{
    public class ZombieBaker : Baker<ZombieAuthor>
    {
        public override void Bake(ZombieAuthor authoring)
        {
            Entity zombie = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(zombie, new Zombie());
        }
    }
}
