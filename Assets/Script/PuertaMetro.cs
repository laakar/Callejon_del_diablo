using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaMetro : MonoBehaviour
{
    public GameObject puerta;
    public bool playerAdentro;
    public Sprite puertaAbierta;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAdentro = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAdentro = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAdentro && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")))
        {
            puerta.GetComponent<SpriteRenderer>().sprite = puertaAbierta;
            puerta.GetComponent<BoxCollider2D>().isTrigger = true;
          
        }
    }
}
