using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool isOn;
    public Light light;
    public AudioSource audioSource;
    public AudioClip switchSound;

    void Start()
    {

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        light.enabled = isOn;

        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;


            if (audioSource != null && switchSound != null)
            {
                audioSource.PlayOneShot(switchSound);
            }
        }
    }
}