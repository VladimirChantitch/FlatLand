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
        
        Button backToHubWin = null;
        Button backToHubLoose = null;

        Sprite[] l_w = new Sprite[2];

        public event Action<GameState> onLoadNewScene;
        public event Action<bool> onAnsweredDialgue;

        public event Action<bool> hasChooseLeft;

        Button rightButton = null;
        Button leftButton = null;

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

            if (state == GameState.deuxD || state == GameState.unD || state == GameState.zeroD)
            {
                backToHubLoose = currentRoot.Q<Button>("backToHubLoose");
                backToHubWin = currentRoot.Q<Button>("backToHubWin");

                backToHubWin.clicked += () => {
                    onLoadNewScene?.Invoke(GameState.troisD);        
                };
                backToHubLoose.clicked += () => onLoadNewScene?.Invoke(GameState.troisD);
            }

            if (state != GameState.start)
            {
                if (currentRoot != null)
                {
                    dialogue = currentRoot.Q<DialogueElement>("dialogue");
                    if (dialogue != null)
                    {
                        dialogue.Init(currentRoot);
                        dialogue.onFalseAnswer += () => onAnsweredDialgue?.Invoke(false);
                        dialogue.onTrueAnswer += () => onAnsweredDialgue?.Invoke(true);
                    }
                }
            }

            if (state == GameState.zeroD)
            {
                rightButton = currentRoot.Q<Button>("right");
                leftButton = currentRoot.Q<Button>("left");

                rightButton.clicked += () => { hasChooseLeft?.Invoke(false); };
                leftButton.clicked += () => { hasChooseLeft?.Invoke(true); };
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
            dialogue?.InitNewDialogue(step);
        }

        internal void handleDialogueFinished(DialogueStep step, bool b)
        {
            if (state  == GameState.zeroD)
            {
                if (b)
                {
                    StyleBackground ss = new StyleBackground(l_w[1]);
                    backToHubWin.style.backgroundImage = ss;
                    backToHubWin.style.display = DisplayStyle.Flex;
                    currentRoot.Q<VisualElement>("buttons").style.display = DisplayStyle.None;
                }
                else
                {
                    StyleBackground ss = new StyleBackground(l_w[0]);
                    backToHubWin.style.backgroundImage = ss;
                    backToHubLoose.style.display = DisplayStyle.Flex;
                    currentRoot.Q<VisualElement>("buttons").style.display = DisplayStyle.None;
                }
            }
            else
            {
                if (b)
                {
                    backToHubWin.style.display = DisplayStyle.Flex;
                }
                else
                {
                    backToHubLoose.style.display = DisplayStyle.Flex;
                }
            }

        }
    }
}

