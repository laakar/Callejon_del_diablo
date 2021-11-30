using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opciones : MonoBehaviour
{
    public bool opcionesArriba;
    public GameObject opciones;
    public float timeWtf;
    public void Awake()
    {
        timeWtf = Time.timeScale;
    }
    void Update()
    {
        if(Input.GetKeyDown("joystick button 5"))
        {
            if(opcionesArriba)
            {
                opciones.SetActive(false);
                opcionesArriba = false;
                Time.timeScale = timeWtf;
            }
            else
            {
                opciones.SetActive(true);
                opcionesArriba = true;
                Time.timeScale = 0;
            }
        }
    }
}
