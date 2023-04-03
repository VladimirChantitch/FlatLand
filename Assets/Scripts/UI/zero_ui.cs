using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UIElements;

public class zero_ui : VisualElement
{
    public new class UxmlFactory : UxmlFactory<zero_ui, zero_ui.UxmlTraits> { }

    public event Action onSkip;
    public event Action onPickLeft;
    public event Action onPickRight;
    public event Action<float> onTimerStarted;
    public event Action onCLickLeave;
    
    public SpriteRenderer spriteRenderer;
    public AudioSource audioSource;

    public ProgressBar progressBar;

    public VisualElement ProgressContainer, SkipContainer, ChoiceContainer;

    Button bg, bl;

    public void Init(SpriteRenderer spriteRenderer, AudioSource audio)
    {
        this.spriteRenderer = spriteRenderer;
        this.audioSource = audio;
        BindButtons();
    }

    private void BindButtons()
    {
        this.Q<Button>("btn_skip").clicked += () => onSkip?.Invoke();
        this.Q<Button>("left").clicked += () => onPickLeft?.Invoke();
        this.Q<Button>("right").clicked += () => onPickRight?.Invoke();

        progressBar = this.Q<ProgressBar>();

        ProgressContainer = this.Q<VisualElement>("Progresse");
        SkipContainer = this.Q<VisualElement>("Skip");
        ChoiceContainer = this.Q<VisualElement>("buttons");

        bl = this.Q<Button>("bl");
        bl.clicked += () => onCLickLeave?.Invoke();
        bg = this.Q<Button>("bg");
        bg.clicked += () => onCLickLeave?.Invoke();
    }

    public void SetNextScreen(ScreensLogic screensLogic)
    {
        audioSource.Stop();
        progressBar.value = 0;
        progressBar.lowValue = 0;
        spriteRenderer.sprite = screensLogic.sprite;   
        if (screensLogic.clip != null)
        {
            audioSource.PlayOneShot(screensLogic.clip);
        }

        if (!screensLogic.hasanswer)
        {
            SetTimer(screensLogic);
        }
    }

    float maxTime;

    private void SetTimer(ScreensLogic screensLogic)
    {
        maxTime = screensLogic.clip.length;
        onTimerStarted?.Invoke(maxTime);
        progressBar.highValue = maxTime;
    }

    public void ShowLooseWinScreen(bool isLoose)
    {
        if (isLoose)
        {
            bl.style.display = DisplayStyle.Flex;

        }
        else
        {
            bg.style.display = DisplayStyle.Flex;
        }

        contentContainer.style.display = DisplayStyle.None;
        ProgressContainer.style.display = DisplayStyle.None;
        ChoiceContainer.style.display = DisplayStyle.None;
    }

    public void UpdateProgresse(float currentTime)
    {
        progressBar.value = currentTime / maxTime;
    }
}
