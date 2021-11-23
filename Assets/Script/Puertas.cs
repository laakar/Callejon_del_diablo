using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public bool playerAdentro, adentroBano;
    public float afueraX, afueraY, adentroX, adentroY, feoX, feoY, mateoAdentroX, mateoAdentroY, mateoAfueraX, mateoAfueraY;
    public Transform jugadorTrans, feoTrans, mateoTrans;
    public GameObject elFeo;
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
    void Update()
    {
        if (playerAdentro && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")))
        {
            if(!adentroBano)
            {
                feoTrans.SetPositionAndRotation(new Vector3(feoX, feoY), new Quaternion(0, 0, 0, 0));
                elFeo.SetActive(false);
                jugadorTrans.SetPositionAndRotation(new Vector3(adentroX, adentroY), new Quaternion(0, 0, 0, 0));
                adentroBano = true;
                if(Gamemanager.instancia.mateoSeguidor)
                {
                    mateoTrans.SetPositionAndRotation(new Vector3(mateoAdentroX, mateoAdentroY), new Quaternion(0, 0, 0, 0));
                }
                
            }
            if(adentroBano)
            {
                elFeo.SetActive(true);
                jugadorTrans.SetPositionAndRotation(new Vector3(afueraX, afueraY), new Quaternion(0, 0, 0, 0));
                adentroBano = false;
                if (Gamemanager.instancia.mateoSeguidor)
                {
                    mateoTrans.SetPositionAndRotation(new Vector3(mateoAfueraX, mateoAfueraY), new Quaternion(0, 0, 0, 0));
                }
            }
        }
    }
}

