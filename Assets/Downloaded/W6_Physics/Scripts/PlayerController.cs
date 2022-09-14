using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public float speed;
    private int score;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveVertical, moveHorizontal * -1, 0f);
        rb.AddTorque(movement * speed);
    }

    private void OnTriggerEnter(Collider collision)
    { 
        if(collision.transform.tag == "food")
        { 
            score++; // Increase the score
            Destroy(collision.gameObject); 
            this.transform.localScale *= 2.0f;
        }
    }
}
