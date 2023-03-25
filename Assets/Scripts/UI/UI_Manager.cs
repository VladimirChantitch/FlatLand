using flat_land.dialogue;
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
        DialogueElement dialogue = null;

        public event Action<GameState> onLoadNewScene;
        public event Action<bool> onAnsweredDialgue;

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

            if (state != GameState.start)
            {
                dialogue = currentRoot.Q<DialogueElement>("dialogue");
                dialogue.onFalseAnswer += () => onAnsweredDialgue?.Invoke(false);
                dialogue.onTrueAnswer += () => onAnsweredDialgue?.Invoke(true);
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

        internal void handleDialogue(DialogueStep step)
        {
            throw new NotImplementedException();
        }
    }
}

