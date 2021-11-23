using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMomento : MonoBehaviour
{
    public GameObject pentagrama;

    IEnumerator Adios()
    {
        yield return new WaitForSecondsRealtime(2f);
        Gamemanager.instancia.Hidetext();
        gameObject.SetActive(false);
    }
    void Update()
    {
        if(Gamemanager.instancia.anastacioMomento && Gamemanager.instancia.euripidesMomento && Gamemanager.instancia.dagobertoMomento && Gamemanager.instancia.marioMomento)
        {
            Gamemanager.instancia.Showtext("Escuche algo en los andenes, sera mejor que vaya a revisar");
            pentagrama.SetActive(true);
            StartCoroutine(Adios());
        }
    }
}
