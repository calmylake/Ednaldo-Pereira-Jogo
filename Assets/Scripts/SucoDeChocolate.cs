using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SucoDeChocolate : MonoBehaviour
{
    bool taken;
    CapsuleCollider2D capsuleCol;
    Vector3 startScale;

    public AudioSource[] sound;

    ControladorDeVolume volumeController;

    int cooldown;
    void Start()
    {
        capsuleCol = FindObjectOfType<CapsuleCollider2D>();
        startScale = transform.localScale;
        cooldown = 0;
        taken = false;

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

    private void FixedUpdate()
    {
        if (cooldown >= 90)
        {
            Spawn();
        }
        else if (taken == true)
        {
            cooldown++;
        }
    }

    private void OnTriggerEnter2D (Collider2D col)
    {
        Take();
    }

    public void Spawn()
    {
        transform.localScale = startScale;
        taken = false;
        capsuleCol.enabled = true;
        cooldown = 0;
    }

    public void Take()
    {
        Movement mv = FindObjectOfType<Movement>();
        mv.dash = false;
        transform.localScale = new Vector3(0,0,0);
        taken = true;
        capsuleCol.enabled = false;
        int tempInt = new System.Random().Next(0, sound.Length - 1);
        sound[tempInt].enabled = true;
        sound[tempInt].Play();
    }
}
