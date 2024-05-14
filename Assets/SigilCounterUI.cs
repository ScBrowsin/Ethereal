using TMPro;
using UnityEngine;

public class SigilCounterUI : MonoBehaviour
{
    public TextMeshProUGUI sigilCountText;

    void Update()
    {
        // Update the text value to display the sigil count
        sigilCountText.text = "Sigils: " + PlayerDataManager.sigilCount;
    }
}
