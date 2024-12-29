using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto entrou no trigger: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("O Player ativou o trigger!");
        }
    }
}

