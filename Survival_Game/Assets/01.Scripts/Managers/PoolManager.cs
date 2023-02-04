using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolManager : Singleton<PoolManager>
{
    #region ObjectPrefabs
    public GameObject arrowPrefab;
    public GameObject[] enemyPrefab;
    public GameObject damageTextPrefab;
    public GameObject[] skillPrefab;
    public GameObject[] itemPrefab;
    #endregion

    #region ObjectPools
    private ObjectPooling<Arrow> arrowPool;
    private ObjectPooling<Enemy>[] enemyPool;
    private ObjectPooling<DamageText> damageTextPool;
    private ObjectPooling<SkillParent>[] skillPool;
    private ObjectPooling<ItemParent>[] itemPool;
    #endregion

    void Awake()
    {
        arrowPool = new ObjectPooling<Arrow>(arrowPrefab, this.transform, 10);
        damageTextPool = new ObjectPooling<DamageText>(damageTextPrefab, this.transform, 100);

        enemyPool = new ObjectPooling<Enemy>[enemyPrefab.Length];
        for (int i = 0; i < enemyPrefab.Length; i++)
        {
            enemyPool[i] = new ObjectPooling<Enemy>(enemyPrefab[i], this.transform, 10);
        }

        skillPool = new ObjectPooling<SkillParent>[skillPrefab.Length];
        for (int i = 0; i < skillPrefab.Length; i++)
        {
            skillPool[i] = new ObjectPooling<SkillParent>(skillPrefab[i], this.transform, 10);
        }

        itemPool = new ObjectPooling<ItemParent>[itemPrefab.Length];
        for (int i = 0; i < itemPrefab.Length; i++)
        {
            itemPool[i] = new ObjectPooling<ItemParent>(itemPrefab[i], this.transform, 1);
        }

    }

    public static Arrow GetArrowObject()
    {
        return Instance.arrowPool.GetOrCreate();
    }

    public static DamageText GetDamageText()
    {
        return Instance.damageTextPool.GetOrCreate();
    }

    public static Enemy GetEnemyObject(EnemyType enemyType)
    {
        return Instance.enemyPool[(int)enemyType].GetOrCreate();
    }

    public static SkillParent GetSkillObject(SkillType skillType)
    {
        return Instance.skillPool[(int)skillType].GetOrCreate();
    }

    public static ItemParent GetItemObject(int num)
    {
        return Instance.itemPool[num].GetOrCreate();
    }
}
