using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ZombieBrains
{
    public struct Brain : IComponentData
    {
        [SerializeField]
        private float3 _boundsMin;
        [SerializeField] 
        private float3 _boundsMax;

        public Brain(Bounds bounds)
        {
            _boundsMin = bounds.min;
            _boundsMax = bounds.max;
        }

        public bool Contains(float3 p)
        {
            return Contains(p, 0) && Contains(p, 1) && Contains(p, 2);
        }
        private bool Contains(float3 p, int dimension)
        {
            return p[dimension] >= _boundsMin[dimension] && p[dimension] <= _boundsMax[dimension];
        }
    }
}
