using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonMomento : MonoBehaviour
{
    public bool playerAdentro;
    public string textoBoton;
    public string botonApretado;
    public string puzleListo;
    public string botonEquivocado;
    public enum BOTON_TYPE
    {
        BOTON_1,
        BOTON_2,
        BOTON_3,
        BOTON_4
    }
    public BOTON_TYPE botones;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAdentro = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Gamemanager.instancia.Hidetext();
            playerAdentro = false;
            IA.instancia.velocidad = 2;
        }
    }
    void Update()
    {
        if (playerAdentro && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")))
        {
            IA.instancia.velocidad = 0;
            switch (botones)
            {
                case BOTON_TYPE.BOTON_1:
                    if(!Gamemanager.instancia.primerBoton)
                    {
                        Gamemanager.instancia.Showtext(textoBoton);
                        Gamemanager.instancia.primerBoton = true;
                    }
                    else if(Gamemanager.instancia.primerBoton && Gamemanager.instancia.tercerBoton && Gamemanager.instancia.segundoBoton && Gamemanager.instancia.cuartoBoton)
                    {
                        Gamemanager.instancia.Showtext(puzleListo);
                    }
                    else
                    {
                        Gamemanager.instancia.Showtext(botonApretado);
                    }
                    break;
                case BOTON_TYPE.BOTON_2:
                    if(Gamemanager.instancia.primerBoton && !Gamemanager.instancia.tercerBoton && !Gamemanager.instancia.segundoBoton && !Gamemanager.instancia.cuartoBoton)
                    {
                        Gamemanager.instancia.Showtext(textoBoton);
                        Gamemanager.instancia.segundoBoton = true;
                    }    
                    else if(Gamemanager.instancia.primerBoton && (!Gamemanager.instancia.tercerBoton || Gamemanager.instancia.tercerBoton) && Gamemanager.instancia.segundoBoton && !Gamemanager.instancia.cuartoBoton)
                    {
                        Gamemanager.instancia.Showtext(botonApretado);
                    }
                    else if(Gamemanager.instancia.primerBoton && Gamemanager.instancia.tercerBoton && Gamemanager.instancia.segundoBoton && Gamemanager.instancia.cuartoBoton)
                    {
                        Gamemanager.instancia.Showtext(puzleListo);
                    }
                    else
                    {
                        Gamemanager.instancia.Showtext(botonEquivocado);
                        Gamemanager.instancia.primerBoton = false;
                        Gamemanager.instancia.segundoBoton = false;
                        Gamemanager.instancia.tercerBoton = false;
                        Gamemanager.instancia.cuartoBoton = false;
                    }
                    break;
                case BOTON_TYPE.BOTON_3:
                    if(Gamemanager.instancia.primerBoton && !Gamemanager.instancia.tercerBoton && Gamemanager.instancia.segundoBoton && !Gamemanager.instancia.cuartoBoton)
                    {
                        Gamemanager.instancia.Showtext(textoBoton);
                        Gamemanager.instancia.tercerBoton = true;
                    }
                    else if(Gamemanager.instancia.primerBoton && Gamemanager.instancia.tercerBoton && Gamemanager.instancia.segundoBoton && !Gamemanager.instancia.cuartoBoton)
                    {
                        Gamemanager.instancia.Showtext(botonApretado);
                    }
                    else if(Gamemanager.instancia.primerBoton && Gamemanager.instancia.tercerBoton && Gamemanager.instancia.segundoBoton && Gamemanager.instancia.cuartoBoton)
                    {
                        Gamemanager.instancia.Showtext(puzleListo);
                    }
                    else
                    {
                        Gamemanager.instancia.Showtext(botonEquivocado);
                        Gamemanager.instancia.primerBoton = false;
                        Gamemanager.instancia.segundoBoton = false;
                        Gamemanager.instancia.tercerBoton = false;
                        Gamemanager.instancia.cuartoBoton = false;
                    }
                    break;
                case BOTON_TYPE.BOTON_4:
                    if(Gamemanager.instancia.primerBoton && Gamemanager.instancia.tercerBoton && Gamemanager.instancia.segundoBoton && !Gamemanager.instancia.cuartoBoton)
                    {
                        Gamemanager.instancia.Showtext(textoBoton);
                        Gamemanager.instancia.cuartoBoton = true;
                    }
                    else if(Gamemanager.instancia.primerBoton && Gamemanager.instancia.tercerBoton && Gamemanager.instancia.segundoBoton && Gamemanager.instancia.cuartoBoton)
                    {
                        Gamemanager.instancia.Showtext(puzleListo);
                    }
                    else
                    {
                        Gamemanager.instancia.Showtext(botonEquivocado);
                        Gamemanager.instancia.primerBoton = false;
                        Gamemanager.instancia.segundoBoton = false;
                        Gamemanager.instancia.tercerBoton = false;
                        Gamemanager.instancia.cuartoBoton = false;
                    }
                    break;
            }
        }
    }
}