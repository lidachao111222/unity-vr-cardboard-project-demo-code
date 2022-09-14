using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageBGM : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip clipBgm;

    public GameObject objectToToggle;

    private bool status = true;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    
    }


    public void toggleObject()
    {
        status = !status;

        if (status)
        {
            audioSource.Stop();
            audioSource.clip = null;
            audioSource.loop = false;
        }
        else
        {
            audioSource.clip = clipBgm;
            audioSource.loop = true;
            audioSource.Play();
        }

    }
}
