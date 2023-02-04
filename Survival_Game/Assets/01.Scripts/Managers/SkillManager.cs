using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : Singleton<SkillManager>
{
    private SkillParent skill;
    private ItemParent item;

    public List<GameObject> holyBird;

    public void StartSkill(SkillType skillType)
    {
        switch (skillType)
        {
            case SkillType.Thunder:
                StartCoroutine(SpawnThunder());
                break;
            case SkillType.HolyArrow:
                StartCoroutine(SpawnHolyArrow());
                break;
            case SkillType.HolyBird:
                StartCoroutine(SpawnHolyBird());
                break;
        }
    }

    private IEnumerator SpawnThunder()
    {
        for (int i = 0; i < 10; i++)
        {
            skill = PoolManager.GetSkillObject(SkillType.Thunder);
            skill.transform.position = GetRandomPointOnScreen(0.2f, 0.8f);
            yield return new WaitForSeconds(0.8f);
            if (GameManager.IsPlayerDead()) yield break;
        }
        yield return null;
    }

    private IEnumerator SpawnHolyArrow()
    {
        int oneShoting = 12;
        int speed = 200;

        float angle = 360 / oneShoting;
        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < oneShoting; i++)
            {
                skill = PoolManager.GetSkillObject(SkillType.HolyArrow);
                skill.gameObject.SetActive(true);
                skill.transform.position = GameManager.playerTrm().position;
                skill.transform.rotation = Quaternion.Euler(0f, 0f, angle * i);

                skill.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * i / oneShoting), speed * Mathf.Sin(Mathf.PI * i * 2 / oneShoting)));
            }
            yield return new WaitForSeconds(2f);
            if (GameManager.IsPlayerDead()) yield break;

        }
    }

    private IEnumerator SpawnHolyBird()
    {
        holyBird.ForEach(x => x.SetActive(true));
        int roundCount = 0;
        int objSize = 3;
        float circleR = 1.5f;
        float deg = 0;
        float objSpeed = 200;

        while (roundCount < 7)
        {
            deg += Time.deltaTime * objSpeed;
            if (deg < 360)
            {
                for (int i = 0; i < objSize; i++)
                {
                    var rad = Mathf.Deg2Rad * (deg + (i * (360 / objSize)));
                    var x = circleR * Mathf.Sin(rad);
                    var y = circleR * Mathf.Cos(rad);
                    holyBird[i].transform.position = GameManager.playerTrm().position + new Vector3(x, y);
                    holyBird[i].transform.rotation = Quaternion.Euler(0, 0, (deg + (i * (360 / objSize))) * -1);
                }
            }
            else
            {
                roundCount++;
                deg = 0;
                if (GameManager.IsPlayerDead()) yield break;

            }
            yield return null;
        }
        holyBird.ForEach(x => x.SetActive(false));

    }

    public void SpawnItem()
    {
        int rand = Random.Range(0, 4);
        item = PoolManager.GetItemObject(rand);
        item.transform.position = GetRandomPointOnScreen();
        item.gameObject.SetActive(true);
    }


    public Vector3 GetRandomPointOnScreen(float x = 0f, float y = 1f)
    {
        float randomX = Random.Range(x, y);
        float randomY = Random.Range(x, y);

        Vector3 randomPoint = Camera.main.ViewportToWorldPoint(new Vector3(randomX, randomY, 10));
        randomPoint.z = 0;

        return randomPoint;
    }

}
