/** using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas; // Reference to the PauseMenu Canvas
    public GameObject audioHomie;      // Reference to the AudioHomie GameObject

    private bool isPaused = false;

    void Update()
    {
        // Toggle pause menu when the Esc key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuCanvas.SetActive(true); // Show the pause menu
        audioHomie.SetActive(false);     // Deactivate AudioHomie
        isPaused = true;
        Time.timeScale = 0f;             // Pause the game
    }

    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false); // Hide the pause menu
        audioHomie.SetActive(true);       // Reactivate AudioHomie
        isPaused = false;
        Time.timeScale = 1f;              // Resume the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;              // Ensure the game is unpaused
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }

    public void SwitchToHipHopScene()
    {
        Time.timeScale = 1f;              // Ensure the game is unpaused
        SceneManager.LoadScene("SecondMusicScene"); // Load Hip-Hop scene
    }

    public void SwitchToBeneeScene()
    {
        Time.timeScale = 1f;              // Ensure the game is unpaused
        SceneManager.LoadScene("ThirdMusicScene"); // Load BENEE scene
    }

    public void SwitchToPinkPantheressScene()
    {
        Time.timeScale = 1f;              // Ensure the game is unpaused
        SceneManager.LoadScene("FirstScenePinkPantheress"); // Load PinkPantheress scene
    }

    public void QuitGame()
    {
        Application.Quit();               // Quit the application
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
        #endif
    }
}
**/

// No need for pause menu as of right now