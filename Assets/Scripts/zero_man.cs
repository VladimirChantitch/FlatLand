using flat_land.gameManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class zero_man : MonoBehaviour
{
    [SerializeField] List<ScreensLogic> screens = new List<ScreensLogic>();
    [SerializeField] AudioSource audioSource;
    [SerializeField] SpriteRenderer bg_sr;
    [SerializeField] UIDocument uIDocument;

    zero_ui zui;

    private void Start()
    {
        UnityEngine.Cursor.visible = true;
    }

    private void OnEnable()
    {
        UnityEngine.Cursor.visible = true;
        zui = uIDocument.rootVisualElement.Q<zero_ui>();
        zui.Init(bg_sr, audioSource);
        BindEvents();
        PlayNext();
    }

    private void BindEvents()
    {
        zui.onCLickLeave += () => SceneManager.LoadScene("3D");
        zui.onPickLeft += () => CheckIfLeftTrue();
        zui.onPickRight += () => CheckIfRightTrue();
        zui.onSkip += () => Skip();
        zui.onTimerStarted += (f) => StartTimer(f);
    }

    int cursor = 0;
    ScreensLogic logic = null;

    private void PlayNext()
    {
        logic = screens[cursor];
        zui.SetNextScreen(logic);
        cursor++;   
    }

    private void Skip()
    {
        if (logic.hasanswer == false)
        {
            PlayNext();
        }
    }

    private void CheckIfRightTrue()
    {
        if (logic.isLeft)
        {
            zui.ShowLooseWinScreen(true); return;
        }
        if (screens.Count == cursor + 1)
        {
            zui.ShowLooseWinScreen(false); return;
        }
        else
        {
            PlayNext();
        }
    }

    private void CheckIfLeftTrue()
    {
        if (!logic.isLeft)
        {
            zui.ShowLooseWinScreen(true); return;
        }
        if (screens.Count == cursor + 1)
        {
            zui.ShowLooseWinScreen(false); return;
        }
        else
        {
            PlayNext();
        }
    }

    Coroutine cor = null;
    bool timerFinished;

    private void StartTimer(float f)
    {
        if (cor != null)
        {
            StopCoroutine(cor);
        }
        cor = StartCoroutine(timer(f));
    }

    private void Update()
    {
        if (timerFinished)
        {
            timerFinished = false;
            PlayNext();
        }
    }

    IEnumerator timer(float f)
    {
        yield return new WaitForSeconds(f);
        timerFinished = true;
    }
}
[Serializable]
public class ScreensLogic
{
    public bool isLeft;
    public Sprite sprite;
    public AudioClip clip;
    public bool hasanswer;
}

