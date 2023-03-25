using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace flat_land.runner
{
    public class Chunk : MonoBehaviour
    {
        [SerializeField] ChunkEvent enterCollider;
        [SerializeField] ChunkEvent exitCollider;

        public event Action onPLayerEnterChunk;
        public event Action onPLayerExitChunk;

        public event Action onPlayerHit;

        float chunckSize;

        public Transform Start { get => enterCollider.transform; }
        public Transform End { get => exitCollider.transform; }

        private void Awake()
        {
            enterCollider.onTriggerCollider += () => onPLayerEnterChunk?.Invoke();
            exitCollider.onTriggerCollider += () => onPLayerExitChunk?.Invoke();

            GetComponentsInChildren<Death>().ToList().ForEach(d =>
            {
                d.onPlayerHit += () => onPlayerHit?.Invoke();
            });

            CalculateSize();
        }

        private void CalculateSize()
        {
            chunckSize = Vector3.Distance(End.position, Start.position);    
        }

        public float GetSpawnOffset()
        {
            return chunckSize / 2;
        }

        internal void SetPosition(Transform end)
        {
            transform.position = (Vector2)end.position + Vector2.right * GetSpawnOffset();
        }
    }
}

