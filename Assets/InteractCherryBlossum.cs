using TMPro;
using UnityEngine;

public class InteractionCherryBlossum : MonoBehaviour
{
    public TMP_Text interactText; // Assign this in the inspector
    public GameObject textBoxPanel; // Reference to the textbox panel
    public TMP_Text explanationText;
    public GameObject explanationPanel;

    public bool isCherryBlossumActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check for the player tag
        {
            isCherryBlossumActive = true; // Activate Cherry Blossom interaction
            interactText.gameObject.SetActive(true);
            textBoxPanel.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCherryBlossumActive = false; // Deactivate Cherry Blossom interaction
            interactText.gameObject.SetActive(false);
            textBoxPanel.gameObject.SetActive(false);
            InteractManager.Instance.HideInteractionText();
        }
    }

    private void Update()
    {
        if (isCherryBlossumActive && Input.GetKeyDown(KeyCode.E))
        {
            ShowCherryBlossumInfo();
        }
    }

    public void ShowCherryBlossumInfo()
    {
        Debug.Log("Cherry Blossom Info Triggered");
        InteractManager.Instance.ShowInteractionText("A marvelous Cherry Blossom tree blooms across a pond of infinity.");
        explanationText.gameObject.SetActive(true);
        explanationPanel.gameObject.SetActive(true);
    }
}
