using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpEnemigo : MonoBehaviour
{
    public Transform eltripas;
    public AudioSource audioSrc;
    void Start()
    {
        
    }

    public enum TP_ENEMIGO
    {
        PASILLO,
        PASILLO_2,
        HABITACION_1,
        BANO_2,
        PRINCIPIO
    }
    public TP_ENEMIGO tpEnem;
    IEnumerator esperar()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Destroy(gameObject);
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           switch (tpEnem)
            {
                case TP_ENEMIGO.PASILLO:
                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<xd>().llavePuertaUno == true)
                    {
                        eltripas.position = new Vector2(-2.5f, 55.54f);
                        audioSrc.Play();
                        StartCoroutine(esperar());
                    }
                    break;

                case TP_ENEMIGO.PASILLO_2:
                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<xd>().leerNota == true)
                    {
                        eltripas.position = new Vector2(5.67f, 3.7f);
                        audioSrc.Play();
                        StartCoroutine(esperar());
                    }
                    break;

                case TP_ENEMIGO.HABITACION_1:

                    eltripas.position = new Vector2(2.91f, 34.97f);
                    audioSrc.Play();
                    StartCoroutine(esperar());
                    break;

                case TP_ENEMIGO.BANO_2:

                    eltripas.position = new Vector2(-11.40f, 35.12f);
                    audioSrc.Play();
                    StartCoroutine(esperar());
                    break;

                case TP_ENEMIGO.PRINCIPIO:

                    if(GameObject.FindGameObjectWithTag("Player").GetComponent<xd>().objtSgtNivel == true)
                    {
                        eltripas.position = new Vector2(-11.51f, -7.48f);
                        audioSrc.Play();
                        StartCoroutine(esperar());
                    }
                    break;
            }
        }
    }
}
