using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melancia : MonoBehaviour
{
    bool taken;

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            taken = true;
            Debug.Log("melancia");
            transform.localScale = new Vector3(0, 0, 0);
            ScoreManager.AddPoints(1);
        }
    }
}
