using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private GameTimer gameTimer;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        // Atualizamos a busca pelo GameTimer
        gameTimer = FindFirstObjectByType<GameTimer>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collect"))
        {
            audioSource.Play();
            GameController.Collect();
            // Aqui somamos 1 ao placar
            if (ScoreManager.Instance != null)
                ScoreManager.Instance.AddScore(1);
            Destroy(other.gameObject);
            if (gameTimer != null && gameTimer.IsRunning())
            {
                gameTimer.AddTime(4f);
            }
        }
    }
}
