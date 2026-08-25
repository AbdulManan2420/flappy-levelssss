using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteManager : MonoBehaviour
{
    private int currentLevel;

    void Start()
    {
        // Read the level the player just completed
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
    }

    void Update()
    {
        // Press Enter to go to the next level
        if (Input.GetKeyDown(KeyCode.Return) ||
            Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        // Unlock the next level
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (currentLevel >= unlockedLevel)
        {
            PlayerPrefs.SetInt("UnlockedLevel", currentLevel + 1);
            PlayerPrefs.Save();
        }

        // If Level 10 is completed, return to Main Menu
        if (currentLevel >= 10)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            // Update the current level before loading the next one
            PlayerPrefs.SetInt("CurrentLevel", currentLevel + 1);
            PlayerPrefs.Save();

            SceneManager.LoadScene("Level" + (currentLevel + 1));
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}