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
    static bool zD;
    static bool oD;
    static bool td;

    [SerializeField] public static bool introPlayed = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        IsAllSuccessfull();
    }
    
    public static void IncreaseSuccessCounter(int dim)
    {
        switch (dim)
        {
            case 0:
                zD = true;
                break;
            case 1: 
                oD = true;
                break;
            case 2:
                td = true;
                break;
        }
    }

    public static int GetSuccessCounter()
    {
        successCounter = 0;
        if (zD) { successCounter++; }
        if (oD) { successCounter++; }   
        if (td) { successCounter++; }
        return successCounter;
    }

    public void IsAllSuccessfull()
    {
        GameManager g = FindObjectOfType<GameManager>();
        if (g.state == GameState.troisD)
        {
            if (GetSuccessCounter() >= maxSuccess)
            {
                SceneManager.LoadScene("Tribunal");
            }
        }
    }
}
