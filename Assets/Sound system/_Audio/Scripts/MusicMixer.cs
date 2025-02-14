using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicMixer : MonoBehaviour
{
    public AudioMixerSnapshot Area1;
    public AudioMixerSnapshot Area2;
    public AudioMixerSnapshot Area3;
    public AudioMixerSnapshot Area4;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Area1"))
        {
            Area1.TransitionTo(5);
        }

        if (other.CompareTag("Area2"))
        {
            Area2.TransitionTo(2);
        }

        if (other.CompareTag("Area3"))
        {
            Area3.TransitionTo(5);
        }

        if (other.CompareTag("Area4"))
        {
            Area3.TransitionTo(3);
        }
    }





}
