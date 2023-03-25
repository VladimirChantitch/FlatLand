using flat_land.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flat_land.interaction
{
    public class InteractionPopUp : MonoBehaviour
    {
        public event Action<string> onInteract;
        public event Action onStopInteract;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 30)
            {
                onInteract?.Invoke(other.GetComponent<GateInteraction>().WorldName);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == 30)
            {
                onStopInteract?.Invoke();
            }
        }
    }
}
    
