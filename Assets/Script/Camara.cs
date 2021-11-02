using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject character;
    void Update()
    {
        Vector3 position = transform.position;
        position.x = character.transform.position.x;
        position.y = character.transform.position.y;
        transform.position = position;
    }
}
