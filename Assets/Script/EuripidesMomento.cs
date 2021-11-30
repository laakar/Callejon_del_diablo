using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EuripidesMomento : MonoBehaviour
{
    public GameObject fotoPadre;
    public bool fotoMomento;
    public static EuripidesMomento instancia;
    public bool primerEncuentro;
    public bool playerAdentro;
    public float velo;


    private void Awake()
    {
        instancia = this;
    }

    IEnumerator MomentoAdios()
    {
        Gamemanager.instancia.Showtext("ANASTACIO... SI, ESE ES MI NOMBRE. MUCHAS GRACIAS...");
        fotoPadre.SetActive(false);
        Gamemanager.instancia.anastacioMomento = true;
        yield return new WaitForSecondsRealtime(2f);
        Destroy(gameObject);
        Gamemanager.instancia.Hidetext();
    }    
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
            IA.instancia.velocidad = velo;
            playerAdentro = false;
            Gamemanager.instancia.Hidetext();
        }
    }
    void Update()
    {
        if (playerAdentro && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")))
        {
            IA.instancia.velocidad = 0;
            if (!primerEncuentro && !fotoMomento)
            {
                Gamemanager.instancia.Showtext("MI NOMBRE... DIME MI NOMBRE O TE MATARE... ESTA EN ALGUN LUGAR DE ESTA HABITACIÓN");
                primerEncuentro = true;
                fotoPadre.SetActive(true);
            }
            else if (primerEncuentro && !fotoMomento)
            {
                Gamemanager.instancia.Showtext("MI NOMBRE... DIMELO");
            }
            else if (primerEncuentro && fotoMomento)
            {
                StartCoroutine(MomentoAdios());
            }

        }


    }
}
