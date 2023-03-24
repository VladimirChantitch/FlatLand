using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flat_land.controller
{
    public class one_controller : AbstractController
    {
        internal override void Interacts()
        {
            throw new System.NotImplementedException();
        }

        internal override void MouseClicked()
        {
            throw new System.NotImplementedException();
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

