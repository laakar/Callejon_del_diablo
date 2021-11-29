using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mateopara : MonoBehaviour
{
    public bool tocandoplayer;
    public Rigidbody2D rb2d;
    public Animator animator;
    void Start()
    {
        tocandoplayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (tocandoplayer == true)
        {
            rb2d.velocity = new Vector2(0, 0);
            animator.SetFloat("Speed", rb2d.velocity.sqrMagnitude);
        }
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameObject.FindGameObjectWithTag("mateo"))
        {
            if (collision.CompareTag("Player"))
            {
                tocandoplayer = true;
            }
            
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GameObject.FindGameObjectWithTag("mateo"))
        {
            if (collision.CompareTag("Player"))
            {
                tocandoplayer = false;
            }

        }

    }
}
