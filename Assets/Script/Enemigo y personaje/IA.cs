using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    public static IA instancia;
    public float velocidad;
    private Transform target;
    public bool touchingplayer;
    Vector2 movi;
    public Animator anima;
    public Transform tripas;

    private void Awake()
    {
        instancia = this;
    }
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
       
        
        transform.position = Vector2.MoveTowards(transform.position, target.position, velocidad * Time.deltaTime);
        anima.SetFloat("Horizontal",movi.x);
        anima.SetFloat("Vertical", movi.y);
        anima.SetFloat("Speed", tripas.position.sqrMagnitude);
    }
}
