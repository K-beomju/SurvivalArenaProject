using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Enemy enemy;
    public float spawnInterval = 5f;
    public float spawnRadius = 10f;
    public float duration = 900f;

    private Camera mainCamera;
    private float spawnTimer;
    private float endTime;

    void Start()
    {
        mainCamera = Camera.main;
        spawnTimer = spawnInterval;
        endTime = Time.time + duration;
    }

    void Update()
    {
        if (Time.time > endTime || GameManager.IsPlayerDead())
        {
            //stop spawning enemies
            return;
        }

        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = spawnInterval;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // check if the spawn position is outside of the camera view
        Vector3 spawnPos = RandomCircle(GameManager.playerTrm().position, spawnRadius);

        if (!IsVisibleFrom(mainCamera, spawnPos))
        {
            enemy = PoolManager.GetEnemyObject();
            enemy.transform.position = spawnPos;
        }
        else
        {
            spawnTimer = 0;
        }
    }

    //원형범위
    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

    bool IsVisibleFrom(Camera camera, Vector3 pos)
    {
        Vector3 viewPos = camera.WorldToViewportPoint(pos);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1)
        {
            return true;
        }
        return false;
    }
}
