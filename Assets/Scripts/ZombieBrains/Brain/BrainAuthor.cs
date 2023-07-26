using Unity.Transforms;
using UnityEngine;

namespace ZombieBrains
{
    public class BrainAuthor : MonoBehaviour
    {
        public float Radius
        {
            get
            {
                if (_collider == null)
                {
                    return 0;
                }
                Vector3 lossyScale = _collider.transform.localScale;
                float maxScaleComponent = lossyScale[0];
                for (int i = 1; i < 3; i++)
                {
                    if (lossyScale[i] > maxScaleComponent)
                    {
                        maxScaleComponent = lossyScale[i];
                    }
                }
                return _collider.radius * maxScaleComponent;
            }
        }
        public float MaxHealth => _maxHealth;

        [SerializeField]
        private SphereCollider _collider;
        [SerializeField]
        private float _maxHealth;
    }
}
