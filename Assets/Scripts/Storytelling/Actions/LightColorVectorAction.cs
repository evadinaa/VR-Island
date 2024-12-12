using UnityEngine;

namespace Storytelling
{
    public class LightColorVectorAction : VectorActionBehaviour
    {
        // Reference to the light whose color will be updated
        [SerializeField]
        private Light pointLight;

        // Scaling factors for converting vector components to RGB values
        [SerializeField]
        private float scaleX = 1f;
        [SerializeField]
        private float scaleY = 1f;
        [SerializeField]
        private float scaleZ = 1f;

        private void Start()
        {
            // Ensure the light reference is assigned
            if (pointLight == null)
            {
                Debug.LogError("PointLight is not assigned. Please assign a light object in the inspector.");
            }
        }

        public override void PerformAction(Vector3 vector)
        {
            if (pointLight == null) return;

            // Convert vector components to RGB values using scaling factors
            float red = Mathf.Clamp01(vector.x * scaleX);
            float green = Mathf.Clamp01(vector.y * scaleY);
            float blue = Mathf.Clamp01(vector.z * scaleZ);

            // Update the light color
            pointLight.color = new Color(red, green, blue);

            // Optionally log the color values for debugging
            if (enableLogging)
            {
                Debug.Log($"Light Color: R={red * 255}, G={green * 255}, B={blue * 255}");
            }
        }
    }
}


