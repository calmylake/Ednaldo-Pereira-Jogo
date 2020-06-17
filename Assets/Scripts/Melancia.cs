using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melancia : MonoBehaviour
{
    bool taken;

    public AudioSource[] sound;

    ControladorDeVolume volumeController;

    void Start()
    {
        volumeController = FindObjectOfType<ControladorDeVolume>();
        int i = 0;
        while (i < sound.Length)
        {
            sound[i].volume = volumeController.getVolume();
            i++;
        }
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
            int tempInt = new System.Random().Next(0, sound.Length - 1);
            sound[tempInt].enabled = true;
            sound[tempInt].Play();
        }
    }
}
