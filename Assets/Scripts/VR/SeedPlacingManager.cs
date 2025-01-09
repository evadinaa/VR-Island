using UnityEngine;

public class SeedPlacingManager : MonoBehaviour
{
    public GameObject tree; // The tree object
    public GameObject magicCircle; // The magic circle object
    public GameObject seed; // The seed object
    public GameObject bridge; // The bridge to activate
    public AudioClip treeGrowSound; // SFX for tree growing

    private AudioSource audioSource;
    private Animator treeAnimator;

    void Start()
    {
        // Ensure tree and bridge are initially hidden
        if (tree) tree.SetActive(false);
        if (bridge) bridge.SetActive(false);

        // Try to get or add an AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Get the tree animator
        treeAnimator = tree ? tree.GetComponent<Animator>() : null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Seed"))
        {
            PlaceSeed();
        }
    }

    void PlaceSeed()
    {
        // Disable seed and magic circle
        if (magicCircle) magicCircle.SetActive(false);
        if (seed) seed.SetActive(false);

        // Show tree and start animation
        if (tree) tree.SetActive(true);
        if (treeAnimator) treeAnimator.Play("BloomEffect");

        // Play tree growth sound
        if (audioSource && treeGrowSound) audioSource.PlayOneShot(treeGrowSound);

        // Activate bridge after animation finishes
        if (treeAnimator != null)
        {
            float animationLength = treeAnimator.GetCurrentAnimatorStateInfo(0).length;
            Invoke("ActivateBridge", animationLength);
        }
        else
        {
            ActivateBridge(); // If no animation, activate immediately
        }
    }

    void ActivateBridge()
    {
        if (bridge)
        {
            bridge.SetActive(true); // Make the bridge visible
            Debug.Log("Bridge is now visible!");
        }
        else
        {
            Debug.LogError("Bridge GameObject is not assigned!");
        }
    }
}
