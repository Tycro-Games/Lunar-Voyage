
using UnityEngine;



[CreateAssetMenu(fileName = "EnemySpawnable", menuName = "Create/EnemySpawnable", order = 0)]
public class EnemySpawnable : ScriptableObject
{
    public GameObject enemyGameObject;
    public int weight;
}


