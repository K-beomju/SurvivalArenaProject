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

    private float radius = 10; // the radius of the circular formation
    private float goldenRatio = (1 + Mathf.Sqrt(5)) / 2; // the golden ratio

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
        for (int i = 0; i < 5; i++)
        {
            // check if the spawn position is outside of the camera view
            Vector3 spawnPos = RandomCircle(GameManager.playerTrm().position, spawnRadius);

            if (!IsVisibleFrom(mainCamera, spawnPos))
            {
                enemy = PoolManager.GetEnemyObject();
                enemy.transform.position = spawnPos;
                enemy.gameObject.SetActive(true);
            }
            else
            {
                spawnTimer = 0;
            }

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


    // 원형 테두리 생성
    void SpawnCircleEnemy(int spawnCount = 10)
    {
        float angle = 0; // the current angle
        for (int i = 0; i < spawnCount; i++)
        {
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);
            enemy = PoolManager.GetEnemyObject();
            enemy.transform.position = new Vector2(x, y) + (Vector2)GameManager.playerTrm().position;
            enemy.gameObject.SetActive(true);
            enemy.transform.parent = transform;
            angle += Mathf.PI * 2 * goldenRatio;
        }
    }
}
