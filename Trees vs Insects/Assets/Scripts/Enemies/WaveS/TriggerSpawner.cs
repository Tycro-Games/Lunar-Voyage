using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class TriggerSpawner : MonoBehaviour
    {
        private EnemySpawner[] enemySpawners;

        public EnemySpawner ChooseASpawner (EnemySpawner[] enemies)
        {
            return enemies[Random.Range (0, enemies.Length)];
        }

        public HashSet<EnemySpawner> RandomListOfSpawner ()
        {
            HashSet<EnemySpawner> spawners = new HashSet<EnemySpawner> ();
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                spawners.Add (enemySpawners[Random.Range (0, enemySpawners.Length)]);
            }
            return spawners;
        }

        private void Start ()
        {
            enemySpawners = GetComponentsInChildren<EnemySpawner> ();
        }
    }
}