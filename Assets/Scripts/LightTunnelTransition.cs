using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LightTunnelTransition : MonoBehaviour
{
    public ScreenFade screenFade;       // Drag the ScreenFade script here
    public VideoPlayer lightTunnelVideo; // Reference to the VideoPlayer component
    public string nextSceneName;        // Name of the next scene
    public Image fadeImage;             // Full-screen Image to fade the video (drag here in the Inspector)
    public float videoStartDelay = 0.5f; // Optional delay before showing the video
    public float fadeOutDuration = 2f;  // Duration for fading the video out before scene transition

    private bool transitionStarted = false;

    // Método público chamado pelo ShieldController
    public void StartTransition()
    {
        Debug.Log("Transição iniciada pelo ShieldController!");
        if (!transitionStarted)
        {
            transitionStarted = true;
            StartCoroutine(StartLightTunnel());
        }
    }

    private IEnumerator StartLightTunnel()
    {
        // Step 1: Fade to black
        screenFade.FadeToBlack();
        yield return new WaitForSeconds(screenFade.fadeDuration);

        // Step 2: Optional delay before playing the video
        yield return new WaitForSeconds(videoStartDelay);

        // Step 3: Start playing the light tunnel video
        lightTunnelVideo.Play();

        // Step 4: Wait for part of the video to play before fading out
        yield return new WaitForSeconds(1f); // Adjust timing as necessary
        screenFade.FadeToClear();

        // Step 5: Wait for the video to finish playing
        while (lightTunnelVideo.isPlaying)
        {
            yield return null;
        }

        // Step 6: Start fading out the video itself
        // yield return FadeOutVideo();

        // Step 7: Transition to the next scene after the fade
        SceneManager.LoadScene(nextSceneName);
    }

    private IEnumerator FadeOutVideo()
    {
        float startAlpha = fadeImage.color.a;
        float time = 0;

        while (time < fadeOutDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, 1, time / fadeOutDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Ensure it's fully black at the end
        fadeImage.color = new Color(0, 0, 0, 1);
    }
}


