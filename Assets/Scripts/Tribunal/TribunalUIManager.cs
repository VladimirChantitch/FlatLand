using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TribunalUIManager : MonoBehaviour
{
    public event Action OnQuestionFinished;

    [SerializeField] private Question question;
    private Question currentQuestion;
    [SerializeField] private TextMeshProUGUI questionTMP;

    [SerializeField] private Button answerButton1;
    [SerializeField] private Button answerButton2;
    [SerializeField] private TextMeshProUGUI answerTMP1;
    [SerializeField] private TextMeshProUGUI answerTMP2;
    [SerializeField] private AudioSource audioSource;


    private void Awake()
    {
        answerButton1.gameObject.SetActive(false);
        answerButton2.gameObject.SetActive(false);
        questionTMP.gameObject.SetActive(false);
    }

    public void Init()
    {
        currentQuestion = question;
        answerButton1.gameObject.SetActive(true);
        answerButton2.gameObject.SetActive(true);
        questionTMP.gameObject.SetActive(true);
        answerButton1.onClick.AddListener(() => NexQuestion());
        answerButton2.onClick.AddListener(() => NexQuestion());
        SetQuestion();
    }

    private void NexQuestion()
    {
        currentQuestion = currentQuestion.NextQuestion;
        if (currentQuestion != null)
        {
            SetQuestion();
        }
        else
        {
            OnQuestionFinished?.Invoke();
        }
    }

    private void SetQuestion()
    {
        answerTMP1.text = currentQuestion.Answer1;
        answerTMP2.text = currentQuestion.Answer2;
        questionTMP.text = currentQuestion.QuestionTxt;
        audioSource.Stop();
        audioSource.PlayOneShot(currentQuestion.AudioClip);
    }
}
