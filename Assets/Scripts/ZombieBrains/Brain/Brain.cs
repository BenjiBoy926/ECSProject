using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

namespace ZombieBrains
{
    public struct Brain : IComponentData
    {
        public float Radius => _radius;
        public float3 Scale => HealthPercent * _initialScale;
        private float HealthPercent => _currentHealth / _maxHealth;

        [SerializeField]
        private float _radius;
        [SerializeField]
        private float _currentHealth;
        [SerializeField]
        private float _maxHealth;
        [SerializeField]
        private float3 _initialScale;

        public Brain(float radius, float maxHealth, float3 initialScale)
        {
            _radius = radius;
            _currentHealth = maxHealth;
            _maxHealth = maxHealth;
            _initialScale = initialScale;
        }
        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
        }
    }
}
