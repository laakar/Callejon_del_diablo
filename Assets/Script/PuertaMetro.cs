using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaMetro : MonoBehaviour
{
    public GameObject puerta;
    public bool playerAdentro;
    public bool playerSafe;
    public float safeX;
    public float safeY;
    public float unsafeX;
    public float unsafeY;
    public Transform playerTrans, mateoTrans;
    public float mateoAdentroX, mateoAdentroY, mateoAfueraX, mateoAfueraY;
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
          
            if (!playerSafe)
            {
               // playerTrans.SetPositionAndRotation(new Vector3(safeX, safeY), new Quaternion(0, 0, 0, 0));
                playerSafe = true;
                if (Gamemanager.instancia.mateoSeguidor)
                {
                    mateoTrans.SetPositionAndRotation(new Vector3(mateoAdentroX, mateoAdentroY), new Quaternion(0, 0, 0, 0));
                }
            }

            else if (playerSafe)
            {
                playerTrans.SetPositionAndRotation(new Vector3(unsafeX, unsafeY), new Quaternion(0, 0, 0, 0));
                playerSafe = false;
                if (Gamemanager.instancia.mateoSeguidor)
                {
                    mateoTrans.SetPositionAndRotation(new Vector3(mateoAfueraX, mateoAfueraY), new Quaternion(0, 0, 0, 0));
                }
            }
        }
    }
}
