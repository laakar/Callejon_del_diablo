using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crisis : MonoBehaviour
{
    public float velocidad = 5f;
    public bool llavePuertaUno;
    public bool llavePuertaFinal;


    Rigidbody2D rb2d;
    private float Horizontal;
    private float Vertical;
    private Animator animator;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    void Update()
    {

        Horizontal = Input.GetAxisRaw("Horizontal");
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        animator.SetBool("dercha", Horizontal != 0.0f);
        Vertical = Input.GetAxisRaw("Vertical");
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        animator.SetBool("arriba", Vertical != 0.0f);
    }
    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(Horizontal * velocidad, Vertical * velocidad);
    }
}
