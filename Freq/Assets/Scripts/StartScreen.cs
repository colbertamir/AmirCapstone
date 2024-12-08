using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    // This function will be called when the button is pressed
    public void SwitchToFirstMusicScene()
    {
        SceneManager.LoadScene("FirstMusicScene");
    }
}
