using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    public AudioSource levelCompleteAudio;

    private bool finished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (finished) return;

        if (other.CompareTag("Player"))
        {
            finished = true;

            if (levelCompleteAudio != null)
                levelCompleteAudio.Play();

            Invoke(nameof(LoadLevelComplete), 1.5f);
        }
    }

    void LoadLevelComplete()
    {
        SceneManager.LoadScene("LevelComplete");
    }
}