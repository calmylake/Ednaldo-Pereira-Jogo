using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeVolume : MonoBehaviour
{
    public AudioSource audioSrc;
    public static float volume;

    void Start()
    {
        audioSrc.volume = volume;
        audioSrc.enabled = true;
        audioSrc.Play();
    }

    void Update()
    {
        
    }

    public float getVolume()
    {
        return volume;
    }
}
