using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class TriggerSpawner : MonoBehaviour
    {
        private EnemySpawner[] enemySpawners;

        public EnemySpawner ChooseASpawner ()
        {
            return enemySpawners[Random.Range (0, enemySpawners.Length)];
        }

        private void Start ()
        {
            enemySpawners = GetComponentsInChildren<EnemySpawner> ();
        }
    }
}