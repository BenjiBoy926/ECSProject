using UnityEngine;

namespace ZombieBrains
{
    public class BrainAuthor : MonoBehaviour
    {
        public Bounds Bounds
        {
            get
            {
                if (_collider != null)
                {
                    Bounds bounds = _collider.bounds;
                    return new Bounds(bounds.center, bounds.size * 2f);
                }
                return new Bounds();
            }
        }

        [SerializeField]
        private Collider _collider;
    }
}
