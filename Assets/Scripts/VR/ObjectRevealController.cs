using UnityEngine;

public class ObjectRevealController : MonoBehaviour
{
    public GameObject objectToReveal; // The object that will become visible
    public AudioClip portalSFX; // The sound effect to play
    private AudioSource audioSource; // Reference to the AudioSource

    void Start()
    {
        // Ensure the target object is initially hidden
        if (objectToReveal != null)
        {
            objectToReveal.SetActive(false);
        }
        else
        {
            Debug.LogError("No object assigned to reveal!");
        }

        // Try to get or add an AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Call this method when the first object is interacted with
    public void RevealObject()
    {
        if (objectToReveal != null)
        {
            objectToReveal.SetActive(true); // Make the target object visible
            Debug.Log(objectToReveal.name + " is now visible!");

            // Play the portal SFX if assigned
            if (portalSFX != null)
            {
                audioSource.clip = portalSFX;
                audioSource.Play();
                Debug.Log("Portal SFX played!");
            }
            else
            {
                Debug.LogWarning("Portal SFX is not assigned!");
            }
        }
    }
}


