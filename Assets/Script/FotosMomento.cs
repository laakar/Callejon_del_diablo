using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FotosMomento : MonoBehaviour
{
    public bool playerAdentro;
    public string textoFotos;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAdentro = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Gamemanager.instancia.Hidetext();
            playerAdentro = false;
        }
    }
    void Update()
    {
        if (playerAdentro && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")))
        {
            Gamemanager.instancia.Showtext(textoFotos);
        }
    }
}
