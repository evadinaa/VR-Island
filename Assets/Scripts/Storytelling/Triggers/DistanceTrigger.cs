using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Storytelling.Triggers
{
    /// <summary>
    /// Triggers actions based on the distance of the player from the
    /// attached GameObject.
    /// </summary>
    public class DistanceTrigger : TriggerBehaviour
    {
        public float triggerDistance;
        public int checkDelay = 5;
        private int delayCounter = 0;

        void FixedUpdate()
        {
            if (delayCounter < checkDelay)
            {
                delayCounter++;
                return;
            }

            CheckTriggered();
            delayCounter = 0;
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, triggerDistance);
        }
        
        public override void CheckTriggered()
        {
            bool isNear = Vector3.Distance(transform.position, initiator.transform.position)
                          <= triggerDistance;
            if (isNear)
            {
                PerformAllActions();
            }
        }
    }    
}
