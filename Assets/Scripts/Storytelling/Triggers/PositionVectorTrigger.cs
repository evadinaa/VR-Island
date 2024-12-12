using System.Collections.Generic;
using UnityEngine;

namespace Storytelling
{
    public class PositionVectorTrigger : VectorTriggerBehaviour
    {
        // Player's transform reference
        [Tooltip("Assign the player's transform here.")]
        public Transform player;

        // To store the player's initial position
        private Vector3 initialPosition;

        private void Start()
        {
            // Save the player's initial position
            if (player != null)
            {
                initialPosition = player.position;
            }
            else
            {
                Debug.LogError("Player transform is missing! Please assign it in the inspector.");
            }
        }

        private void FixedUpdate()
        {
            // Continuously update the player's relative position
            UpdatePosition();
        }

        public override void UpdatePosition()
        {
            if (player == null)
            {
                Debug.LogError("Cannot update position as the player transform is not set!");
                return;
            }

            // Calculate the relative position based on the player's movement
            Vector3 relativePosition = player.position - initialPosition;

            // Trigger all assigned actions using the calculated relative position
            foreach (var action in actions)
            {
                if (action != null)
                {
                    action.PerformAction(relativePosition);
                }
            }
        }
    }
}


