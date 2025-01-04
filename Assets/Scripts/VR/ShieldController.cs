using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShieldController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    public LightTunnelTransition transitionHandler;
    public Transform playerTransform; // Referência ao transform do Player
    public bool isInsideShield = false;

    void Start()
    {
        characterController = FindObjectOfType<CharacterController>();
        animator = GetComponent<Animator>();

        // Verifica se o script foi atribuído no Inspector ou tenta localizá-lo na cena
        if (transitionHandler == null)
        {
            transitionHandler = FindObjectOfType<LightTunnelTransition>();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideShield = true;
            playerTransform.SetParent(transform);  // Torna o player filho do escudo, seguindo o movimento

        // Bloqueia movimentos do jogador
        if (characterController != null) characterController.enabled = false;

            // Inicia a animação
            if (animator != null)
            {
                animator.SetTrigger("StartAnimation");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideShield = false;
            playerTransform.SetParent(null);  // Remove o player da hierarquia do escudo, permitindo a movimentação independente
            // Restaura movimentos apenas se necessário (não será o caso com Scene Change)

            if (characterController != null) characterController.enabled = true;
        }
    }

        // chamado pelo evento da animação
        public void TriggerTransition()
    {
        {
            if (transitionHandler != null)
            {
                transitionHandler.StartTransition(); // chama o method público no LightTunnelTransition
            }
            else
            {
                Debug.LogError("TransitionHandler não foi atribuído no Inspector ou encontrado na cena!");
            }
        }
    }

}

