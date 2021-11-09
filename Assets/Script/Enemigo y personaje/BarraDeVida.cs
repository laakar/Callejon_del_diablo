using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    private int vidaMaxima = 100;
    public Slider sliderVida;
    private int damage = -25;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            vidaMaxima = vidaMaxima + damage;
            sliderVida.value = vidaMaxima;
        }
    }
}
