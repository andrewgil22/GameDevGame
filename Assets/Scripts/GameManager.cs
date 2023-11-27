using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int balloonsPopped = 0;
    private float levelTimer = 0f;
    private int currentLevel = 1;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Update the timer
        levelTimer += Time.deltaTime;

        // Debugging: Print the timer and balloon count
        Debug.Log("Level: " + currentLevel + ", Timer: " + levelTimer + ", Balloons Popped: " + balloonsPopped);

        // Check conditions for level progression
        if (currentLevel == 1 && levelTimer >= 10f && balloonsPopped >= 1)
        {
            Debug.Log("Loading Level 2...");
            LoadNextLevel(); // Load Level 2
        }
        else if (currentLevel == 2 && levelTimer >= 80f && balloonsPopped >= 10)
        {
            Debug.Log("Loading Level 3...");
            LoadNextLevel(); // Load Level 3
        }
    }

    public void BalloonPopped()
    {
        balloonsPopped++;
    }

    private void LoadNextLevel()
    {
        currentLevel++;
        string sceneNameToLoad = "Level" + currentLevel;

        Debug.Log("Trying to load scene: " + sceneNameToLoad);
        SceneManager.LoadScene(sceneNameToLoad);

    }

    public int GetBalloonsPopped()
    {
        return balloonsPopped;
    }


}

