using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace flat_land.input
{
    public class InputManager : MonoBehaviour
    {
        public event Action onClick;
        public event Action onInteract;

        Inputs inputActions = null;

        private void OnEnable()
        {
            inputActions = new Inputs();
            inputActions.Enable();



        }

        private void OnDisable()
        {
            inputActions.Disable();
        }
    }
}

