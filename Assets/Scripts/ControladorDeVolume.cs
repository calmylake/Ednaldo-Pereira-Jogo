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
    }

    void Update()
    {
        
    }
}
