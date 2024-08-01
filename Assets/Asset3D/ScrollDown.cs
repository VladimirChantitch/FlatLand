using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ScrollDown : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private bool scroll;

    public void StartScrolling()
    {
        scroll = true;
    }

    private void Update()
    {
        if (scroll)
        {
            Vector3 newPos = transform.position;
            newPos.y += speed * Time.deltaTime;
            transform.position = newPos;
        }
    }
}
