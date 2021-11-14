using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xd : MonoBehaviour
{
    public float velocidad = 5f;
    public bool llavePuertaUno;
    public bool llavePuertaFinal;
    Rigidbody2D rb2d;
    Vector2 mov;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        mov = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + mov * velocidad * Time.deltaTime);
    }
}
