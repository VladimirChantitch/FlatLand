using flat_land.controller;
using flat_land.input;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flat_land.player
{
    public class PlayerManager : MonoBehaviour
    {
        InputManager inputManager = null;
        AbstractController controller = null;

        private void Awake()
        {
            inputManager = GetComponent<InputManager>();
            controller = GetComponent<AbstractController>();
        }

        private void Start()
        {
            InitInputManagerEvents();
        }

        private void InitInputManagerEvents()
        {
            if (controller != null)
            {
                inputManager.onClick += () => controller.MouseClicked();
                inputManager.onInteract += () => controller.Interacts();
                inputManager.onSpaceBar += () => controller.PressSpaceBar();
                inputManager.onMove += (direction) => controller.Move(direction);
            }
        }
    }
}


