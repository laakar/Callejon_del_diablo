using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FotoMomento : MonoBehaviour
{
    public bool playerAdentro;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerAdentro = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Gamemanager.instancia.Hidetext();
            playerAdentro = false;
        }    
    }
    void Update()
    {
        if(playerAdentro && Input.GetKeyDown("6"))
        {
            if(Gamemanager.instancia.primeraFoto && Gamemanager.instancia.segundaFoto && Gamemanager.instancia.terceraFoto)
            {
                Gamemanager.instancia.Showtext("Tienes todas las fotos");
            }
            else
            {
                Gamemanager.instancia.Showtext("Te faltan fotos washito");
            }
        }
    }
}
