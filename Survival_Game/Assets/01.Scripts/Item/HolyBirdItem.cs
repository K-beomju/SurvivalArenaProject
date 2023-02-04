using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyBirdItem : ItemParent
{
    protected override void Eat()
    {
        this.gameObject.SetActive(false);
        SkillManager.Instance.StartSkill(SkillType.HolyBird);
    }
}
