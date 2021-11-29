using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            IA.instancia.velocidad = 2;
        }    
    }
    IEnumerator Pasar()
    {
        yield return new WaitForSecondsRealtime(2f);
        Gamemanager.instancia.Hidetext();
        SceneManager.LoadScene("Metroxd", LoadSceneMode.Single);
    }
    void Update()
    {
        if(playerAdentro && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")))
        {
            IA.instancia.velocidad = 0;
            if(Gamemanager.instancia.primerBoton && Gamemanager.instancia.segundoBoton && Gamemanager.instancia.tercerBoton && Gamemanager.instancia.cuartoBoton)
            {
                Gamemanager.instancia.Showtext("El pentagrama empieza a brillar");
                StartCoroutine(Pasar());
            }
            else
            {
                Gamemanager.instancia.Showtext("No pasa nada");
            }
        }
    }
}
