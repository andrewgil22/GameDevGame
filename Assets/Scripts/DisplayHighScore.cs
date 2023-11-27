using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScores : MonoBehaviour
{
    public Text[] highScoreTexts; // Assign UI Texts for each high score

    void Start()
    {
        List<HighScoreEntry> highScores = PersistentData.Instance.GetHighScores();

        for (int i = 0; i < highScoreTexts.Length; i++)
        {
            if (i < highScores.Count)
            {
                highScoreTexts[i].text = (i + 1) + ". " + highScores[i].playerName + "'s Score: " + highScores[i].score;
            }
            else
            {
                highScoreTexts[i].text = (i + 1) + ". ";
            }
        }
    }
}
