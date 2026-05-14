using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private Obstacle obstaclePrefab;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnYPosition = 6f;
    [SerializeField] private float spawnXPadding = 0.6f;
    [SerializeField] private float startSpawnInterval = 1.1f;
    [SerializeField] private float minimumSpawnInterval = 0.35f;

    [Header("Obstacle Speed")]
    [SerializeField] private float startFallSpeed = 4f;
    [SerializeField] private float maxFallSpeed = 10f;

    [Header("Difficulty")]
    [SerializeField] private float difficultyIncreaseRate = 0.08f;

    private Camera mainCamera;
    private float spawnTimer;
    private float currentSpawnInterval;
    private float currentFallSpeed;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Start()
    {
        ResetSpawner();
    }

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver)
        {
            return;
        }

        IncreaseDifficulty();

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= currentSpawnInterval)
        {
            spawnTimer = 0f;
            SpawnObstacle();
        }
    }

    public void ResetSpawner()
    {
        spawnTimer = 0f;
        currentSpawnInterval = startSpawnInterval;
        currentFallSpeed = startFallSpeed;
    }

    private void IncreaseDifficulty()
    {
        currentSpawnInterval -= difficultyIncreaseRate * Time.deltaTime;
        currentSpawnInterval = Mathf.Max(currentSpawnInterval, minimumSpawnInterval);

        currentFallSpeed += difficultyIncreaseRate * Time.deltaTime * 2f;
        currentFallSpeed = Mathf.Min(currentFallSpeed, maxFallSpeed);
    }

    private void SpawnObstacle()
    {
        if (obstaclePrefab == null || mainCamera == null)
        {
            return;
        }

        Vector3 leftEdge = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector3 rightEdge = mainCamera.ViewportToWorldPoint(new Vector3(1f, 0f, 0f));

        float randomX = Random.Range(leftEdge.x + spawnXPadding, rightEdge.x - spawnXPadding);
        Vector3 spawnPosition = new Vector3(randomX, spawnYPosition, 0f);

        Obstacle obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        obstacle.Initialize(currentFallSpeed);

        float randomSize = Random.Range(0.5f, 1.2f);
        obstacle.transform.localScale = new Vector3(randomSize, randomSize, 1f);
    }
}
