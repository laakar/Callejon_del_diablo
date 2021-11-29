using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DagobertoMomento : MonoBehaviour
{
    public static DagobertoMomento instancia;
    public bool primerEncuentro;
    public bool tarjetaMomento;
    public GameObject tarjeta, timer;
    public bool playerAdentro;
    public string textoPrimerEncuentro;
    public string textoFallaste;
    public string textoGanaste;
    public string textoPayaso;
    public float velo;

    public void Awake()
    {
        instancia = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAdentro = true;
            velo = IA.instancia.velocidad;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Gamemanager.instancia.Hidetext();
            playerAdentro = false;
            IA.instancia.velocidad = velo;
        }
    }

    IEnumerator AdiosMomento()
    {
        timer.SetActive(false);
        Gamemanager.instancia.Showtext(textoGanaste);
        Gamemanager.instancia.euripidesMomento = true;
        yield return new WaitForSecondsRealtime(2f);
        Gamemanager.instancia.Hidetext();
        gameObject.SetActive(false);
    }

    public void Update()
    {
        if(playerAdentro && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")))
        {
            IA.instancia.velocidad = 0;
            if(!primerEncuentro)
            {
                Gamemanager.instancia.Showtext(textoPrimerEncuentro);
                primerEncuentro = true;
                tarjeta.SetActive(true);
                Timer.instancia.timerMomento = true;
            }
            else if(Timer.instancia.timer > 0 && !tarjetaMomento)
            {
                Gamemanager.instancia.Showtext(textoPayaso);
                BarraDeVida.vida.vidaMaxima = BarraDeVida.vida.vidaMaxima - 25;
            }
            else if(Timer.instancia.timer == 0 && !tarjetaMomento)
            {
                Gamemanager.instancia.Showtext(textoFallaste);
                Gamemanager.instancia.botiquinMomento = false;
                BarraDeVida.vida.vidaMaxima = 0;
            }
            else if(tarjetaMomento)
            {
                StartCoroutine(AdiosMomento());
            }    
        }    
    }
}
