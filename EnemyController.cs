using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f; // velocidade de perseguição
    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Procura pelo player usando a tag "Player"
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            Debug.Log("Player encontrado: " + player.name);
        }
        else
        {
            Debug.LogWarning("Player NÃO encontrado! Certifique-se que o objeto do player está com a tag 'Player'.");
        }

        // Se você quiser testar a colisão e movimento sem que o inimigo desapareça muito rápido,
        // comente a linha abaixo. Ela destrói o inimigo após 3 segundos.
        Destroy(gameObject, 6f);
    }

    void FixedUpdate()
    {
        // Se o player foi encontrado, calcula a direção e aplica velocidade
        if (player != null)
        {
            Vector2 direction = ((Vector2)player.position - rb.position).normalized;
            rb.linearVelocity = direction * speed;
            Debug.Log("Velocidade do inimigo: " + rb.linearVelocity);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    // Detecta colisão física. Certifique-se que ambos, inimigo e player, possuem Collider2D
    // e que nenhum deles tenha "Is Trigger" marcado, se estiver usando OnCollisionEnter2D.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colisão com o player detectada via OnCollisionEnter2D");
            GameController.TimeRanOut(); // finaliza o jogo
        }
    }

    // Se preferir usar colisões via triggers (com o collider marcado como Is Trigger),
    // descomente o método abaixo e certifique-se que os colliders estejam configurados como triggers.
    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Colisão com o player detectada via OnTriggerEnter2D");
            GameController.TimeRanOut();
        }
    }
    */
}
