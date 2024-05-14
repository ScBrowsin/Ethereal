using TMPro;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public TMP_Text interactText; // Assign this in the inspector
    public GameObject textBoxPanel; // Adding this line reference to the textbox panel.
    public TMP_Text explanationText;
    public GameObject explanationPanel;

    public bool isLilyPadActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Make sure your player has the tag "Player"
        {
            isLilyPadActive = true;
            interactText.gameObject.SetActive(true);
            textBoxPanel.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isLilyPadActive = false;        
            interactText.gameObject.SetActive(false);
            textBoxPanel.gameObject.SetActive(false);
            InteractManager.Instance.HideInteractionText();
        }
    }

    private void Update()
    {
        if (isLilyPadActive && Input.GetKeyDown(KeyCode.E))
        {
            ShowLilyPadInfo();
        }
    }

    public void ShowLilyPadInfo()
    {
        Debug.Log("Lily Pad Info Triggered");
        InteractManager.Instance.ShowInteractionText("A few lone lily pads float in the pond.");
        explanationText.gameObject.SetActive(true);
        explanationPanel.gameObject.SetActive(true);
        
        // If you want to show a new UI panel along with changing the text, make sure to set it active here
        // e.g., infoPanel.SetActive(true);
    }
}

