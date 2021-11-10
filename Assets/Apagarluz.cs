using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apagarluz : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject linterna;
    public GameObject linternasuelo;
    public GameObject newgameObject;
    public bool playerinZone;
    public string textoposible;
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
        if (playerinZone && Input.GetKeyDown("6"))
        {
            Gamemanager.instancia.Showtext(textoposible);
            linterna.SetActive(true);
            linternasuelo.SetActive(false);
            Destroy(newgameObject);
            if (GameObject.FindGameObjectWithTag("Pala"))
            {
                Gamemanager.instancia.PalaOk();
            }
        }

    }
}
