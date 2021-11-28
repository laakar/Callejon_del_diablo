using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            IA.instancia.velocidad = 2;
        }
    }
    void Update()
    {
        if (playerAdentro && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")))
        {
            IA.instancia.velocidad = 0;
            Gamemanager.instancia.Showtext(textoFotos);
            if (GameObject.FindGameObjectWithTag("Salida"))
            {
                SceneManager.LoadScene("Metroxd");
            }
        }

        
    }
}
