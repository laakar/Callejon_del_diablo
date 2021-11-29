using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlVolumen : MonoBehaviour
{
    public Slider sliderVolumen;
    public float slidervalue;

    void Start()
    {
        sliderVolumen.value = PlayerPrefs.GetFloat("volumen", 0.5f);
        AudioListener.volume = slidervalue;
    }

    public void volumenAudio(float volumen)
    {
        slidervalue = volumen;
        PlayerPrefs.SetFloat("volumen", slidervalue);
        AudioListener.volume = slidervalue;
    }
}
