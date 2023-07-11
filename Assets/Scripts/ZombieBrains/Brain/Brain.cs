using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

namespace ZombieBrains
{
    public struct Brain : IComponentData
    {
        public float3 Position => _position;
        public float Radius => _radius;

        [SerializeField]
        private float3 _position;
        [SerializeField]
        private float _radius;

        public Brain(float3 position, float radius)
        {
            _position = position;
            _radius = radius;
        }

        public bool Contains(float3 point, float margin)
        {
            return math.distance(point, _position) <= (_radius + margin);
        }
    }
}
