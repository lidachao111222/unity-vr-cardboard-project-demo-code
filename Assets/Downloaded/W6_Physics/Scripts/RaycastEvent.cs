using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastEvent : MonoBehaviour
{
   void FixedUpdate()
   {
       if (Physics.Raycast(transform.position, Vector3.up, 5f))
        {
            Debug.Log("There is something in front of the object!");
        }

        Debug.DrawRay(transform.position, Vector3.up*5f, Color.red);
    }
}
