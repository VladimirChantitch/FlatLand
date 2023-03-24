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

        private void Awake()
        {
            uI_Manager = GetComponentInChildren<UI_Manager>();

            InitEvents();
        }

        private void InitEvents()
        {
            uI_Manager.onLoadNewScene += (state) => LoadNextScene(state);
        }

        private void LoadNextScene(GameState state)
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
    }

    public enum GameState { start, zeroD, unD, deuxD, troisD }
}

