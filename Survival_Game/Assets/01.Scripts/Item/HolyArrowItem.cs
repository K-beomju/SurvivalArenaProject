using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyArrowItem : ItemParent
{
    protected override void Eat()
    {
        this.gameObject.SetActive(false);
        SkillManager.Instance.StartSkill(SkillType.HolyArrow);
    }
}
