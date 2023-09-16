using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     public List<GameObject> levels; // List to hold your level prefabs
    private int currentLevelIndex = 0; // Index of the current level

    void Start()
    {
        // Enable the first level
        EnableLevel(currentLevelIndex);
    }

    // Function to enable a level
    void EnableLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levels.Count)
        {
            // Disable the current level (if any)
            DisableCurrentLevel();

            // Enable the new level
            levels[levelIndex].SetActive(true);

            // Update the current level index
            currentLevelIndex = levelIndex;
        }
    }

    // Function to disable the current level
    void DisableCurrentLevel()
    {
        if (currentLevelIndex >= 0 && currentLevelIndex < levels.Count)
        {
            levels[currentLevelIndex].SetActive(false);
        }
    }

    // Function to progress to the next level
    public void GoToNextLevel()
    {
        int nextLevelIndex = currentLevelIndex + 1;
        if (nextLevelIndex < levels.Count)
        {
            EnableLevel(nextLevelIndex);
        }
        else
        {
            // You've reached the end of the levels
            Debug.Log("You've completed all levels!");
        }
    }

    // Function to restart the current level
    public void RestartCurrentLevel()
    {
        DisableCurrentLevel(); // Disable the current level
        EnableLevel(currentLevelIndex); // Re-enable the current level
    }
}
