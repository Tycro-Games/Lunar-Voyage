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

                enemyChooser.Init (waves[currentWave].enemies);

                StartCoroutine (RandomSpawner (enemyWeight));
            }
        }

        public IEnumerator RandomSpawner (int enemyWeight)
        {
            while (enemyWeight >= 0)
            {
                EnemySpawner spawner = trigger.ChooseASpawner ();

                int index = enemyChooser.ChooseEnemy (enemyWeight);

                enemyWeight -= waves[currentWave].enemies[index].weight;
                if (enemyWeight < 0)
                    continue;

                GameObject enemy = waves[currentWave].enemies[index].enemyGameObject;
                spawner.Spawn (enemy);

                yield return new WaitForSeconds (waves[currentWave].durationBetweenEnemies);
            }
            currentWave++;
        }

        private void Awake ()
        {
            enemyListChecker = GetComponent<EnemyListChecker> ();
            trigger = GetComponent<TriggerSpawner> ();
            seed = GetComponent<Seed> ();

            enemyChooser = GetComponent<EnemyChooser> ();
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