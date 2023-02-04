using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Enemy enemy;
    public float spawnInterval = 5f;
    public float spawnRadius = 10f;
    public float durationTimer = 0f;

    private Camera mainCamera;
    private float spawnTimer;

    private float goldenRatio = (1 + Mathf.Sqrt(5)) / 2; // the golden ratio

    public bool isStart = false;
    private int ogreEnemyCount = 0;

    public static int enemyCount = 0;

    void Start()
    {
        mainCamera = Camera.main;
        spawnTimer = spawnInterval;
    }

    void Update()
    {
        if (!isStart || GameManager.IsPlayerDead()) return;
        durationTimer = Time.time;

        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = spawnInterval;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (enemyCount > 50) return;

        if (durationTimer <= 60)
            EnemySpawn(3, EnemyType.Normal);
        else if (durationTimer < 120)
        {
            EnemySpawn(2, EnemyType.Normal);
            EnemySpawn(1, EnemyType.Shaman);
        }
        else if (durationTimer < 200)
        {
            EnemySpawn(2, EnemyType.Normal);
            EnemySpawn(1, EnemyType.Creaper);
        }
        else if (durationTimer < 300)
        {
            EnemySpawn(3, EnemyType.Normal);
            EnemySpawn(1, EnemyType.Creaper);
            EnemySpawn(1, EnemyType.Shaman);
        }
        else if (durationTimer < 500)
        {
            EnemySpawn(1, EnemyType.Shaman);
            EnemySpawn(5, EnemyType.Baby);
        }
        else if (durationTimer < 700)
        {
            EnemySpawn(1, EnemyType.Shaman);
            EnemySpawn(1, EnemyType.Creaper);
            EnemySpawn(1, EnemyType.Baby);
        }
        else
        {
            if (ogreEnemyCount < 3)
            {
                EnemySpawn(1, EnemyType.Ogre);
                ogreEnemyCount += 1;
            }

            EnemySpawn(1, EnemyType.Shaman);
            EnemySpawn(1, EnemyType.Normal);
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

    public void EnemySpawn(int count, EnemyType enemyType)
    {
        for (int i = 0; i < count; i++)
        {
            // check if the spawn position is outside of the camera view
            Vector3 spawnPos = RandomCircle(GameManager.playerTrm().position, spawnRadius);

            if (!IsVisibleFrom(mainCamera, spawnPos))
            {
                ++enemyCount;
                enemy = PoolManager.GetEnemyObject(enemyType);
                enemy.transform.position = spawnPos;
                enemy.gameObject.SetActive(true);
            }
            else
            {
                spawnTimer = 0;
            }

        }
    }
}
