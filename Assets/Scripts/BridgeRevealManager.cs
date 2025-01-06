using UnityEngine;

public class BridgeRevealManager : MonoBehaviour
{
    public float bridgeFadeDuration = 3.0f; // Time for the bridge to fully reveal

    private Renderer bridgeRenderer;

    void Start()
    {
        bridgeRenderer = GetComponent<Renderer>();
        SetBridgeTransparency(0f); // Start fully transparent
        gameObject.SetActive(false); // Initially hidden
    }

    public void StartBridgeReveal()
    {
        gameObject.SetActive(true); // Activate bridge
        StartCoroutine(FadeInBridge());
    }

    System.Collections.IEnumerator FadeInBridge()
    {
        float elapsedTime = 0f;
        Color color = bridgeRenderer.material.color;
        float initialAlpha = color.a;

        while (elapsedTime < bridgeFadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(initialAlpha, 1f, elapsedTime / bridgeFadeDuration); // Gradually increase alpha
            bridgeRenderer.material.color = color;
            yield return null;
        }

        color.a = 1f; // Fully opaque
        bridgeRenderer.material.color = color;
    }

    void SetBridgeTransparency(float alpha)
    {
        if (bridgeRenderer)
        {
            Color color = bridgeRenderer.material.color;
            color.a = alpha;
            bridgeRenderer.material.color = color;
        }
    }
}

