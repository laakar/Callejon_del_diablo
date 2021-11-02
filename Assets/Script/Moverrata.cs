using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Moverrata : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject iconomortal;
    public Transform Ratatransform;
    // Añade una variante transform
    public float Speedmouse = 10;
    // Añade una variante float
    public SpriteRenderer Ratarend;
    //añade una variable spriterenderer
    public Animator run;
    //añade una variable Animator
    private Vector2 boxSize = new Vector2(0.5f, 1f);
    void Start()
    {
        iconomortal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)) //se activa al apretar la tecla D
        {
            Ratatransform.Translate(Vector2.right * Time.deltaTime * Speedmouse);// mueve el objeto a la izquierda
            Ratarend.flipX = false;// gira el sprite
            run.SetFloat("Movimiento", Speedmouse);//activa la animacion de movimiento
        }
        if (Input.GetKey(KeyCode.A))//se activa al apretar la tecla A
        {
            Ratatransform.Translate(Vector2.left * Time.deltaTime * Speedmouse);//mueve el objeto a la derecha
            Ratarend.flipX = true;
            run.SetFloat("Movimiento", Speedmouse);

        }
        if (Input.GetKey(KeyCode.W))//se activa al apretar la tecla W
        {
            Ratatransform.Translate(Vector2.up * Time.deltaTime * Speedmouse);//mueve el objeto hacia arriba
            run.SetFloat("Movimiento", Speedmouse);
        }
        if (Input.GetKey(KeyCode.S))//se activa al apretar la tecla D
        {
            Ratatransform.Translate(Vector2.down * Time.deltaTime * Speedmouse);//mueve el objeto hacia abajo
            run.SetFloat("Movimiento", Speedmouse);
        }
        if (Input.GetKey(KeyCode.E))
        {
            Checkinteraction();
        
        
        
        
        }//se activa al apretar la tecla D



    }
    public void OpenInteractableIcon()
    {
        iconomortal.SetActive(true);
    }

    public void CloseInteractableIcon()
    {
        iconomortal.SetActive(false);
    }
    private void Checkinteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position,boxSize, 0,Vector2.zero);
        if(hits.Length > 0)
        {
            foreach(RaycastHit2D rc in hits)
            {
                if(rc.transform.GetComponent<Interactuable>())
                {
                    rc.transform.GetComponent<Interactuable>().Interact();
                    return;
                }
            }
        }
    }
}
