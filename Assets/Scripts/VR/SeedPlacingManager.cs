using UnityEngine;

public class SeedPlacingManager : MonoBehaviour
{
    public GameObject tree;             // The tree object
    public GameObject magicCircle;      // The magic circle object
    public GameObject seed;             // The seed object
    public GameObject explosionEffect;  // Explosion effect before the bridge reveal
    public BridgeRevealManager bridgeRevealManager; // Reference to the bridge reveal manager

    private Animator treeAnimator;

    void Start()
    {
        tree.SetActive(false); // Tree starts hidden
        explosionEffect.SetActive(false); // Explosion starts disabled
        treeAnimator = tree.GetComponent<Animator>();
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

        // Trigger explosion after animation finishes
        Invoke("TriggerExplosion", treeAnimator.GetCurrentAnimatorStateInfo(0).length);
    }

    void TriggerExplosion()
    {
        if (explosionEffect) explosionEffect.SetActive(true);

        // Notify bridge reveal script to start
        if (bridgeRevealManager) bridgeRevealManager.StartBridgeReveal();

        // Disable the explosion effect after a short time
        Destroy(explosionEffect, 2.0f); // Adjust time as needed
    }
}
