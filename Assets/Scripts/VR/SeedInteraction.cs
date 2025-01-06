using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SeedInteraction : MonoBehaviour
{
    public GameObject seedEffect; // Efeito especial do seed a ser desativado após a pegada

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        // Referência ao XRGrabInteractable
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Inscreva-se nos eventos de interação
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    void OnDestroy()
    {
        // Remova os eventos ao destruir o objeto
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Desative o efeito especial
        if (seedEffect != null)
        {
            seedEffect.SetActive(false);
        }

        Debug.Log("Seed has been grabbed!");
    }
}


