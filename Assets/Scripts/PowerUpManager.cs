using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject[] powerUpPrefabs;
    public float spawnInterval = 5f;
    public Vector2 spawnAreaMin = new Vector2(-10.4f, -9.6f);
    public Vector2 spawnAreaMax = new Vector2(19.6f, 6.4f);
    public float cellSize = 2f;

    void Start()
    {
        StartCoroutine(SpawnPowerUps());
    }

    private IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            Vector2 spawnPosition = GetRandomFreePosition();

            if (spawnPosition != Vector2.zero)
            {
                // Генерация случайного типа поверапа
                int randomIndex = Random.Range(0, powerUpPrefabs.Length);
                Instantiate(powerUpPrefabs[randomIndex], spawnPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector2 GetRandomFreePosition()
    {
        Vector2 spawnPosition;
        int maxAttempts = 10;
        int attempts = 0;

        do
        {
            // Генерация случайной позиции в области спавна
            float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            spawnPosition = new Vector2(Mathf.Round(x / cellSize) * cellSize, Mathf.Round(y / cellSize) * cellSize); // Округление для сетки

            attempts++;
        } while (IsPositionBlocked(spawnPosition) && attempts < maxAttempts);

        // Возвращаем позицию или (0,0)
        return attempts < maxAttempts ? spawnPosition : Vector2.zero;
    }

    private bool IsPositionBlocked(Vector2 position)
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, cellSize / 2);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Brick") || collider.CompareTag("Stone") || collider.CompareTag("Enemy") || collider.CompareTag("PowerUP") || collider.CompareTag("Player") || collider.CompareTag("Bomb"))
            {
                return true;
            }
        }

        return false;
    }
}