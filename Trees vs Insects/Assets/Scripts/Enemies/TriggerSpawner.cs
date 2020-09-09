using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
    private EnemySpawner[] enemySpawners;

    void Start()
    {
        enemySpawners = GetComponentsInChildren<EnemySpawner>();
    }
    public EnemySpawner ChooseASpawner()
    {
        EnemySpawner enemySpawner = enemySpawners[Random.Range(0, enemySpawners.Length)];
        return enemySpawner;
    }

}


