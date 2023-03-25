using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flat_land.runner
{
    public class ChunkEvent : MonoBehaviour
    {
        public event Action onTriggerCollider;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 3)
            {
                Debug.Log("Hey");
                onTriggerCollider?.Invoke();
            }
        }
    }
}

