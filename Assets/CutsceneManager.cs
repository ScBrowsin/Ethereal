using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CutsceneManager : MonoBehaviour
{
    public TextMeshProUGUI skipText;

    void Update()
    {
        // Check if the player presses the "E" key
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Load the next scene
            SceneManager.LoadScene("EtherealScene1PondOfBeginnings");
        }
    }

    // Method to show the skip text
    public void ShowSkipText()
    {
        skipText.gameObject.SetActive(true);
    }
}
