using UnityEngine;

public class RotateYAxis : MonoBehaviour
{
    // Velocidade de rotação em graus por segundo
    [SerializeField] public float rotationSpeed = 5f;

    void Update()
    {
        // Rotaciona o objeto ao longo do eixo Y
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}

