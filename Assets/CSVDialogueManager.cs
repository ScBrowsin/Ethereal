using System.Collections.Generic;
using UnityEngine;

public class CSVDialogueManager : MonoBehaviour
{
    // Define two private dictionaries to store dialogue sequences and indices
    private Dictionary<string, List<string>> dialogueSequences = new Dictionary<string, List<string>>();
    private Dictionary<string, int> dialogueIndices = new Dictionary<string, int>();

    // Start method, called when the script is initialized
    void Start()
    {
        // Call the ReadCSV method when the script starts
        ReadCSV();
    }

    // Method to read CSV data
    void ReadCSV()
    {
        // Load a CSV file named "etherealscene1" from the Resources folder as a TextAsset
        TextAsset dialogueData = Resources.Load<TextAsset>("etherealscene1");
        // Check if the CSV data is successfully loaded
        if (dialogueData != null)
        {
            // Split the CSV data into lines
            string[] data = dialogueData.text.Split(new char[] { '\n' });
            // Loop through each line starting from the second line (excluding the header)
            for (int i = 1; i < data.Length; i++)
            {
                // Split each line by comma to get individual cells
                string[] row = data[i].Split(new char[] { ',' });
                // Check if the row has at least two elements
                if (row.Length >= 2)
                {
                    // Extract the key (object name) and sentence from the row
                    string key = row[0].Trim();
                    string sentence = row[1].Trim();

                    // If the dialogue sequence for the key doesn't exist, create a new list and set the dialogue index to 0
                    if (!dialogueSequences.ContainsKey(key))
                    {
                        dialogueSequences[key] = new List<string>();
                        dialogueIndices[key] = 0;
                    }

                    // Add the sentence to the dialogue sequence corresponding to the key
                    dialogueSequences[key].Add(sentence);
                }
            }
        }
        else
        {
            // Log an error message if the CSV data fails to load
            Debug.LogError("Failed to load CSV data from Resources.");
        }
    }

    // Method to get the next dialogue sentence for a given object name
    public string GetNextDialogue(string objectName, bool advanceDialogue = true)
    {
        // Check if the dialogue sequence exists for the given object name
        if (dialogueSequences.ContainsKey(objectName))
        {
            // Get the list of sentences for the object name
            var sentences = dialogueSequences[objectName];
            // Get the current index for the dialogue sequence
            int index = dialogueIndices[objectName];

            // Optionally advance the dialogue index
            if (advanceDialogue)
            {
                // Increment the index for the next time, but stop at the last entry
                if (index < sentences.Count - 1)
                {
                    dialogueIndices[objectName] = index + 1;
                }
            }

            // Return the dialogue sentence at the current index
            return sentences[index];
        }

        // Return a default message if the dialogue sequence is not found
        return "Dialogue not found.";
    }
}
