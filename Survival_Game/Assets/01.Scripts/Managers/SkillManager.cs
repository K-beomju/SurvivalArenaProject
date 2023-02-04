using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : Singleton<SkillManager>
{
    private SkillParent skill;

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
        }
    }

    private IEnumerator SpawnThunder()
    {
        for (int i = 0; i < 10; i++)
        {
            skill = PoolManager.GetSkillObject(SkillType.Thunder);
            skill.transform.position = GetRandomPointOnScreen(0.2f, 0.8f);
            yield return new WaitForSeconds(0.8f);
        }
        yield return null;
    }

    IEnumerator SpawnHolyArrow()
    {
        int oneShoting = 12;
        int speed = 150;

        float angle = 360 / oneShoting;
        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < oneShoting; i++)
            {
                skill = PoolManager.GetSkillObject(SkillType.HolyArrow);
                skill.gameObject.SetActive(true);
                skill.transform.position = GameManager.playerTrm().position;
                skill.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * i / oneShoting), speed * Mathf.Sin(Mathf.PI * i * 2 / oneShoting)));
                skill.transform.Rotate(new Vector3(0f, 0f, 360 * i / oneShoting));
            }
            yield return new WaitForSeconds(2f);
        }

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
