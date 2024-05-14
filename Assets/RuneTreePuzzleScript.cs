using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RuneTreePuzzleScript : MonoBehaviour
{
    public string objectName;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI instructionText; // Instruction text for pressing Y or N keys
    public GameObject interactPrompt;
    public MainSoulfireMoveScript playerMovement;
    public TextMeshProUGUI sigilText;
    //public SigilImage sigilImage;
    public TilePlacer tilePlacer; // Reference to the TilePlacer script.
    public Tilemap etherealTopTilemap; // Declare etherealTopTilemap variable
    public TileReplacerSigPedTop tileReplacerSigPedTop; // Reference to TileReplacerSigPedTop
    public TileReplacerSigPedLow tileReplacerSigPedLow; // Reference to TileReplacerSigPedTop

    private bool isPlayerInRange = false;
    private bool isDialogueActive = false;
    private int interactionCount = 0; // Counter for tracking interactions.

    // Coordinates of the bridge positions for the RuneTree puzzle
    public RectInt[] bridgePositions;
    public Vector2Int[] sigPedLowPositions;
    public Vector2Int[] sigPedTopPositions;

    void Awake()
    {
        dialogueText.gameObject.SetActive(false);
        instructionText.gameObject.SetActive(false); // Initially hide instruction text
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
        else if (isDialogueActive)
        {
            // Check for player input when dialogue is active
            if (Input.GetKeyDown(KeyCode.Y))
            {
                // Handle player response for "Y" key
                PlaceSigil();
                sigilText.gameObject.SetActive(true);
// SigilImage.gameObject.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                // Handle player response for "N" key
                NoSigil();
            }
        }
    }

    void ShowDialogue()
    {
        // Show initial question and instruction text
        if (interactionCount == 0)
        {
            dialogueText.text = "A somber willow stares across its wooded kingdom. Take tree sigils?";
        }
        else
        {
            dialogueText.text = "Submerge the disjointed and retrieve sigils?";
        }
        instructionText.text = "Press Y or N keys to continue.";
        dialogueText.gameObject.SetActive(true);
        instructionText.gameObject.SetActive(true);
        isDialogueActive = true;
        playerMovement.enabled = false; // Disable player movement
    }

    void HideDialogue()
    {
        // Hide dialogue and instruction text
        dialogueText.gameObject.SetActive(false);
        instructionText.gameObject.SetActive(false);
        isDialogueActive = false;
        playerMovement.enabled = true; // Enable player movement
    }

    void PlaceSigil()
    {
        // Execute functions for placing a sigil
        Debug.Log("Sigil placed!");

        PlayerDataManager.sigilCount = 3; // This sets the sigils to 3

        // Call the TilePlacer function for each bridge position
        foreach (RectInt position in bridgePositions)
        {
            tilePlacer.PlaceTiles(etherealTopTilemap, position);
        }

        // Replace tiles for sigPedLowPositions
        foreach (Vector2Int position in sigPedLowPositions)
        {
            tileReplacerSigPedLow.ReplaceTiles(etherealTopTilemap, position);
        }

        // Replace tiles for sigPedTopPositions
        foreach (Vector2Int position in sigPedTopPositions)
        {
            tileReplacerSigPedTop.ReplaceTiles(etherealTopTilemap, position);
        }

        // Add your sigil placement logic here
        HideDialogue(); // Hide dialogue after placing sigil
        GetSigilsBack();
        // Increment the interaction count
        interactionCount++;
    }



    void NoSigil()
    {
        // Execute functions for not placing a sigil
        Debug.Log("No sigil placed.");
        // Add your no sigil logic here
        HideDialogue(); // Hide dialogue after choosing not to place sigil
    }


    void GetSigilsBack()
    {
        // Reactivate all BoxCollider2D components
        GameObject[] pedestals = GameObject.FindGameObjectsWithTag("Pedestal");
        foreach (GameObject pedestal in pedestals)
        {
            BoxCollider2D collider = pedestal.GetComponent<BoxCollider2D>();
            if (collider != null)
            {
                collider.enabled = true;
            }
        }
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
