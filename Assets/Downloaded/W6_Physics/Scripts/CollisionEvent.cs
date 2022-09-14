using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    void OnCollisionEnter(Collision collision){
        GetComponent<Renderer>().material.color = Color.green;
    }
}

