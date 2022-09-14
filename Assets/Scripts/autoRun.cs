using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRun : MonoBehaviour
{
    // We use the variable to toggle player movement.
    bool isMoving = false;
    
    // Repeat the sound if player walk.
    bool isSoundRun = false;

    // Foot sound
    private AudioSource footSound;
     

    // Set the movement speed. Can also be set in the Inspector under the this script's component.
    public float movementSpeed = 2;

    [SerializeField] AudioClip footSoundClip;

    private void Start()
    {
        footSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame.
    void Update()
    {
        // If the mouse button (or headset switch) is pressed, toggle the isMoving variable.
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = isMoving ? false : true;
        }

        // if sit then stop moving.
        if (transform.position.y == 1)
        {
            isMoving = false;
        }

        // If the isMoving variable is true, we move the object this script is attached in the direction the main camera is facing (the XR camera) at the speed set in the movementSpeed variable.
        if (isMoving)
        {
            transform.position += new Vector3(Camera.main.transform.forward.x * Time.deltaTime * movementSpeed, 0, Camera.main.transform.forward.z * Time.deltaTime * movementSpeed);
            // when player walk, player the sound.
            if (!isSoundRun)
            {
                footSound.clip = footSoundClip;
                footSound.loop = true;
                footSound.Play();
                isSoundRun = true;
            }
        }
        else
        {
            // stop the sound when player stop.
            if (isSoundRun)
            {
                footSound.Stop();
                footSound.clip = null;
                footSound.loop = false;
                isSoundRun = false;
            }
        }

   
        
    }
}
