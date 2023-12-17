using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool isOn;
    public Light light;
    public AudioSource audioSource;
    public AudioClip switchSound;

    public int electricity;
    public int usagePerSecond;
    int fullBattery;

    public TMP_Text text;

    bool drainingBattery;
    float defaultIntensity = 2f;
    float currentIntensity;

    void Start()
    {
        fullBattery = electricity;
        currentIntensity = defaultIntensity;

        if (light != null)
        {
            light.intensity = currentIntensity;
        }

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
            if (electricity > 0)
            {
                isOn = !isOn;

                if (isOn)
                {
                    drainingBattery = true;
                    InvokeRepeating("TurnedOn", 1f, 1f);
                }
                else
                {
                    drainingBattery = false;
                    StartCoroutine(FadeOutLight());
                    CancelInvoke("TurnedOn");
                }

                if (audioSource != null && switchSound != null)
                {
                    audioSource.PlayOneShot(switchSound);
                }
            }
        }

        if (isOn && drainingBattery) // Check if the flashlight is on and draining the battery
        {
            int percentage = (electricity * 100) / fullBattery;
            if (electricity > 0)
            {
                text.text = ("ϟ ") + percentage.ToString() + ("%");
                UpdateIntensity(percentage);
            }
            else
            {
                text.text = ("ϟ ") + "0%";
                isOn = false; // Turn off the flashlight if the battery is depleted
                StartCoroutine(FadeOutLight());
                CancelInvoke("TurnedOn");
            }
        }
    }

    void UpdateIntensity(int percentage)
    {
        float intensityPercentage = (float)percentage / 100;
        float newIntensity = defaultIntensity * intensityPercentage;

        if (light != null)
        {
            light.intensity = newIntensity;
        }
    }

    IEnumerator FadeOutLight()
    {
        while (light.intensity > 0)
        {
            light.intensity -= Time.deltaTime * defaultIntensity;
            yield return null;
        }
        light.intensity = 0;
    }

    private void TurnedOn()
    {
        electricity -= usagePerSecond;
    }
}
