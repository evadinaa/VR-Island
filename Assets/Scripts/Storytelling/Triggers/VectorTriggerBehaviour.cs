using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Storytelling
{
    public class VectorTriggerBehaviour : MonoBehaviour
    {
        // A list of actions to be performed when triggered
        [SerializeField]
        public List<VectorActionBehaviour> actions;

        // Method to update the object's position, customizable in derived classes
        public virtual void UpdatePosition()
        {
            // Logic for position update will be implemented by subclasses
        }

        // Executes all actions in the list using the provided Vector3 parameter
        public void ExecuteActions(Vector3 vector)
        {
            if (actions == null || actions.Count == 0) return;

            foreach (VectorActionBehaviour action in actions)
            {
                action.PerformAction(vector);
            }
        }
    }
}
