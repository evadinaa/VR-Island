using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Storytelling
{
    public class VectorActionBehaviour : MonoBehaviour
    {
        // Option to log debug information for actions
        [Header("Debug Settings")]
        public bool enableLogging = false;

        // Method to define an action based on a given Vector3 input
        public virtual void PerformAction(Vector3 inputVector)
        {
            // To be implemented in child classes with specific logic
            if (enableLogging)
            {
                Debug.Log($"Action executed with vector: {inputVector}");
            }
        }
    }
}
