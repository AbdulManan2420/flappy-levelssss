using TMPro;
using UnityEngine;

public class MainMenuCoins : MonoBehaviour
{
    public TMP_Text coinText;

    void Start()
    {
       coinText.text = "Coins : " + PlayerPrefs.GetInt("TotalCoins", 0);
    }
}