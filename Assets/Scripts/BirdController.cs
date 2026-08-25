using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BirdController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 5f;
    public float flapForce = 7f;
    public float gravityMultiplier = 1.4f;

    [Header("UI")]
    public TextMeshProUGUI pressToPlayText;

    [Header("Audio")]
    public AudioSource flapAudio;
    public AudioSource deathAudio;

    private Rigidbody rb;
    private bool gameStarted = false;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Bird waits until first Space press
        rb.isKinematic = true;

        gameStarted = false;
        isDead = false;

        // Show "Press Space To Play"
        if (pressToPlayText != null)
        {
            pressToPlayText.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (isDead)
            return;

        // Waiting to start
        if (!gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                StartGame();
            }

            return;
        }

        // Normal flap
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Flap();
        }
    }

    void FixedUpdate()
    {
        if (!gameStarted || isDead)
            return;

        // Forward movement
        rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, forwardSpeed);

        // Extra gravity
        rb.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
    }

    void StartGame()
    {
        gameStarted = true;

        // Enable physics
        rb.isKinematic = false;

        // Hide text
        if (pressToPlayText != null)
        {
            pressToPlayText.gameObject.SetActive(false);
        }

        // First flap
        Flap();
    }

    void Flap()
    {
        if (isDead)
            return;

        // Reset vertical speed
        rb.linearVelocity = new Vector3(0, 0, forwardSpeed);

        // Jump
        rb.AddForce(Vector3.up * flapForce, ForceMode.Impulse);

        // Sound
        if (flapAudio != null)
            flapAudio.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead || !gameStarted)
            return;

        if (collision.gameObject.CompareTag("Obstacle") ||
            collision.gameObject.CompareTag("Ground"))
        {
            isDead = true;

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            if (deathAudio != null)
                deathAudio.Play();

            Invoke(nameof(GameOver), 1f);
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}