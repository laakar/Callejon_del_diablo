using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Cambio_de_escena : MonoBehaviour
{

    public string textoposible;
    public bool playerinZone;
   
   
    void Start()
    {

    }

    // Update is called once per frame
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
        if (playerinZone)
        {
            if ( Input.GetKeyDown ("6") && Gamemanager.instancia.keymoment)
            {
                SceneManager.LoadScene("Casaxd", LoadSceneMode.Single);
            }
            else if (Input.GetKeyDown("6")) 
        {
                Gamemanager.instancia.Showtext(textoposible);
            }
        }
        
    }





}
