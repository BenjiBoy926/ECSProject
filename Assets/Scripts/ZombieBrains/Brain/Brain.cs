using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

namespace ZombieBrains
{
    public struct Brain : IComponentData
    {
        public float Radius => HealthPercent * _initialRadius;
        public float3 Scale => HealthPercent * _initialScale;
        private float HealthPercent => _currentHealth / _maxHealth;

        [SerializeField]
        private float _initialRadius;
        [SerializeField]
        private float3 _initialScale;
        [SerializeField]
        private float _currentHealth;
        [SerializeField]
        private float _maxHealth;

        public Brain(float initialRadius, float3 initialScale, float maxHealth)
        {
            _initialRadius = initialRadius;
            _initialScale = initialScale;
            _currentHealth = maxHealth;
            _maxHealth = maxHealth;
        }
        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
        }
    }
}
