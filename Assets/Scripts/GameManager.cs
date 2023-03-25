using flat_land.clicker;
using flat_land.dialogue;
using flat_land.interaction;
using flat_land.runner;
using flat_land.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace flat_land.gameManager
{
    public class GameManager : MonoBehaviour
    {
        UI_Manager uI_Manager = null;
        [SerializeField] InteractionPopUp interactPopUp = null;
        [SerializeField] DialogueReader dialogueReader = null;
        [SerializeField] LevelController levelController = null;
        public GameState state;

        private void Awake()
        {
            uI_Manager = GetComponentInChildren<UI_Manager>();
            dialogueReader = Instantiate(dialogueReader);
            dialogueReader.onDialogueSelected += (step) =>
            {
                uI_Manager.handleDialogue(step);
            };

            dialogueReader.onFinished += (step, b) =>
            {
                uI_Manager.handleDialogueFinished(step, b); 
            };

            if (state == GameState.deuxD)
            {
                levelController.onPlayerHit += () => {
                    LooseMiniGame();
                };
                levelController.onPlayerWin += () => WinMiniGame();
            }

            Cursor.visible = false;
        }

        private void WinMiniGame()
        {
            dialogueReader.GetWinDialogue();
        }

        private void Start()
        {
            InitEvents();
            HandleDialogue();
        }

        private void HandleDialogue()
        {
             dialogueReader.GetNextDialogue(state);
        }

        private void InitEvents()
        {
            uI_Manager.onLoadNewScene += (state) => LoadNextScene(state);
            uI_Manager.onAnsweredDialgue += (isValid) =>
            {
                if (isValid)
                {
                    dialogueReader.GetNextDialogue(state);
                }
                else
                {
                    dialogueReader.GetLooseDialogue();
                    LooseMiniGame();
                }
            };

            if (interactPopUp != null)
            {
                interactPopUp.onInteract += (txt) => uI_Manager.ShowPopUp(txt);
                interactPopUp.onStopInteract += () => uI_Manager.HidePopUp();
            }
        }

        private void LooseMiniGame()
        {
            dialogueReader.GetLooseDialogue();
        }

        public static void LoadNextScene(GameState state)
        {
            switch (state)
            {
                case GameState.start:
                    SceneManager.LoadScene("Start");
                    break;
                case GameState.zeroD:
                    SceneManager.LoadScene("0D");
                    break;
                case GameState.unD:
                    SceneManager.LoadScene("1D");
                    break;
                case GameState.deuxD:
                    SceneManager.LoadScene("2D");
                    break;
                case GameState.troisD:
                    SceneManager.LoadScene("3D");
                    break;
            }
        }

        public static void GoBackToHub()
        {
            SceneManager.LoadScene("3D");
        }
    }

    public enum GameState { start, zeroD, unD, deuxD, troisD }
}

