using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enumObjetos : MonoBehaviour
{
    public bool playerinZone;
    public GameObject puertaUno, puertaFinal;
    
    public enum POSIBLES_CASOS
    {
        LLAVE_PUERTA_UNO,
        LLAVE_PUERTA_FINAL,
        OBJETO_VACIO,
        NOTA_LLAVE_FINAL,
        PUERTA_UNO,
        PUERTA_FINAL    

    }

    public POSIBLES_CASOS casos;
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
        if (playerinZone && (Input.GetKeyDown("Joystick Button 2") || Input.GetKeyDown("Joystick Button 0")))
        {
            switch (casos)
            {
                case POSIBLES_CASOS.LLAVE_PUERTA_UNO:
                    Gamemanager.instancia.Showtext("Encontre una llave, puede que me sea util más adelante");
                    GameObject.FindGameObjectWithTag("Player").GetComponent<xd>().llavePuertaUno = true;
                    break;

                case POSIBLES_CASOS.OBJETO_VACIO:
                    Gamemanager.instancia.Showtext("Aqui no hay nada, seguire buscando");
                    break;

                case POSIBLES_CASOS.PUERTA_UNO:
                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<xd>().llavePuertaUno == true)
                    {
                        puertaUno.SetActive(false);
                        Destroy(gameObject);
                        GameObject.FindGameObjectWithTag("Player").GetComponent<xd>().llavePuertaUno = false;
                    }
                    else
                    {
                        Gamemanager.instancia.Showtext("Esta cerrada, creo que necesito una llave");
                    }
                    break;

                case POSIBLES_CASOS.NOTA_LLAVE_FINAL:
                    Gamemanager.instancia.Showtext("Encuentras una nota y dice lo siguiente: Recuerda, las llaves de repuesto estan escondidas en la cocina");
                    
                    break;

                case POSIBLES_CASOS.LLAVE_PUERTA_FINAL:
                    Gamemanager.instancia.Showtext("Creo que con esta llave deberia poder escapar");
                    GameObject.FindGameObjectWithTag("Player").GetComponent<xd>().llavePuertaFinal = true;
                    break;

                case POSIBLES_CASOS.PUERTA_FINAL:
                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<xd>().llavePuertaFinal == true)
                    {
                        puertaFinal.SetActive(false);
                    }
                    else
                    {
                        Gamemanager.instancia.Showtext("Esta cerrada, creo que necesito una llave");
                    }
                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<xd>().llavePuertaUno == true)
                    {
                        Gamemanager.instancia.Showtext("Esta no es la llave correcta, debo seguir investigando");
                    }
                    break;
            }
        }
    }
}
