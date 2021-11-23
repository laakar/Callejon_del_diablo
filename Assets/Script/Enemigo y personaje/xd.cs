using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xd : MonoBehaviour
{
    public float velocidad = 5f;
    public bool llavePuertaUno;
    public bool llavePuertaFinal;
    public bool objtSgtNivel;
    public bool leerNota;
    Rigidbody2D rb2d;
    Vector2 mov;
    public Animator anim;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        mov.x = Input.GetAxisRaw("Horizontal");
        mov.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", mov.x);
        anim.SetFloat("Vertical", mov.y);
        anim.SetFloat("Speed", mov.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + mov * velocidad * Time.deltaTime);
    }
}
