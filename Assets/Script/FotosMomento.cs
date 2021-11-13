using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FotosMomento : MonoBehaviour
{
    public bool playerAdentro;
    public string textoFotos;
    public enum FOTO_TYPE
    {
        FOTO_1,
        FOTO_2,
        FOTO_3
    }
    public FOTO_TYPE fotos;

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
        if (playerAdentro && Input.GetKeyDown("6"))
        {
            switch (fotos)
            {
                case FOTO_TYPE.FOTO_1:
                    Gamemanager.instancia.Showtext(textoFotos);
                    Gamemanager.instancia.primeraFoto = true;
                    break;
                case FOTO_TYPE.FOTO_2:
                    Gamemanager.instancia.Showtext(textoFotos);
                    Gamemanager.instancia.segundaFoto = true;
                    break;
                case FOTO_TYPE.FOTO_3:;
                    Gamemanager.instancia.Showtext(textoFotos);
                    Gamemanager.instancia.terceraFoto = true;
                    break;
            }
        }
    }
}
