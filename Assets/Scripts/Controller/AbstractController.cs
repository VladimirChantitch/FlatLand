using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flat_land.controller
{
    public abstract class AbstractController : MonoBehaviour
    {
        internal abstract void Interacts();

        internal abstract void MouseClicked();

        internal abstract void Move(Vector2 direction);

        internal abstract void PressSpaceBar();
    }
}

