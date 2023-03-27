using flat_land.gameManager;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DmensionalGod : MonoBehaviour
{
    [SerializeField] static int successCounter = 0;
    [SerializeField] static int maxSuccess = 3;

    [SerializeField] public static bool introPlayed = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        IsAllSuccessfull();
    }
    
    public static void IncreaseSuccessCounter()
    {
        successCounter = successCounter + 1;
    }

    public static int GetSuccessCounter()
    {
        return successCounter;
    }

    public  void IsAllSuccessfull()
    {
        GameManager g = FindObjectOfType<GameManager>();
        if (g.state == GameState.troisD)
        {
            if (successCounter >= maxSuccess)
            {
                SceneManager.LoadScene("Tribunal");
            }
        }
    }
}
