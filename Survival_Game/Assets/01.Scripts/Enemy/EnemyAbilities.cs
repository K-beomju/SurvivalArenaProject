using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Abilities")]
public class EnemyAbilities : ScriptableObject
{
    public string enemyName;
    public float health;
    public int attack;
}
