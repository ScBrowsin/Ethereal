using TMPro;
using UnityEngine;

public class LilyPadInteractable : MonoBehaviour
{
    public string objectName;
    public TextMeshProUGUI dialogueText;
    public GameObject interactPrompt;
    public MainSoulfireMoveScript playerMovement; // Reference to the player's movement script

    private bool isPlayerInRange = false;
    private bool isDialogueActive = false;

    void Awake()
    {
        dialogueText.gameObject.SetActive(false);
        interactPrompt.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CanInteract())
        {
            if (!isDialogueActive)
            {
                ShowDialogue();
            }
            else
            {
                HideDialogue();
            }
        }
    }

    void ShowDialogue()
    {
        CSVDialogueManager dialogueManager = FindObjectOfType<CSVDialogueManager>();
        string dialogue = dialogueManager.GetNextDialogue(objectName, !isDialogueActive);
        dialogueText.text = dialogue;
        dialogueText.gameObject.SetActive(true);
        isDialogueActive = true;
        playerMovement.enabled = false; // Disable player movement
    }

    void HideDialogue()
    {
        dialogueText.gameObject.SetActive(false);
        isDialogueActive = false;
        playerMovement.enabled = true; // Enable player movement
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInRange = true;
            ShowInteractPrompt(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInRange = false;
            ShowInteractPrompt(false);
            if (isDialogueActive) // Make sure to hide the dialogue if it's active when the player leaves.
            {
                HideDialogue();
            }
        }
    }

    void ShowInteractPrompt(bool show)
    {
        interactPrompt.SetActive(show);
    }

    bool CanInteract()
    {
        return isPlayerInRange; // Now this returns true only if the player is within the trigger range.
    }
}
