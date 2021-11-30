using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enumObjetos : MonoBehaviour
{
    public bool playerinZone;
    public GameObject puertaUno, puertaFinal, llaveFinal, llaveUno, pentagrama, objetoFinal, timer;
    public float velo;
    
    public enum POSIBLES_CASOS
    {
        LLAVE_PUERTA_UNO,
        LLAVE_PUERTA_FINAL,
        BOTIQUIN,
        OBJETO_VACIO,
        NOTA_LLAVE_FINAL,
        PUERTA_UNO,
        PUERTA_FINAL,
        OBJETO_SGT_NIVEL,
        SIGUIENTE_NIVEL,
        SILLA_CAMA,
        TARJETA_EURIPIDES,
        TARJETA_DAGOBERTO,
        TARJETA_MARIO,
        ANASTACIO,
        EURIPIDES,
        DAGOBERTO,
        MARIO


    }

    IEnumerator enemigoEspera()
    {
        yield return new WaitForSecondsRealtime(1f);
        IA.instancia.velocidad = velo;
    }

    IEnumerator TiempoFunciones()
    {
        yield return new WaitForSecondsRealtime(2f);
        llaveUno.SetActive(false);
    }
    IEnumerator TiempoFunciones2()
    {
        yield return new WaitForSecondsRealtime(2f);
        llaveFinal.SetActive(false);
    }
    IEnumerator TiempoFunciones3()
    {
        yield return new WaitForSecondsRealtime(2f);
        objetoFinal.SetActive(false);
    }

    IEnumerator DagobertoMomentoXd()
    {
        Gamemanager.instancia.Showtext("Esta es la chaqueta que me pidio el fantasma... Su nombre es Dagoberto.");
        AnastacioMomento.instancia.tarjetaMomento = true;
        yield return new WaitForSecondsRealtime(2f);
        IA.instancia.velocidad = velo;
        AnastacioMomento.instancia.tarjeta.SetActive(false);
    }

    IEnumerator EuripidesFoto()
    {
        Gamemanager.instancia.Showtext("Esta es la tarjeta que me pidio el fantasma, su nombre es Euripides. Mejor se la entrego antes de que sea demasiado tarde.");
        timer.SetActive(false);
        DagobertoMomento.instancia.tarjetaMomento = true;
        yield return new WaitForSecondsRealtime(2f);
        IA.instancia.velocidad = velo;
        DagobertoMomento.instancia.tarjeta.SetActive(false);
    }
    IEnumerator MarioAdios()
    {
        Gamemanager.instancia.Showtext("Esta es la tarjeta que me pidio el fantasma... Su nombre es Mario.");
        MarioMomento.instancia.tarjetaMomento = true;
        yield return new WaitForSecondsRealtime(2f);
        IA.instancia.velocidad = velo;
        gameObject.SetActive(false);
    }
    IEnumerator AnastacioFinal()
    {
        Gamemanager.instancia.Showtext("Tu me ayudaste antes, dejame devolverte el favor. Habla con los demas fantasmas para poder escapar de aqui.");
        Gamemanager.instancia.final1 = true;
        yield return new WaitForSecondsRealtime(2f);
        IA.instancia.velocidad = velo;
        gameObject.SetActive(false);
    }
    IEnumerator EuripidesFinal()
    {
        Gamemanager.instancia.Showtext("¿SIGUES AQUI? NO TENGO TODO EL DIA, CORRE AL SIGUIENTE FANTASMA MIENTRAS AUN ESTOY DE BUEN HUMOR.");
        Gamemanager.instancia.final2 = true;
        yield return new WaitForSecondsRealtime(2f);
        IA.instancia.velocidad = velo;
        gameObject.SetActive(false);
    }
    IEnumerator DagobertoFinal()
    {
        Gamemanager.instancia.Showtext("Gracias por ayudarme, entre todos podemos romper el sello y ayudarte a escapar, no te rindas");
        Gamemanager.instancia.final3 = true;
        yield return new WaitForSecondsRealtime(2f);
        IA.instancia.velocidad = velo;
        gameObject.SetActive(false);
    }
    IEnumerator MarioFinal()
    {
        Gamemanager.instancia.Showtext("Corre hacia el pentagrama, nosotros romperemos el sello. No dejes que te atrape");
        Gamemanager.instancia.final4 = true;
        yield return new WaitForSecondsRealtime(2f);
        IA.instancia.velocidad = velo;
        gameObject.SetActive(false);
    }
    public POSIBLES_CASOS casos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerinZone = true;
            velo = IA.instancia.velocidad;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Gamemanager.instancia.Hidetext();
            playerinZone = false;
        }
    }

    private void Update()
    {
        if (playerinZone && (Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("space")))
        {
            IA.instancia.velocidad = 0;
            switch (casos)
            {
                case POSIBLES_CASOS.LLAVE_PUERTA_UNO:
                    
                    GameObject.FindGameObjectWithTag("Player").GetComponent<xd>().llavePuertaUno = true;
                    Gamemanager.instancia.Showtext("Una llave, quizas me sea útil...");
                    StartCoroutine(TiempoFunciones());
                    StartCoroutine(enemigoEspera());
                    
                    break;
                    

                case POSIBLES_CASOS.OBJETO_VACIO:
                    
                    Gamemanager.instancia.Showtext("Aquí no hay nada, seguire buscando");
                    StartCoroutine(enemigoEspera());
                    break;

                case POSIBLES_CASOS.PUERTA_UNO:
                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<xd>().llavePuertaUno == true)
                    {
                        puertaUno.SetActive(false);
                        Destroy(gameObject);
                        GameObject.FindGameObjectWithTag("Player").GetComponent<xd>().llavePuertaUno = false;
                    }
                    else
                    {
                        
                        Gamemanager.instancia.Showtext("Esta cerrada, creo que necesito una llave");
                        StartCoroutine(enemigoEspera());
                    }
                    break;

                case POSIBLES_CASOS.NOTA_LLAVE_FINAL:
                    
                    Gamemanager.instancia.Showtext("Encuentras una nota y dice lo siguiente: Recuerda, las llaves de repuesto estan escondidas en la cocina");
                    GameObject.FindGameObjectWithTag("Player").GetComponent<xd>().leerNota = true;
                    llaveFinal.SetActive(true);
                    StartCoroutine(enemigoEspera());
                    break;

                case POSIBLES_CASOS.LLAVE_PUERTA_FINAL:
                   
                    Gamemanager.instancia.Showtext("Creo que con esta llave deberia poder escapar");
                    GameObject.FindGameObjectWithTag("Player").GetComponent<xd>().llavePuertaFinal = true;
                    StartCoroutine(TiempoFunciones2());
                    StartCoroutine(enemigoEspera());
                    break;

                case POSIBLES_CASOS.PUERTA_FINAL:
                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<xd>().llavePuertaFinal == true)
                    {
                        puertaFinal.SetActive(false);
                        StartCoroutine(enemigoEspera());
                    }
                    else
                    {
                        
                        Gamemanager.instancia.Showtext("Esta cerrada, creo que necesito una llave");
                        StartCoroutine(enemigoEspera());
                    }
                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<xd>().llavePuertaUno == true)
                    {
                        
                        Gamemanager.instancia.Showtext("Esta no es la llave correcta, debo seguir investigando");
                        StartCoroutine(enemigoEspera());
                    }
                    break;

                case POSIBLES_CASOS.SILLA_CAMA:
                    
                    Gamemanager.instancia.Showtext("Este no es un buen momento para descansar");
                    StartCoroutine(enemigoEspera());
                    break;

                case POSIBLES_CASOS.BOTIQUIN:

                    Gamemanager.instancia.botiquinMomento = true;
                    Destroy(gameObject);
                    break;

                case POSIBLES_CASOS.OBJETO_SGT_NIVEL:

                    
                    GameObject.FindGameObjectWithTag("Player").GetComponent<xd>().objtSgtNivel = true;
                    Gamemanager.instancia.Showtext("Creo que escuche algo en la planta baja...., sera mejor que vaya a ver");
                    StartCoroutine(TiempoFunciones3());
                    pentagrama.SetActive(true);
                    StartCoroutine(enemigoEspera());
                    break;

                case POSIBLES_CASOS.SIGUIENTE_NIVEL:

                    if(GameObject.FindGameObjectWithTag("Player").GetComponent<xd>().objtSgtNivel == true)
                    {
                        SceneManager.LoadScene("Callejonxd", LoadSceneMode.Single);
                    }

                    break;
                    
                case POSIBLES_CASOS.TARJETA_EURIPIDES:
                    StartCoroutine(EuripidesFoto());
                    break;

                case POSIBLES_CASOS.TARJETA_DAGOBERTO:
                    StartCoroutine(DagobertoMomentoXd());
                    break;

                case POSIBLES_CASOS.TARJETA_MARIO:
                    StartCoroutine(MarioAdios());
                    break;

                case POSIBLES_CASOS.ANASTACIO:
                    IA.instancia.velocidad = 0;
                    StartCoroutine(AnastacioFinal());
                    break;

                case POSIBLES_CASOS.EURIPIDES:
                    IA.instancia.velocidad = 0;
                    StartCoroutine(EuripidesFinal());
                    break;

                case POSIBLES_CASOS.DAGOBERTO:
                    IA.instancia.velocidad = 0;
                    StartCoroutine(DagobertoFinal());
                    break;

                case POSIBLES_CASOS.MARIO:
                    IA.instancia.velocidad = 0;
                    StartCoroutine(MarioFinal());
                    break;
            }
        }
    }
}
