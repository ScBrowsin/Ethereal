using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PedestalEighthScript : MonoBehaviour
{
    public string objectName;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI instructionText; // Instruction text for pressing Y or N keys
    public GameObject interactPrompt;
    public MainSoulfireMoveScript playerMovement;
    public TileSwapper tileSwapper; // Reference to TileSwapper script
    public TileSwapperSigPedLow tileSwapperSigPedLow; // Reference to TileSwapperSigPedLow script
    public TileSwapperSigPedTop tileSwapperSigPedTop; // Reference to TileSwapperSigPedTop script

    // Properties to set values for TileSwapper from the Unity Editor
    public Tilemap etherealTopTilemap;
    public Tilemap etherealBottomTilemap;
    public TileBase etherealTopTile;
    public TileBase etherealBottomTile;
    public int xLocation;
    public int yLocation;
    public int targetWidth;
    public int targetHeight;

    // Properties to specify the positions of the top and bottom tiles of the pedestal
    public int topTilePosX;
    public int topTilePosY;
    public int lowTilePosX;
    public int lowTilePosY;

    private bool isPlayerInRange = false;
    private bool isDialogueActive = false;

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
        dialogueText.text = "Would you like to place a sigil?";
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
        // Check if the player has any sigils left
        if (PlayerDataManager.sigilCount > 0)
        {
            // Execute functions for placing a sigil
            Debug.Log("Sigil placed!");

            PlayerDataManager.sigilCount--; // This decreases sigil count by one.

            // Call RemoveTopLayer function from TileSwapper script
            if (tileSwapper != null && etherealTopTilemap != null)
            {
                tileSwapper.RemoveTopLayer(etherealTopTilemap, new RectInt(xLocation, yLocation, targetWidth, targetHeight));
            }

            // Now, let's call the TileSwapperSigPedTop and TileSwapperSigPedLow functions
            if (tileSwapperSigPedTop != null)
            {
                tileSwapperSigPedTop.SwapTile(etherealTopTilemap, topTilePosX, topTilePosY); // Swap top tile
            }

            if (tileSwapperSigPedLow != null)
            {
                tileSwapperSigPedLow.SwapTile(etherealTopTilemap, lowTilePosX, lowTilePosY); // Swap bottom tile
            }

            // Add your sigil placement logic here

            // Deactivate the 2D box collider attached to the pedestal
            GetComponent<Collider2D>().enabled = false;

            // Hide dialogue after placing sigil
            HideDialogue();
        }
        else
        {
            // Display message indicating the player does not have any sigils left
            dialogueText.text = "You do not have any sigils left to place.";

            // Show the message UI box
            dialogueText.gameObject.SetActive(true);
            instructionText.gameObject.SetActive(false);
        }
    }


    void NoSigil()
    {
        // Execute functions for not placing a sigil
        Debug.Log("No sigil placed.");
        // Add your no sigil logic here
        HideDialogue(); // Hide dialogue after choosing not to place sigil
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
