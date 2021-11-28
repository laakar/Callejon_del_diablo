using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FotosEuripides : MonoBehaviour
{
    public bool playerAdentro;
    public string textoPosible;

    public enum FOTO_MOMENTO
    {
        FOTO_MALA,
        FOTO_BUENA
    }

    public FOTO_MOMENTO fotaza;

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
    // Update is called once per frame
    void Update()
    {
        if (playerAdentro && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")))
        {
            switch (fotaza)
            {
                case FOTO_MOMENTO.FOTO_MALA:
                    Gamemanager.instancia.Showtext(textoPosible);
                    break;
                case FOTO_MOMENTO.FOTO_BUENA:
                    Gamemanager.instancia.Showtext(textoPosible);
                    EuripidesMomento.instancia.fotoMomento = true;
                    break;
            }
        }
    }
}
