using UnityEngine;

public class ObjectRevealController : MonoBehaviour
{
    public GameObject objectToReveal; // The object that will become visible

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
    }

    // Call this method when the first object is interacted with
    public void RevealObject()
    {
        if (objectToReveal != null)
        {
            objectToReveal.SetActive(true); // Make the target object visible
            Debug.Log(objectToReveal.name + " is now visible!");
        }
    }
}

