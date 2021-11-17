using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public bool playerAdentro;
    public bool playerSafe;
    public GameObject elTripas;
    public float safeX;
    public float safeY;
    public float unsafeX;
    public float unsafeY;
    public float tripasX;
    public float tripasY;
    public Transform playerTrans;
    public Transform tripasTrans;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerAdentro = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerAdentro = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAdentro && (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("space")))
        {
            if(!playerSafe)
            {
                tripasTrans.SetPositionAndRotation(new Vector3(tripasX, tripasY), new Quaternion(0,0,0,0));
                elTripas.SetActive(false);
                playerTrans.SetPositionAndRotation(new Vector3(safeX, safeY), new Quaternion(0, 0, 0, 0));
                playerSafe = true;
            }

            else if(playerSafe)
            {
                elTripas.SetActive(true);
                playerTrans.SetPositionAndRotation(new Vector3(unsafeX, unsafeY), new Quaternion(0, 0, 0, 0));
                playerSafe = false;
            }
        }


    }
}
