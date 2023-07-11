using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ZombieBrains
{
    public class GraveyardAuthor : MonoBehaviour
    {
        public int TotalTombstones => _totalTombstones;
        public Vector2 TombstoneRotation => _tombstoneRotation;
        public Vector2 TombstoneScale => _tombstoneScale;
        public float TombstoneBrainMargin => _tombstoneBrainMargin;
        public GameObject TombstonePrefab => _tombstonePrefab;
        public float ZombieSpawnDelay => _zombieSpawnDelay;

        [SerializeField]
        private int _totalTombstones = 250;
        [SerializeField]
        private Vector2 _tombstoneRotation = new Vector2(-0.25f, 0.25f);
        [SerializeField]
        private Vector2 _tombstoneScale = new Vector2(0.5f, 1.5f);
        [SerializeField]
        private float _tombstoneBrainMargin = 5;
        [SerializeField]
        private GameObject _tombstonePrefab;
        [SerializeField]
        private float _zombieSpawnDelay = 0.5f;
    }
}

