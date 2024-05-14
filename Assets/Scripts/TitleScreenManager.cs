using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    // This function will be called when the button is clicked
    public void LoadNextScene()
    {
        SceneManager.LoadScene("EtherealTitleScreen2"); // Load the scene named "EtherealTitleScreen2"
    }
}
