using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctm : Interactuable
{
    public Sprite open;
    public Sprite closed;

    private SpriteRenderer sr;
    private bool isOpen;
    public override void Interact()
    {
       if(isOpen)
        {
            sr.sprite = closed;
        }
       else
        {
            sr.sprite = open;
        }
        isOpen = !isOpen;
    }

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
