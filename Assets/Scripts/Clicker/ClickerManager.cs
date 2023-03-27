using camera;
using flat_land.gameManager;
using flat_land.player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace flat_land.clicker
{
    public class ClickerManager : MonoBehaviour
    {
        #region singleton
        public static ClickerManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        #endregion

        public UnityEvent<bool> onClickerFiinished = new UnityEvent<bool>();
        public float playerSize;
        public float kingSize;
        public float targetSize;
        [SerializeField] CameraShake cameraShake;
        bool isFInished = false;

        public void NotifyKingSize(float size)
        {
            kingSize = size;
            CheckWhoWon();
        }

        public void NotifyPlayerSize(float size) 
        {
            cameraShake.ShakeCamera(1.5f, 0.2f, 1f);
            playerSize = size;
            CheckWhoWon();
        }

        private void CheckWhoWon()
        {
            if (isFInished == false) 
            {
                if (kingSize >= targetSize || playerSize >= targetSize)
                {
                    if (kingSize > playerSize)
                    {
                        onClickerFiinished?.Invoke(false);
                    }
                    else
                    {
                        onClickerFiinished?.Invoke(true);
                    }
                }
            }
        }
    }
}

