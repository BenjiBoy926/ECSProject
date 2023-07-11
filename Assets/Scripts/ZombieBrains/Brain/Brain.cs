using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ZombieBrains
{
    public struct Brain : IComponentData
    {
        public float Radius => _radius;

        [SerializeField]
        private float _radius;

        public Brain(float radius)
        {
            _radius = radius;
        }
    }
}
