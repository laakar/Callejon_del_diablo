using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PentagramaFinal : MonoBehaviour
{
    public bool playerinZone;
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
    IEnumerator pasar()
    {
        yield return new WaitForSecondsRealtime(2f);
        Gamemanager.instancia.Hidetext();
        SceneManager.LoadScene("Creditos", LoadSceneMode.Single);
    }
    private void Update()

    {
        if (playerinZone && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")))
        {
            if(Gamemanager.instancia.final1 && Gamemanager.instancia.final2 && Gamemanager.instancia.final3 && Gamemanager.instancia.final4)
            {
                Gamemanager.instancia.Showtext("Finalmente podremos escapar de este fantasma. Vamos Mateo, es hora de encontrar la salida.");
                StartCoroutine(pasar());

            }
            else
            {
                Gamemanager.instancia.Showtext("Una barrera impide interactuar con esto");
            }
        }
    }
}
