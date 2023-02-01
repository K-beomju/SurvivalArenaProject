using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolManager : Singleton<PoolManager>
{
    #region ObjectPrefabs
    public GameObject arrowPrefab;
    public GameObject[] enemyPrefab;
    #endregion

    #region ObjectPools
    private ObjectPooling<Arrow> arrowPool;
    private ObjectPooling<Enemy>[] enemyPool;
    #endregion

    private Dictionary<string, int> effectDic = new Dictionary<string, int>();

    void Awake()
    {
        arrowPool = new ObjectPooling<Arrow>(arrowPrefab, this.transform, 10);
        enemyPool = new ObjectPooling<Enemy>[enemyPrefab.Length];
        for (int i = 0; i < enemyPrefab.Length; i++)
        {
            enemyPool[i] = new ObjectPooling<Enemy>(enemyPrefab[i], this.transform, 10);
        }

    }

    public static Arrow GetArrowObject()
    {
        return Instance.arrowPool.GetOrCreate();
    }

    public static Enemy GetEnemyObject(EnemyType enemyType)
    {
        return Instance.enemyPool[(int)enemyType].GetOrCreate();
    }
}
