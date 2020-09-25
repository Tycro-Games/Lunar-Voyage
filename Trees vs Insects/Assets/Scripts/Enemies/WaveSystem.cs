using System.Collections;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class WaveSystem : MonoBehaviour
    {
        private int count;

        private int currentWave = 0;

        private EnemyChooser enemyChooser;

        private EnemyListChecker enemyListChecker;

        [Header ("Enemies")]
        [SerializeField]
        private EnemySpawnable[] enemySpawnable = null;

        [SerializeField]
        private int enemyWeight = 10;

        private Seed seed;

        private TriggerSpawner trigger;

        [Header ("Waves")]
        [SerializeField]
        private Wave[] waves = null;

        public void RandomSpawner ()
        {
            if (currentWave < waves.Length)
            {
                enemyWeight = waves[currentWave].weight;

                StartCoroutine (RandomSpawner (enemyWeight));
                currentWave++;
            }
        }

        public IEnumerator RandomSpawner (int enemyWeight)
        {
            while (enemyWeight >= 0)
            {
                EnemySpawner spawner = trigger.ChooseASpawner ();

                int index = enemyChooser.ChooseEnemy (enemyWeight);

                enemyWeight -= enemySpawnable[index].weight;
                if (enemyWeight < 0)
                    continue;

                GameObject enemy = enemySpawnable[index].enemyGameObject;
                spawner.Spawn (enemy);

                yield return new WaitForSeconds (.5f);
            }
        }

        private void Awake ()
        {
            enemyListChecker = GetComponent<EnemyListChecker> ();
            trigger = GetComponent<TriggerSpawner> ();
            seed = GetComponent<Seed> ();

            enemyChooser = GetComponent<EnemyChooser> ();
            enemyChooser.Init (enemySpawnable);
        }

        private void OnDisable ()
        {
            enemyListChecker.OnNoEnemies -= RandomSpawner;
        }

        private void OnEnable ()
        {
            enemyListChecker.OnNoEnemies += RandomSpawner;
        }
    }
}