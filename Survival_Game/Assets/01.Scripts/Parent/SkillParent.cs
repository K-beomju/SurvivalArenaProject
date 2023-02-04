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
   
    public IEnumerator DetativeSkillCo(int delay = 5)
    {
        yield return new WaitForSeconds(delay);
        DetactiveSkill();
    }

    // 애니메이션 이벤트
    public void DetactiveSkill()
    {
        gameObject.SetActive(false);
    }



}
