using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cerrarJuego : MonoBehaviour
{
    public void salirJuego()
    {
        Application.Quit();
        Debug.Log("saliste del juego");
    }
}
