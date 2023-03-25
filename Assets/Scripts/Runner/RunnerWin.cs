using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flat_land.runner
{
    public class RunnerWin : MonoBehaviour
    {
        public event Action onPLayerWin;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 3)
            {
                onPLayerWin?.Invoke();
            }
        }
    }
}

