using flat_land.gameManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace flat_land.UI
{
    public class UI_Manager : MonoBehaviour
    {
        public GameState state;

        VisualElement currentRoot = null;

        StartMenu startMenu = null;

        public event Action<GameState> onLoadNewScene;

        private void Awake()
        {
            currentRoot = GetComponent<UIDocument>().rootVisualElement;
        }

        private void Start()
        {
            if (state == GameState.start)
            {
                HandleStartMenu();
            }
        }

        private void HandleStartMenu()
        {
            startMenu = new StartMenu(currentRoot);
            startMenu.onStartGame += () => GoTo(GameState.troisD);
        }

        private void GoTo(GameState state)
        {

        }
    }
}

