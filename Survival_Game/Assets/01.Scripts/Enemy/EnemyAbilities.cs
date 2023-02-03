using UnityEngine;



public enum EnemyType : int
{
    Normal = 0,
    Shaman,
    Creaper,
    Ogre,
    Baby
}

[CreateAssetMenu(menuName = "Enemy/Abilities")]
public class EnemyAbilities : ScriptableObject
{
    public string enemyName;
    public float health;
    public int attack;
    public float speed;
    public float exp;
}
