using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component

    void Update()
    {
        if (PersistentData.Instance != null)
        {
            // Use the GetScore method from the PersistentData script
            int currentScore = PersistentData.Instance.GetScore();
            scoreText.text = "Score: " + currentScore;
            print("score: " + currentScore);
        }
        else
        {
            // This line is for debugging purposes to notify you if PersistentData instance is not found.
            Debug.LogError("PersistentData instance not found.");
        }
    }
}
