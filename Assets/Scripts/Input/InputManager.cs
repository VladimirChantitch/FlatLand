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
        public event Action onI;
        public event Action<Vector2> onMove;
        public event Action<Vector2> onMouseMove;

        Inputs inputActions = null;

        private void OnEnable()
        {
            inputActions = new Inputs();
            inputActions.Enable();

            inputActions.Actions.Interact.performed += i => onInteract?.Invoke();
            inputActions.Actions.MouseClick.performed += i => onClick?.Invoke();
            inputActions.Actions.Bar.performed += i => onSpaceBar?.Invoke();
            inputActions.Actions.LesPointsSurLesI.performed += i => onI?.Invoke();
        }

        private void Update()
        {
            CheckIfMoving();
        }

        private void FixedUpdate()
        {
            CheckIfMouseMove();
        }

        private void CheckIfMoving()
        {
            Vector2 moveVector = inputActions.Actions.Move.ReadValue<Vector2>();
            if (moveVector.x != 0 || moveVector.y != 0) 
            {
                onMove?.Invoke(moveVector);
            }
        }

        private void CheckIfMouseMove()
        {
            Vector2 moveVector = inputActions.Actions.Look.ReadValue<Vector2>();
            if (moveVector.x != 0 || moveVector.y != 0)
            {
                onMouseMove?.Invoke(moveVector);
            }
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }
    }
}

