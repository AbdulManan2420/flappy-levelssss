using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    public Button[] levelButtons;

    void Start()
    {
        // Agar pehli baar game open ho to Level 1 unlock rahe
        if (!PlayerPrefs.HasKey("UnlockedLevel"))
        {
            PlayerPrefs.SetInt("UnlockedLevel", 1);
        }

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel");

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = (i < unlockedLevel);
        }
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level" + level);
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}