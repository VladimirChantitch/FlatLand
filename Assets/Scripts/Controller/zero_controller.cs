using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flat_land.controller
{
    public class zero_controller : AbstractController
    {
        internal override void Interacts()
        {
            Debug.Log("Maybe some action could be triggered");
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
            throw new System.NotImplementedException();
        }
    }
}

