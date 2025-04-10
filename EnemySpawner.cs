using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab do inimigo
    public float spawnInterval = 13f; // Intervalo de 15 segundos para spawnar inimigos

    // Define a área de spawn (ajuste conforme sua cena)
    public Vector2 spawnAreaMin = new Vector2(-8f, -4f);
    public Vector2 spawnAreaMax = new Vector2(8f, 4f);

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // Gera uma posição aleatória dentro da área definida
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 spawnPos = new Vector2(x, y);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    // Visualiza a área de spawn no Editor com Gizmos
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 center = new Vector3((spawnAreaMin.x + spawnAreaMax.x) / 2f,
                                     (spawnAreaMin.y + spawnAreaMax.y) / 2f,
                                     0);
        Vector3 size = new Vector3(spawnAreaMax.x - spawnAreaMin.x,
                                   spawnAreaMax.y - spawnAreaMin.y,
                                   0);
        Gizmos.DrawWireCube(center, size);
    }
}
