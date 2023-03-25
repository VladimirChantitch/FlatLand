using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class DmensionalGod : MonoBehaviour
{
    [SerializeField] static int successCounter;
    [SerializeField] static int maxSuccess;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public static void IncreaseSuccessCounter()
    {
        successCounter = successCounter + 1;
    }

    public static int GetSuccessCounter()
    {
        return successCounter;
    }

    public static bool IsAllSuccessfull()
    {
        if (successCounter >= maxSuccess)
        {
            return true;
        }
        return false;
    }
}
