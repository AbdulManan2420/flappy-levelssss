using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BirdSelectionManager : MonoBehaviour
{
    public Button[] birdButtons;
    public Color normalColor = Color.white;
    public Color selectedColor = Color.green;

    private int selectedBird = 0;

    void Start()
    {
        selectedBird = PlayerPrefs.GetInt("SelectedBird", 0);
        UpdateSelection();
    }

    public void SelectBird(int index)
    {
        selectedBird = index;
        UpdateSelection();
    }

    void UpdateSelection()
    {
        for (int i = 0; i < birdButtons.Length; i++)
        {
            ColorBlock cb = birdButtons[i].colors;
            cb.normalColor = (i == selectedBird) ? selectedColor : normalColor;
            birdButtons[i].colors = cb;
        }
    }

    public void Confirm()
    {
        PlayerPrefs.SetInt("SelectedBird", selectedBird);
        PlayerPrefs.Save();

        SceneManager.LoadScene("LevelSelect");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}