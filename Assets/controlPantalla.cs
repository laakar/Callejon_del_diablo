using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlPantalla : MonoBehaviour
{
    public Toggle pantallaCompleta;
    void Start()
    {
        if (Screen.fullScreen)
        {
            pantallaCompleta.isOn = true;
        }
        else
        {
            pantallaCompleta.isOn = false;
        }
    }

    public void modoPantallacompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
        Debug.Log("xd");
    }
}
