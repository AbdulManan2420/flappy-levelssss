using UnityEngine;

public class ResetData : MonoBehaviour
{
    public void ResetGameData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        Debug.Log("Game Data Reset Successfully!");
    }
}