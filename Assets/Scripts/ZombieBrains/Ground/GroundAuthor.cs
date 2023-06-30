using UnityEngine;

namespace ZombieBrains
{
    public class GroundAuthor : MonoBehaviour
    {
        public Bounds Surface
        {
            get
            {
                if (_collider == null)
                {
                    return new Bounds();
                }

                Bounds bounds = _collider.bounds;
                Vector3 center = bounds.center + Vector3.up * bounds.extents.y;
                Vector3 size = new Vector3(bounds.size.x, 0, bounds.size.z);
                return new Bounds(center, size);
            }
        }

        [SerializeField]
        private Collider _collider;
    }
}