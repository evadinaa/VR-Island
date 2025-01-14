using UnityEngine;
using UnityEngine.SceneManagement;

public class LightTunnelTransition : MonoBehaviour
{
	public string nextSceneName; // Name of the next scene

	// Public method to start the scene transition
	public void StartTransition()
	{
		Debug.Log("Transition initiated!");
		SceneManager.LoadScene(nextSceneName);
	}
}



