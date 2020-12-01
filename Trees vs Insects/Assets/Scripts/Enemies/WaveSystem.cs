using System.Collections;
using UnityEngine;
using UnityEngine.Events;

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

        private bool IsWaveStarted = false;
        private int tempWeight = 0;

        [SerializeField]
        private UnityEvent OnLevelEnd = null;

        public void RandomSpawner ()
        {
            if (currentWave < waves.Length)
            {
                if (!IsWaveStarted)
                {
                    IsWaveStarted = true;

                    enemyWeight = waves[currentWave].weight;

                    enemyChooser.Init (waves[currentWave].enemies);
                    StartCoroutine (RandomSpawner (enemyWeight));
                }
                else
                {
                    if (tempWeight <= 0)
                    {
                        StopCoroutine (RandomSpawner (tempWeight));
                        IsWaveStarted = false;
                        currentWave++;
                        RandomSpawner ();
                    }
                }
            }
            OnLevelEnd?.Invoke ();
        }

        public IEnumerator RandomSpawner (int enemyWeight)
        {
            while (enemyWeight > 0)
            {
                int index = enemyChooser.ChooseEnemy (enemyWeight);
                enemyWeight -= waves[currentWave].enemies[index].weight;

                if (enemyWeight < 0)
                    continue;

                tempWeight = enemyWeight;
                SpawnEnemies (index);

                yield return new WaitForSeconds (waves[currentWave].durationBetweenEnemies);
            }
            IsWaveStarted = false;
            currentWave++;
        }

        private void SpawnEnemies (int index)
        {
            EnemySpawner spawner = trigger.ChooseASpawner ();
            GameObject enemy = waves[currentWave].enemies[index].enemyGameObject;
            spawner.Spawn (enemy);
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