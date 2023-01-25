using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolManager : MonoBehaviour
{
    #region ObjectPrefabs
    public GameObject arrowPrefab;
    public GameObject enemyPrefab;
    #endregion

    #region ObjectPools
    private ObjectPooling<Arrow> arrowPool;
    private ObjectPooling<Enemy> enemyPool;
    #endregion

    private Dictionary<string, int> effectDic = new Dictionary<string, int>();

    private static PoolManager Instance;
    public static PoolManager instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType(typeof(PoolManager)) as PoolManager;
                if (Instance == null)
                {
                    GameObject obj = new GameObject();
                    Instance = obj.AddComponent<PoolManager>();
                }
            }

            return Instance;
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);

        arrowPool = new ObjectPooling<Arrow>(arrowPrefab, this.transform, 10);
        enemyPool = new ObjectPooling<Enemy>(enemyPrefab, this.transform , 10);

    }

    public static Arrow GetArrowObject()
    {
        return instance.arrowPool.GetOrCreate();
    }

    public static Enemy GetEnemyObject()
    {
        return instance.enemyPool.GetOrCreate();
    }
}
