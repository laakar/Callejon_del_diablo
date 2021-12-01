using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public bool playerAdentro;
    public bool playerSafe;
    public GameObject elTripas, luzSegura, luzPlayer;
    public float safeX;
    public float safeY;
    public float unsafeX;
    public float unsafeY;
    public float tripasX;
    public float tripasY;
    public Transform playerTrans, mateoTrans;
    public Transform tripasTrans;
    public AudioSource cancionFea;
    public AudioSource cancionLinda;
    public float mateoAdentroX, mateoAdentroY, mateoAfueraX, mateoAfueraY, velo;

    public Sprite puertaAbierta;
    public GameObject puerta;

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
                puerta.GetComponent<SpriteRenderer>().sprite = puertaAbierta;
                puerta.GetComponent<BoxCollider2D>().isTrigger = false;

                cancionFea.Stop();
                cancionLinda.Play();
                tripasTrans.SetPositionAndRotation(new Vector3(tripasX, tripasY), new Quaternion(0,0,0,0));
                elTripas.SetActive(false);
                playerTrans.SetPositionAndRotation(new Vector3(safeX, safeY), new Quaternion(0, 0, 0, 0));
                playerSafe = true;
                luzSegura.SetActive(true);
                luzPlayer.SetActive(false);
                if (Gamemanager.instancia.mateoSeguidor)
                {
                    mateoTrans.SetPositionAndRotation(new Vector3(mateoAdentroX, mateoAdentroY), new Quaternion(0, 0, 0, 0));
                }
            }

            else if(playerSafe)
            {
                cancionLinda.Stop();
                cancionFea.Play();
                elTripas.SetActive(true);
                IA.instancia.velocidad = velo;
                playerTrans.SetPositionAndRotation(new Vector3(unsafeX, unsafeY), new Quaternion(0, 0, 0, 0));
                playerSafe = false;
                luzSegura.SetActive(false);
                luzPlayer.SetActive(true);
                if (Gamemanager.instancia.mateoSeguidor)
                {
                    mateoTrans.SetPositionAndRotation(new Vector3(mateoAfueraX, mateoAfueraY), new Quaternion(0, 0, 0, 0));
                }
            }
        }
    }
}
