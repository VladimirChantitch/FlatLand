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
        [SerializeField] ClickerManager clickerManager = null;
        [SerializeField] AudioSource audioSource = null;
        [SerializeField] zero_man z = null;
        public GameState state;

        private void Awake()
        {
            if (dialogueReader != null)
            {
                dialogueReader = Instantiate(dialogueReader);
                dialogueReader.onDialogueSelected += (step) =>
                {
                    audioSource.Stop();
                    uI_Manager.handleDialogue(step);
                    if (state == GameState.zeroD)
                    {
                        PlayAudioClip(step.npc.audio, true);
                    }
                    else
                    {
                        PlayAudioClip(step.npc.audio);
                    }
                };

                dialogueReader.onFinished += (step, b) =>
                {
                    uI_Manager.handleDialogueFinished(step, b);
                    PlayAudioClip(step.npc.audio);
                };
            }
            uI_Manager = GetComponentInChildren<UI_Manager>();

            if (state == GameState.deuxD)
            {
                levelController.onPlayerHit += () => LooseMiniGame();
                levelController.onPlayerWin += () => WinMiniGame();
            }

            if (state == GameState.unD)
            {
                clickerManager.onClickerFiinished.AddListener( (b) =>
                {
                    if (b)
                    {
                        WinMiniGame();
                    }
                    else
                    {
                        LooseMiniGame();
                    }
                });
            }

            Cursor.visible = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                switch (state)
                {
                    case GameState.start:
                        Application.Quit();
                        break;
                    case GameState.zeroD:
                        LoadNextScene(GameState.start);
                        break;
                    case GameState.unD:
                        LoadNextScene(GameState.start);
                        break;
                    case GameState.deuxD:
                        LoadNextScene(GameState.start);
                        break;
                    case GameState.troisD:
                        LoadNextScene(GameState.start);
                        break;
                }
            }
        }

        private void PlayAudioClip(AudioClip audio, bool solo = false)
        {
            audioSource.Stop();
            if (state == GameState.zeroD) 
            {
                float audioLength = audio.length;
                audioSource.PlayOneShot(audio);
                if (solo) return;
                StartCoroutine(PlayNextAudioCor(audioLength));
            }
            else
            {
                float audioLength = audio.length;
                audioSource.PlayOneShot(audio);
                if (solo) return;
                StartCoroutine(PlayNextAudioCor(audioLength));
            }
        }

        IEnumerator PlayNextAudioCor(float timer)
        {
            yield return new WaitForSeconds(timer + 0.25f);
            HandleDialogue();
        }

        private void WinMiniGame()
        {
            int dim = 3;
            switch (state)
            {
                case GameState.zeroD:
                    dim = 0;
                    break;
                case GameState.unD:
                    dim = 1;
                    break;
                case GameState.deuxD:
                    dim = 2;
                    break;
            }

            DmensionalGod.IncreaseSuccessCounter(dim);
            dialogueReader.GetWinDialogue();
        }

        private void Start()
        {
            InitEvents();
            HandleDialogue();
        }

        public void PlayNextDialogue1D()
        {
            dialogueReader.GetNextDialogue(state);
        }

        private void HandleDialogue()
        {
            if (dialogueReader != null)
            {
                dialogueReader.GetNextDialogue(state);
            }
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

