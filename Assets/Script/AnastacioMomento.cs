using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnastacioMomento : MonoBehaviour
{
    public bool tarjetaMomento, playerAdentro, primerEncuentro;
    public string primerTexto, textoIntermedio, textoFinal;
    public static AnastacioMomento instancia;
    public GameObject tarjeta;

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
        }
    }

    IEnumerator AdiosMomento()
    {
        Gamemanager.instancia.Showtext(textoFinal);
        Gamemanager.instancia.dagobertoMomento = true;
        yield return new WaitForSecondsRealtime(2f);
        Gamemanager.instancia.Hidetext();
        Destroy(gameObject);
    }
    void Update()
    {
        if (playerAdentro && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")))
        {
            if(!primerEncuentro && !tarjetaMomento)
            {
                Gamemanager.instancia.Showtext(primerTexto);
                primerEncuentro = false;
                tarjeta.SetActive(true);
            }
            else if(primerEncuentro && !tarjetaMomento)
            {
                Gamemanager.instancia.Showtext(textoIntermedio);
            }
            else if (primerEncuentro && tarjetaMomento)
            {
                Gamemanager.instancia.dagobertoMomento = true;
                StartCoroutine(AdiosMomento());
            }
        }
    }
}