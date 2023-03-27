using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ScrollDown : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        Vector3 newPos = transform.position;
        newPos.y += speed * Time.deltaTime;  
        transform.position = newPos;
    }
}
