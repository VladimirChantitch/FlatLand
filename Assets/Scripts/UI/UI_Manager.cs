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


        VisualElement winScreen = null;
        VisualElement looseScreen = null;
        
        Button backToHubWin = null;
        Button backToHubLoose = null;

        Button win = null;
        Button loose = null;

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

            if (state == GameState.deuxD)
            {
                winScreen = currentRoot.Q<VisualElement>("winScree");
                looseScreen = currentRoot.Q<VisualElement>("winScree");

                backToHubLoose = currentRoot.Q<Button>("backToHubLoose");
                backToHubWin = currentRoot.Q<Button>("backToHubWin");

                win = currentRoot.Q<Button>("win");
                loose = currentRoot.Q<Button>("loose");

                backToHubLoose.clicked += () => onLoadNewScene?.Invoke(GameState.troisD);
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
            dialogue.InitNewDialogue(step);
        }

        internal void handleDialogueFinished(DialogueStep step, bool b)
        {
            if (b)
            {
                winScreen.style.display = DisplayStyle.Flex;
                StyleBackground sstyle = new StyleBackground(step.npc.dialogueSprite);
                win.style.backgroundImage = sstyle;
            }
            else
            {
                looseScreen.style.display = DisplayStyle.Flex;
                StyleBackground sstyle = new StyleBackground(step.npc.dialogueSprite);
                loose.style.backgroundImage = sstyle;
            }
        }
    }
}

