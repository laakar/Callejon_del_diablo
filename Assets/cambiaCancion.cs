using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiaCancion : MonoBehaviour
{
    public AudioSource audioSrc;
    public enum MUSICA
    {
            STOP_CANCION1, STOP_CANCION2, PLAY_CANCION1, PLAY_CANCION2
    }

    public MUSICA musica;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (musica)
        {
            case MUSICA.STOP_CANCION1:
            if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>())
                {
                    audioSrc.Stop();
                }
                break;
            case MUSICA.PLAY_CANCION1:
                if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>())
                    audioSrc.Play();
                break;
            case MUSICA.STOP_CANCION2:
                if(GameObject.FindGameObjectWithTag("musica").GetComponent<AudioSource>())
                    audioSrc.Stop();
                break;
            case MUSICA.PLAY_CANCION2:
                if (GameObject.FindGameObjectWithTag("musica").GetComponent<AudioSource>())
                    audioSrc.Play();
                break;
        }
            
    }
}
