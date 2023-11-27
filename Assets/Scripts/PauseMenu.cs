using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    // Pauses the game and shows the pause menu
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Freezes the game
    }

    // Resumes the game and hides the pause menu
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resumes the game
    }

    // Loads the Main Menu scene
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Make sure to resume time scale
        SceneManager.LoadScene("Main Menu");
    }
}

