using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cargarnivel : MonoBehaviour
{
    // Start is called before the first frame update
    public void cargarMenu()
    {
        SceneManager.LoadScene("Pantalla inicio", LoadSceneMode.Single);
    }
    public void cargarCasa()
    {
        SceneManager.LoadScene("Casa", LoadSceneMode.Single);
    }
}
