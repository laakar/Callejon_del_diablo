using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llavemomento : MonoBehaviour
{
    // Start is called before the first frame update
    public string textoposible;
    public string textoposible2;
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
        if (playerinZone && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")) && Gamemanager.instancia.palamoment)
        {
            Gamemanager.instancia.Showtext(textoposible);
            Gamemanager.instancia.LlaveOk();
           

        }
        else if (playerinZone && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")))
        {
            Gamemanager.instancia.Showtext(textoposible2);
        }
    }
}
