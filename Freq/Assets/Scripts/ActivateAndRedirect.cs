using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ActivateAndRedirect : MonoBehaviour
{
    public Canvas YtReadyCanvas; // Reference to the YtReady canvas
    public Button redirectButton; // Reference to the button on the canvas
    private const string youtubeUrl = "https://www.youtube.com/watch?v=DqewBvd-bAA";

    void Start()
    {
        // Ensure the canvas is initially inactive
        if (YtReadyCanvas != null)
        {
            YtReadyCanvas.gameObject.SetActive(false);
        }

        // Start the coroutine to activate the canvas after 30 seconds
        StartCoroutine(ActivateCanvasAfterDelay(30f));

        // Assign the button click listener to redirect to YouTube
        if (redirectButton != null)
        {
            redirectButton.onClick.AddListener(RedirectToYouTube);
        }
    }

    IEnumerator ActivateCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        if (YtReadyCanvas != null)
        {
            YtReadyCanvas.gameObject.SetActive(true); // Activate the canvas
        }
    }

    void RedirectToYouTube()
    {
        Application.OpenURL(youtubeUrl); // Open the specified YouTube video URL
    }
}

// This script is purely to use with the UI for proof of concept, API intergration will be stretch goal