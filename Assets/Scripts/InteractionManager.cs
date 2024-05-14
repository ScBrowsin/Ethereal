using UnityEngine;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance;

    public TMP_Text explanationText;
    public GameObject explanationPanel;

    private void Awake()
    {
        //Singleton pattern to ensure only one instance.
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowInteractionText(string text)
    {
        explanationText.text = text;
        explanationPanel.SetActive(true);
    }

    public void HideInteractionText()
    {
        explanationPanel.SetActive(false);
    }
}
