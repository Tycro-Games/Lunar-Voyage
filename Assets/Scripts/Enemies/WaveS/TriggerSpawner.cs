using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class TriggerSpawner : MonoBehaviour
    {
        public  EnemySpawner[] enemySpawners;

        public EnemySpawner ChooseASpawner(EnemySpawner[] enemies)
        {
            return enemies[Random.Range(0, enemies.Length)];
        }

        public HashSet<EnemySpawner> RandomListOfSpawner(int count)
        {
            HashSet<EnemySpawner> spawners = new HashSet<EnemySpawner>();
            if (enemySpawners.Length <= count)
            {
                spawners.UnionWith(enemySpawners);
                return spawners;
            }
            for (int i = 0, j = 0; i < enemySpawners.Length && j < count; i++)
            {
                EnemySpawner enemySpawner = enemySpawners[Random.Range(0, enemySpawners.Length)];
                if (!spawners.Contains(enemySpawner))
                    j++;
                spawners.Add(enemySpawner);
            }
            return spawners;
        }

        private void Start()
        {
            enemySpawners = GetComponentsInChildren<EnemySpawner>();
        }
    }
}