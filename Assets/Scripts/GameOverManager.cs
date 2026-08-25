using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    void Update()
    {
        // Restart when Enter is pressed
        if (Input.GetKeyDown(KeyCode.Return) ||
            Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        SceneManager.LoadScene("Level" + currentLevel);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}