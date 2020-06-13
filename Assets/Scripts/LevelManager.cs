using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;

    public GameObject deathParticle;

    public Movement player;

    public Fim fim;

    public float respawnDelay;

    public HealthManager healthManager;
    void Start()
    {
        player = FindObjectOfType<Movement>();
    }

    void Update()
    {
        
    }

    public void respawnPlayer()
    {
        healthManager.TakeDamage();
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
