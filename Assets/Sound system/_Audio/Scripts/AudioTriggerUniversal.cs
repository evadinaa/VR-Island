using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioTriggerUniversal : MonoBehaviour
{
    private AudioSource audioS;
    public AudioClip triggerSound; // Som que será tocado
    public bool useGrabInteraction = false; // Ativar som ao pegar no VR
    public bool destroyAfterSound = false; // Destruir objeto após o som
    public bool useTriggerInteraction = false; // Ativar som ao entrar em trigger

    void Start()
    {
        // Tenta encontrar ou adicionar o AudioSource
        audioS = GetComponent<AudioSource>();
        if (audioS == null)
        {
            audioS = gameObject.AddComponent<AudioSource>();
        }

        // Verifica se é um objeto VR e se precisa de interações de Grab
        if (useGrabInteraction)
        {
            var grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            if (grabInteractable != null)
            {
                // Liga o evento de grab
                grabInteractable.selectEntered.AddListener(OnGrab);
            }
            else
            {
                Debug.LogWarning("Grab Interaction está ativado, mas não há XRGrabInteractable no objeto!");
            }
        }
    }

    // Toca o som e executa ações comuns
    private void PlaySound()
    {
        if (audioS != null && triggerSound != null)
        {
            audioS.PlayOneShot(triggerSound);
            Debug.Log("Som reproduzido: " + triggerSound.name);

            if (destroyAfterSound)
            {
                GetComponent<Collider>().enabled = false;
                //Destroy(gameObject, triggerSound.length);
            }
        }
        else
        {
            Debug.LogWarning("AudioSource ou TriggerSound não estão configurados!");
        }
    }

    // Chamado quando o objeto é pego no VR
    private void OnGrab(SelectEnterEventArgs args)
    {
        PlaySound();
    }

    // Chamado quando o Player entra no Trigger
    private void OnTriggerEnter(Collider other)
    {
        if (useTriggerInteraction && other.CompareTag("Player"))
        {
            PlaySound();
        }
    }
}

