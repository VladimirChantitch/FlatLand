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
        public event Action onSpaceBar;
        public event Action<Vector2> onMove;

        Inputs inputActions = null;

        private void OnEnable()
        {
            inputActions = new Inputs();
            inputActions.Enable();

            inputActions.Actions.Interact.performed += i => onInteract?.Invoke();
            inputActions.Actions.MouseClick.performed += i => onClick?.Invoke();
            inputActions.Actions.Bar.performed += i => onSpaceBar?.Invoke(); 
        }

        private void Update()
        {
            CheckIfMoving();
        }

        private void CheckIfMoving()
        {
            Vector2 moveVector = inputActions.Actions.Move.ReadValue<Vector2>();
            if (moveVector.x != 0 || moveVector.y != 0) 
            {
                onMove?.Invoke(moveVector);
            }
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }
    }
}

