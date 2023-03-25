using flat_land.clicker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

namespace flat_land.controller
{
    public class one_controller : AbstractController
    {
        [SerializeField] SpriteRenderer renderer = null;
        [SerializeField] Transform suit;
        [SerializeField] bool canGrow = false;
        [SerializeField] float suitOffset;
        [SerializeField] float growAmount;

        private void Start()
        {
            ClickerManager.Instance.onClickerFiinished.AddListener((kingWon =>
            {
                StopGrowing(kingWon);
            }));
        }

        internal override void Interacts()
        {

        }

        internal override void IPressed()
        {
            Grow(growAmount);
        }

        internal override void MouseClicked()
        {

        }

        internal override void MouseMove(Vector2 direction)
        {

        }

        internal override void Move(Vector2 direction)
        {

        }

        internal override void PressSpaceBar()
        {

        }

        public void Grow(float rate)
        {
            if (canGrow)
            {
                Vector3 newScale = transform.localScale;
                newScale.y += rate;
                transform.localScale = newScale;

                MoveSuit();
                ClickerManager.Instance.NotifyPlayerSize(renderer.bounds.size.y);
            }
        }

        private void MoveSuit()
        {
            Vector3 newCrownPosition = suit.position;
            newCrownPosition.y = renderer.bounds.size.y + suitOffset;
            suit.position = newCrownPosition;
        }

        public void StopGrowing(bool kingGrow)
        {
            canGrow = false;
        }
    }
}

