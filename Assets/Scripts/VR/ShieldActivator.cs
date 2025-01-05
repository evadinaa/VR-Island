using UnityEngine;

public class ShieldActivator : MonoBehaviour
{
    public ShieldController shieldController;

    public void Interact()
    {
        if (shieldController != null)
        {
            shieldController.ActivateShield();
            Debug.Log("IADE Island activated the shield!");
        }
        else
        {
            Debug.LogError("ShieldController not assigned to the ShieldActivator script!");
        }
    }
}
