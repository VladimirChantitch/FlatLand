using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question")]
public class Question : ScriptableObject
{
    [SerializeField] private Question nextQuestion;
    public Question NextQuestion => nextQuestion;

    [SerializeField] private AudioClip audioClip;
    public AudioClip AudioClip => audioClip;
    [SerializeField] private string question;
    public string QuestionTxt => question;
    [SerializeField] private string answer1;
    public string Answer1 => answer1;
    [SerializeField] private string answer2;
    public string Answer2 => answer2;   
    [SerializeField] private bool isAnwser1True;
    public bool IsAnwser1True => isAnwser1True;
}
