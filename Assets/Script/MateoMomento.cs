using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateoMomento : MonoBehaviour
{
    public GameObject mateo;
    public bool playerAdentro, siguemeMateo;
    public string textoMateo;
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
            if(siguemeMateo)
            {
                mateo.SetActive(true);
                Destroy(gameObject);
            }    
        }
    }
    void Update()
    {
        if (playerAdentro && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")))
        {
            Gamemanager.instancia.Showtext(textoMateo);
            siguemeMateo = true;
            Gamemanager.instancia.mateoSeguidor = true;
        }
    }
}
