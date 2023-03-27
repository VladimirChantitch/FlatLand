using flat_land.clicker;
using flat_land.gameManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flat_land.kings
{
    public class ClickerKing : AbstractKing
    {
        [SerializeField] float growRate;
        [SerializeField] float growSpeed = 0.5f;

        [SerializeField] Transform crown;
        [SerializeField] float crownOffset;

        [SerializeField] bool isGrowing;

        SpriteRenderer renderer = null;

        private void Awake()
        {
            renderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            ClickerManager.Instance.onClickerFiinished.AddListener((kingWon) =>
            {
                StopGrowing(kingWon);
            });

            StartGrowing();
        }

        public void Grow(float rate)
        {
            Vector3 newScale = transform.localScale;
            newScale.y += rate;
            transform.localScale = newScale;

            MoveCrown();
            ClickerManager.Instance.NotifyKingSize(renderer.bounds.size.y);
        }

        private void MoveCrown()
        {
            Vector3 newCrownPosition = crown.position;
            newCrownPosition.y = renderer.bounds.size.y + crownOffset;
            crown.position = newCrownPosition;
        }

        public void StartGrowing()
        {
            isGrowing = true;
            StartCoroutine(Growing());
        }

        IEnumerator Growing()
        {
            while (isGrowing)
            {
                Grow(growRate);
                growSpeed *= 0.97f;
                yield return new WaitForSeconds(growSpeed);
            }
        }

        public void StopGrowing(bool kingGrow)
        {
            isGrowing = false;
        }
    }
}

