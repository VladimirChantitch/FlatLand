using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flat_land.runner
{
    public class Death : MonoBehaviour
    {
        public event Action onPlayerHit;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 3)
            {
                onPlayerHit?.Invoke();
            }
        }
    }
}

