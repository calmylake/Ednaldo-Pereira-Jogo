using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    Canvas canvas;
    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        canvas.enabled = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canvas.enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.enabled = false;
    }
}
