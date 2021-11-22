using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer instancia;
    public float timer;
    public TextMeshProUGUI timerText;
    public bool timerMomento;
    public GameObject tarjeta;
    public string sinTiempo;

    public void Awake()
    {
        instancia = this;
    }

    IEnumerator Example()
    {
        Gamemanager.instancia.Showtext(sinTiempo);
        yield return new WaitForSeconds(5);
        Gamemanager.instancia.Hidetext();
    }

    public void Update()
    {
        if (timerMomento)
        {
            timerText.text = "" + (int)timer;
            if(timer > 0)
            {
                timer -= 1 * Time.deltaTime;
            }
            else if (timer == 0)
            {
                tarjeta.SetActive(false);
                DagobertoMomento.instancia.tarjetaMomento = false;
                StartCoroutine(Example());
            }
        }
    }
}
