using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interacciones : MonoBehaviour
{
    public GameObject mensaje;
    bool aux = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        comprobarCercania();
    }
    void mostrarMensaje(string mensaje)
    {
        this.mensaje.GetComponent<TextMeshProUGUI>().text = mensaje;
    }
    GameObject buscarPentagrama()
    {
        GameObject pentagrama = null;
        pentagrama = GameObject.FindWithTag("pentagrama");
        return pentagrama;
    }
    void comprobarCercania()
    {
        if (calcularDistancia(buscarPentagrama()) < 2.6f)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                mostrarMensaje("");
                aux = false;
            }
        }
        if (aux)
        {
            mostrarMensaje("X para interactuar con pentagrama");
        }

        else
        {
            mostrarMensaje("estas lejos");
            aux = true;
        }
    }
    float calcularDistancia(GameObject referencia)
    {
        return Vector2.Distance(this.transform.position, referencia.transform.position);
    }

}

