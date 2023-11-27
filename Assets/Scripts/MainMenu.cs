using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;         // For UI elements like InputField
using TMPro;                  // For TextMeshPro elements

public class MainMenu : MonoBehaviour
{
    public TMP_InputField nameInputField;  // Reference to the name input field

    public void PlayGame()
    {
        // Save the player name before starting the game
        if (nameInputField != null && !string.IsNullOrEmpty(nameInputField.text))
        {
            // Use the SetName method from the PersistentData script
            PersistentData.Instance.SetName(nameInputField.text);
        }

        SceneManager.LoadScene("Level1");
    }

    public void OpenInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
