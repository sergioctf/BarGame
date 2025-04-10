using UnityEngine;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public float spawnInterval = 3f;
    public Vector2 spawnAreaMin = new Vector2(-8f, -4f);
    public Vector2 spawnAreaMax = new Vector2(8f, 4f);

    public List<BoxCollider2D> blockedAreas; // ← aqui vão os colliders das mesas

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            TrySpawnItem();
            timer = 0f;
        }
    }

    void TrySpawnItem()
    {
        for (int i = 0; i < 20; i++) // tenta 20 vezes achar um local válido
        {
            float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            Vector2 spawnPos = new Vector2(x, y);

            if (!IsInsideBlockedArea(spawnPos))
            {
                Instantiate(itemPrefab, spawnPos, Quaternion.identity);
                GameController.SpawnedNewItem();
                return;
            }
        }

        Debug.LogWarning("Falha ao encontrar posição válida para spawn.");
    }

    bool IsInsideBlockedArea(Vector2 position)
    {
        foreach (var area in blockedAreas)
        {
            if (area.bounds.Contains(position))
            {
                return true;
            }
        }
        return false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 center = new Vector3((spawnAreaMin.x + spawnAreaMax.x) / 2f, (spawnAreaMin.y + spawnAreaMax.y) / 2f, 0);
        Vector3 size = new Vector3(spawnAreaMax.x - spawnAreaMin.x, spawnAreaMax.y - spawnAreaMin.y, 0);
        Gizmos.DrawWireCube(center, size);
    }
}