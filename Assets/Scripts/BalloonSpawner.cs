using System.Collections;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloonPrefab;
    public float spawnInterval = 5f;
    public Vector2 spawnAreaMin; // Minimum bounds for spawn area
    public Vector2 spawnAreaMax; // Maximum bounds for spawn area

    void Start()
    {
        StartCoroutine(SpawnBalloonRoutine());
    }

    private IEnumerator SpawnBalloonRoutine()
    {
        while (true)
        {
            SpawnBalloon();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnBalloon()
    {
        // Generate a random position within the defined spawn area
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

        Instantiate(balloonPrefab, spawnPosition, Quaternion.identity);
    }
}
