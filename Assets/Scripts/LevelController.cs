using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int levelNumber = 1;

    void Start()
    {
        PlayerPrefs.SetInt("CurrentLevel", levelNumber);
        PlayerPrefs.Save();
    }
}