using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    public static Gamemanager instancia;
    public CanvasGroup paneltexto;
    public TextMeshProUGUI texto;
    public bool keymoment;
    public bool palamoment;
    public bool primeraFoto;
    public bool segundaFoto;
    public bool terceraFoto;
    private void Awake()
    {
        instancia = this;
    }
    
    public void Showtext(string textoposible)
    {
        paneltexto.alpha = 1;
        texto.text = textoposible;
    }

    public void Hidetext()
    {
        paneltexto.alpha = 0;
        texto.text = "";
    }
    public void LlaveOk()
    {
        keymoment = true;
    }
    public void PalaOk()
    {
        palamoment = true;
    }
}