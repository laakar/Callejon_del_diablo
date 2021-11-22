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

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            eltripas.position = new Vector2(-2.5f, 55.54f);
            audioSrc.Play();
        }
        Destroy(gameObject);
    }
}
