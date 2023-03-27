using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class zero_man : MonoBehaviour
{
    [SerializeField] List<ScreensLogic> screens = new List<ScreensLogic>();
    [SerializeField] AudioSource audioSource;
    [SerializeField] SpriteRenderer bg_sr;
    int cursor;

    bool canAnswer;

    private void Start()
    {
        PlayFirst();
        Cursor.visible = true;
    }

    private void OnEnable()
    {
        Cursor.visible = true;
    }

    private void PlayFirst()
    {
        bg_sr.sprite = screens[0].sprite;
        audioSource.PlayOneShot(screens[0].clip);

        if (!screens[0].hasanwer)
        {
            canAnswer = false;
            StartCoroutine(DelaySignal(screens[0].clip.length));
        }
    }

    IEnumerator DelaySignal(float timer)
    {
        Debug.Log(cursor+ " " + timer);
        yield return new WaitForSeconds(timer);
        ok = true;
    }

    bool ok;
    float timer = 18f;
    float time;
    bool canIt = true;

    private void Update()
    {
        if (ok)
        {
            ok = false;
            PlayNext();
        }

        if (cursor == 3 && time == 0 && canIt == true)
        {
            canIt = false;
            time = Time.time;
        }
        
        if (cursor == 3 && time + timer <= Time.time && canIt == false)
        {
            timer = 0;
            PlayNext();
        }
    }

    public void PlayNext()
    {
        Cursor.visible = true;
        audioSource.Stop();
        cursor += 1;
        bg_sr.sprite = screens[cursor].sprite;
        audioSource.PlayOneShot(screens[cursor].clip);
        canAnswer = true;

        if (!screens[cursor].hasanwer)
        {
            Debug.Log(cursor);
            StartCoroutine(DelaySignal(screens[cursor].clip.length));
            canAnswer = false;
            return;
        }
    }

    public void PlayNext(bool isLeft, Action<bool> action = null)
    {
        Cursor.visible = true;
        audioSource.Stop();
        bool isTrue = isLeft == screens[cursor].isLeft;

        Debug.Log("airuabrhnogf____" + cursor);

        if (canAnswer == false) return;

        if (!screens[cursor].hasanwer)
        {
            StartCoroutine(DelaySignal(screens[cursor].clip.length));
            canAnswer = false;
            return;
        }
        else
        {
            canAnswer = true;
        }

        if (!isTrue)
        {
            action?.Invoke(isTrue);
        }
        else
        {
            if (cursor + 1 >= screens.Count)
            {
                action?.Invoke(isTrue);
            }
            else
            {
                cursor += 1;
                bg_sr.sprite = screens[cursor].sprite;
                audioSource.PlayOneShot(screens[cursor].clip);
            }
        }
    }

    [Serializable]
    public class ScreensLogic
    {
        public bool isLeft;
        public Sprite sprite; 
        public AudioClip clip;
        public bool hasanwer;
    }
}
