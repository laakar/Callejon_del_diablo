using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public static BarraDeVida vida;
    public int vidaMaxima = 100;
    public Slider sliderVida;
    private int damage = -25;

    public void Awake()
    {
        vida = this;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            vidaMaxima = vidaMaxima + damage;
        }
    }
    IEnumerator Example()
    {
        Gamemanager.instancia.Showtext("Usas el botiquin, recuperas vida.");
        yield return new WaitForSecondsRealtime(2f);
        Gamemanager.instancia.Hidetext();
    }

    public void Update()
    {
        sliderVida.value = vidaMaxima;
        if (Gamemanager.instancia.botiquinMomento && vidaMaxima <= 75)
        {
            vidaMaxima = vidaMaxima + 25;
            Gamemanager.instancia.botiquinMomento = false;
            StartCoroutine(Example());
        }
    }
}
