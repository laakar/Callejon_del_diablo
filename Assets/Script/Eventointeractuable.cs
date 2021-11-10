using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventointeractuable : MonoBehaviour
{
    public string textoposible;
    public bool playerinZone;
    public bool keymoment;
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
        if(playerinZone && Input.GetKeyDown ("6"))
        {
            Gamemanager.instancia.Showtext(textoposible);
            if (GameObject.FindGameObjectWithTag("Pala"))
            {
                Gamemanager.instancia.PalaOk();
            }
        }
        
    }
}
