using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolManager : MonoBehaviour
{
    #region ObjectPrefabs
    public GameObject arrowPrefab;
    #endregion

    #region ObjectPools
    private ObjectPooling<Arrow> arrowPool;
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


    }

    public static Arrow GetArrowObject()
    {
        return instance.arrowPool.GetOrCreate();
    }
}
