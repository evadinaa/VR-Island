using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEffects : MonoBehaviour
{
    [SerializeField] GameObject airFX;
    [SerializeField] Color fogColorOnEnter; // Set this to your desired fog color in the inspector

    private void OnTriggerEnter(Collider other)
    {
        airFX.gameObject.SetActive(true);
        RenderSettings.fog = true;
        RenderSettings.fogColor = fogColorOnEnter; // Change fog color
    }

    private void OnTriggerExit(Collider other)
    {
        airFX.gameObject.SetActive(false); // Disable the fire effect
        RenderSettings.fog = false; // Turn off fog
    }
}
