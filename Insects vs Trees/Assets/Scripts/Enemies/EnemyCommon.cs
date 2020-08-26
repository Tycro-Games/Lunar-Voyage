using UnityEngine;
[CreateAssetMenu(fileName = "new enemy common stats", menuName = "Create/new enemy")]
public class EnemyCommon : ScriptableObject
{
    [SerializeField]
    private int health = 10;
    public int GetHealth
    {
        get => health;
    }
    [SerializeField]
    private int damage = 1;
    public int Getdamage
    {
        get => damage;
    }

}
