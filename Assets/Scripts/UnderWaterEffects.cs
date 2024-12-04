using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterEffects : MonoBehaviour
{
    [SerializeField] GameObject waterFX;


    private void OnTriggerEnter(Collider other)
    {
        waterFX.gameObject.SetActive(true);
        RenderSettings.fog = true;
    }


    private void OnTriggerExit(Collider other)
    {
        //waterFX.gameObject.SetActive(false);
        RenderSettings.fog = false;
    }
}
