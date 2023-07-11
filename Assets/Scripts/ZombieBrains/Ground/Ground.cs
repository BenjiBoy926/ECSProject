using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ZombieBrains
{
    public struct Ground : IComponentData
    {
        public float3 SurfaceMin => _surfaceMin;
        public float3 SurfaceMax => _surfaceMax;
        public float SurfaceY => _surfaceMax.y;

        [SerializeField]
        private float3 _surfaceMin;
        [SerializeField] 
        private float3 _surfaceMax;
    
        public Ground(Bounds bounds)
        {
            _surfaceMin = bounds.min;
            _surfaceMax = bounds.max;
        }
    }
}