using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotateSpeed = 150f;
    public float floatSpeed = 2f;
    public float floatHeight = 0.2f;

    [Header("Audio")]
    public AudioSource coinAudio;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Rotate coin
        transform.Rotate(
            rotateSpeed * Time.deltaTime,
            rotateSpeed * Time.deltaTime,
            0);

        // Floating animation
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        transform.position = new Vector3(
            startPos.x,
            newY,
            startPos.z
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Play coin sound
            if (coinAudio != null)
                AudioSource.PlayClipAtPoint(
                    coinAudio.clip,
                    transform.position
                );

            GameManager.Instance.AddCoin();

            int totalCoins = PlayerPrefs.GetInt("Coins", 0);
            PlayerPrefs.SetInt("Coins", totalCoins + 1);
            PlayerPrefs.Save();

            Destroy(gameObject);
        }
    }
}