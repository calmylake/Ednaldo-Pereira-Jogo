using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public LevelManager lm;
    void Start()
    {
        lm = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if(collision.name == "Player")
        {
            Debug.Log("LOL");
            lm.respawnPlayer();
        }
    }
}
