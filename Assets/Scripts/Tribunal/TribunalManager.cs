using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TribunalManager : MonoBehaviour
{
    [Header("Cam")]
    [SerializeField] private Transform camTransform;
    [SerializeField] private Transform targetCamTransform;

    [Header("UI")]
    [SerializeField] private TribunalUIManager uiManager;
    [SerializeField] private ScrollDown creditsScroll;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip endClip;

    [Header("Intro")]
    [SerializeField] private GameObject introText;
    [SerializeField] private AudioClip introClip;
    private float introAudioDuration;

    private void Awake()
    {
        uiManager.OnQuestionFinished += () =>
        {
            creditsScroll.gameObject.SetActive(true);
            uiManager.gameObject.SetActive(false);
            creditsScroll.StartScrolling();
            audioSource.Stop();
            audioSource.PlayOneShot(endClip);
        };

        introAudioDuration = introClip.length;
        audioSource.PlayOneShot(introClip);
        StartCoroutine(WaitUntilIntroFinished());
    }

    void Start()
    {
        creditsScroll.gameObject.SetActive(false);
        camTransform.DOMove(targetCamTransform.position, 8f);
    }

    private IEnumerator WaitUntilIntroFinished() 
    { 
        yield return new WaitForSeconds(introAudioDuration + 1.45f);

        introText.SetActive(false);
        uiManager.Init();
    }
}
