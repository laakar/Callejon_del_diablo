using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorUno : MonoBehaviour
{
    public GameObject tepe;
    public GameObject enemigo;
    public float newX, newY;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IEnumerator Esperar()
        {
            yield return new WaitForSecondsRealtime(0.5f);
            gameObject.transform.Translate(new Vector2(newX, newY));
        }
        if (collision.CompareTag("Player"))
        {
            enemigo.SetActive(true);
            StartCoroutine(Esperar());
        }
    }
    public void Update()
    {
        if(Gamemanager.instancia.final1 && Gamemanager.instancia.final2 && Gamemanager.instancia.final3 && Gamemanager.instancia.final4)
        {
            tepe.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}