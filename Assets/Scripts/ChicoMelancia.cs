using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicoMelancia : MonoBehaviour
{
    public Fim fim;
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
            Debug.Log("Chico");
        }
        fim.WinGame();
    }
}
