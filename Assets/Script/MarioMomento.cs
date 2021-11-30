using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMomento : MonoBehaviour
{
    public bool tarjetaMomento, playerAdentro, primerEncuentro;
    public string primerTexto, textoIntermedio, textoFinal;
    public static MarioMomento instancia;
    public GameObject tarjeta;
    public float velo;

    public void Awake()
    {
        instancia = this;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAdentro = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAdentro = false;
            Gamemanager.instancia.Hidetext();
            IA.instancia.velocidad = velo;
        }
    }
    IEnumerator AdiosMomento()
    {
        Gamemanager.instancia.Showtext(textoFinal);
        Gamemanager.instancia.marioMomento = true;
        yield return new WaitForSecondsRealtime(2f);
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (playerAdentro && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")))
        {
            IA.instancia.velocidad = 0;
            if (!primerEncuentro && !tarjetaMomento)
            {
                Gamemanager.instancia.Showtext(primerTexto);
                primerEncuentro = true;
                tarjeta.SetActive(true);
            }
            else if (primerEncuentro && !tarjetaMomento)
            {
                Gamemanager.instancia.Showtext(textoIntermedio);
            }
            else if (primerEncuentro && tarjetaMomento)
            {
                Gamemanager.instancia.marioMomento = true;
                StartCoroutine(AdiosMomento());
            }
        }
    }
}
