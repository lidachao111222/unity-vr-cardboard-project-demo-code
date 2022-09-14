using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    public GameObject objectToToggle;

    private bool status = true;


    public void toggleObject()
    {
         status = !status;

        //hide
        // objectToToggle.SetActive(status);


        // change color
        /*     if (status)
             {
                 objectToToggle.GetComponent<Renderer>().material.color = Color.yellow;
             }
             else
             {
                 objectToToggle.GetComponent<Renderer>().material.color = Color.red;
             }
     */

      if (status)
     {
           objectToToggle.transform.localScale = new Vector3(objectToToggle.transform.localScale.x , objectToToggle.transform.localScale.y*2 , objectToToggle.transform.localScale.z );
        }
     else
     {
            objectToToggle.transform.localScale = new Vector3(objectToToggle.transform.localScale.x, objectToToggle.transform.localScale.y/2, objectToToggle.transform.localScale.z);
        }

}

private void Start()
{

}

void Update()
{
/*     if (!status)
{
objectToToggle.transform.position = new Vector3(objectToToggle.transform.position.x, objectToToggle.transform.position.y + 0.01f , objectToToggle.transform.position.z);
}*/
    }
}
