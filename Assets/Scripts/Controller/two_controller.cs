using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flat_land.controller
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class two_controller : AbstractController
    {
        internal override void Interacts()
        {
            throw new System.NotImplementedException();
        }

        internal override void MouseClicked()
        {
            Debug.Log("Maybe some action could be triggered");
        }

        internal override void MouseMove(Vector2 direction)
        {
            Debug.Log("Maybe some action could be triggered");
        }

        internal override void Move(Vector2 direction)
        {
            Debug.Log("Maybe some action could be triggered");
        }

        internal override void PressSpaceBar()
        {
            HandleJump();
        }

        private void HandleJump()
        {
            throw new NotImplementedException();
        }
    }
}

