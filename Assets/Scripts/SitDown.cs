using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitDown : MonoBehaviour
{
    public GameObject objectToToggle;

    private bool status = true;


    public void toggleObject()
    {
         status = !status;

      if (status)
     {
           objectToToggle.transform.localScale = new Vector3(objectToToggle.transform.localScale.x , objectToToggle.transform.localScale.y*2 , objectToToggle.transform.localScale.z );
        }
     else
     {
            objectToToggle.transform.localScale = new Vector3(objectToToggle.transform.localScale.x, objectToToggle.transform.localScale.y/2, objectToToggle.transform.localScale.z);
        }

    }
}
