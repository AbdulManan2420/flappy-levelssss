using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    void Update()
    {
        // Press Enter to start the game
        if (Input.GetKeyDown(KeyCode.Return) ||
            Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Play();
        }
    }

    // Play Button
    public void Play()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    // Shop Button
    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    // Exit Button
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}