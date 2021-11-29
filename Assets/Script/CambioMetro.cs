using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioMetro : MonoBehaviour
{
    public bool playerinZone;
    public float velo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerinZone = true;
            velo = IA.instancia.velocidad;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Gamemanager.instancia.Hidetext();
            IA.instancia.velocidad = velo;
            playerinZone = false;
        }
    }
    IEnumerator Pasar()
    {
        yield return new WaitForSecondsRealtime(2f);
        Gamemanager.instancia.Hidetext();
        SceneManager.LoadScene("Final", LoadSceneMode.Single);
    }
    void Update()
    {
        if (playerinZone && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")))
        {
            IA.instancia.velocidad = 0;
            Gamemanager.instancia.Showtext("No te separes Mateo, no sabemos a donde nos llevara esto");
            StartCoroutine(Pasar());
        }
    }
}
