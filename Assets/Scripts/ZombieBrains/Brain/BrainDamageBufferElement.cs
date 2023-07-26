using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ZombieBrains
{
    public struct BrainDamageBufferElement : IBufferElementData
    {
        public float Damage => _damage;

        [SerializeField]
        private float _damage;

        public BrainDamageBufferElement(float damage)
        {
            _damage = damage;
        }
    }
}
