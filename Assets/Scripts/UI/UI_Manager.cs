using flat_land.gameManager;
using flat_land.interaction;
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
        Hub hub = null;

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

            if (state == GameState.troisD)
            {
                hub = currentRoot.Q<Hub>("hub");
                hub.Init(currentRoot);
            }
        }

        private void HandleStartMenu()
        {
            startMenu = new StartMenu(currentRoot);
            startMenu.onStartGame += () => GoTo(GameState.troisD);
        }

        private void GoTo(GameState state)
        {
            onLoadNewScene?.Invoke(state);
        }

        public void ShowPopUp(string txt)
        {
            hub.Show(txt);
        }

        internal void HidePopUp()
        {
            hub.Hide();
        }
    }
}

