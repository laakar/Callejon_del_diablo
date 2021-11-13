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
            if ((Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")) && Gamemanager.instancia.keymoment)
            {
                SceneManager.LoadScene("Casa", LoadSceneMode.Single);
            }
            else if ((Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")))
            {
                Gamemanager.instancia.Showtext(textoposible);
            }
        }
        
    }





}
