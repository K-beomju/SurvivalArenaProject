using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Thunder,
    HolyArrow
}

public abstract class SkillParent : MonoBehaviour
{
    public void DetactiveSkill()
    {
        gameObject.SetActive(false);
    }

    public IEnumerator DetactiveSkillCo()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

}
