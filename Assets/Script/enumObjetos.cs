using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enumObjetos : MonoBehaviour
{
    public bool playerinZone;
    public enum POSIBLES_CASOS
    {
        POSEE_OBJETO_CLAVE,
        NO_POSEE_OBJETO_CLAVE
    }

    public POSIBLES_CASOS casos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerinZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Gamemanager.instancia.Hidetext();
            playerinZone = false;
        }
    }

    private void Update()
    {
        if (playerinZone && Input.GetKeyDown("2"))
        {
            switch (casos)
            {
                case POSIBLES_CASOS.POSEE_OBJETO_CLAVE:
                    Gamemanager.instancia.Showtext("ta bien");
                    break;
                case POSIBLES_CASOS.NO_POSEE_OBJETO_CLAVE:
                    Gamemanager.instancia.Showtext("ta mal");
                    break;
            }
        }
    }
}
