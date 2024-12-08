using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderFireEffects : MonoBehaviour
{
    [SerializeField] GameObject fireFX;
    [SerializeField] Color fogColorOnEnter = new Color(0.63f, 0.32f, 0.18f); // Set this to your desired fog color in the inspector

    private void OnTriggerEnter(Collider other)
    {
        fireFX.gameObject.SetActive(true);
        RenderSettings.fog = true;
        RenderSettings.fogColor = fogColorOnEnter; // Change fog color
    }

    private void OnTriggerExit(Collider other)
    {
        fireFX.gameObject.SetActive(false); // Disable the fire effect
        RenderSettings.fog = false; // Turn off fog
    }
}
