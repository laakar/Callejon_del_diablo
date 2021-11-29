using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraDeVida : MonoBehaviour
{
    public static BarraDeVida vida;
    public int vidaMaxima = 100;
    public Slider sliderVida;
    private int damage = -10;
    public Image vidas;
    public Sprite[] spriteVidas;

    public void Awake()
    {
        vida = this;
        vidas = GameObject.Find("vida").GetComponent<Image>();
        vidas.sprite = spriteVidas[0];
    }

    IEnumerator esperaEnemigo()
    {
        float velocidad = IA.instancia.velocidad;
        IA.instancia.velocidad = 0;
        yield return new WaitForSecondsRealtime(2f);
        IA.instancia.velocidad = velocidad;
    }

    public void Update()
    {
        //sliderVida.value = vidaMaxima;
        if (Gamemanager.instancia.botiquinMomento && vidaMaxima <= 75)
        {
            vidaMaxima = vidaMaxima + 25;
            Gamemanager.instancia.botiquinMomento = false;
            StartCoroutine(Example());
        }

        if (vidaMaxima == 0)
        {
            SceneManager.LoadScene("Pantalla Gameover");
        }
        vidas.sprite = cambiarVida();
        //print(vidaMaxima);
    }
     public Sprite cambiarVida()
    {
        if(vidaMaxima>=90)
        {
            return spriteVidas[0];
        }
        else
            if (vidaMaxima >= 80 && vidaMaxima < 90)
            {
                return spriteVidas[1];
            }else
            if (vidaMaxima >= 70 && vidaMaxima < 80)
            {
                return spriteVidas[2];
            }else
            if (vidaMaxima >= 60 && vidaMaxima < 70)
            {
                return spriteVidas[3];
            }else
            if (vidaMaxima >= 50 && vidaMaxima < 60)
            {
                return spriteVidas[4];
            }else
            if (vidaMaxima >= 40 && vidaMaxima < 50)
            {
                return spriteVidas[5];
            }else
            if (vidaMaxima >= 30 && vidaMaxima < 40)
            {
                return spriteVidas[6];
            }else
            if (vidaMaxima >= 20 && vidaMaxima < 30)
            {
                return spriteVidas[7];
            }else
            if (vidaMaxima >= 10 && vidaMaxima < 20)
            {
                return spriteVidas[8];
            }else
            {
                return spriteVidas[9];
            }
        //return vidaAux;
    }
    IEnumerator Example()
    {
        Gamemanager.instancia.Showtext("Usas el botiquin, recuperas vida.");
        yield return new WaitForSecondsRealtime(2f);
        Gamemanager.instancia.Hidetext();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            vidaMaxima = vidaMaxima + damage;
            StartCoroutine(esperaEnemigo());
        }
    }
}
