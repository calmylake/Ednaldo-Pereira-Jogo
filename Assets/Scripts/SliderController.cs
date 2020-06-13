using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSource;
    void Start()
    {
        slider.value = 1;
    }

    void Update()
    {
        ControladorDeVolume.volume = slider.value;
        audioSource.volume = ControladorDeVolume.volume;
    }
}
