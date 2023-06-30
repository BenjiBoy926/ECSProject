using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieBrains
{
    public class TombstoneAuthor : MonoBehaviour
    {
        public GameObject ZombiePrefab => _zombiePrefab;
        public Vector3 ZombieSpawnLocalPosition => _zombieSpawnTransform != null ? _zombieSpawnTransform.localPosition : Vector3.zero;

        [SerializeField]
        private GameObject _zombiePrefab;
        [SerializeField]
        private Transform _zombieSpawnTransform;
    }
}
