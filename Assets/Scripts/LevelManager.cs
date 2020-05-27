using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;

    public GameObject deathParticle;

    public Movement player;

    public float respawnDelay;
    void Start()
    {
        player = FindObjectOfType<Movement>();
    }

    void Update()
    {
        
    }

    public void respawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(respawnDelay);
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        player.transform.position = currentCheckpoint.transform.position;
    }

}
