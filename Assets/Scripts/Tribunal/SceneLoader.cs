using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private InputAction action;

    private void Awake()
    {
        action.Enable();
        action.performed += i =>
        {
            SceneManager.LoadScene("Start");
        };
    }
}
    