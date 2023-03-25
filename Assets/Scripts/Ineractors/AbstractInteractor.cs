using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flat_land.interaction
{
    public abstract class AbstractInteractor<T> : MonoBehaviour
    {
        public abstract T Interact();
    }
}
