using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class WaveSystem : MonoBehaviour
    {
        [Header ("Waves")]
        public Wave[] waves = null;

        private int count;

        private int currentWave = 0;

        private EnemyChooser enemyChooser;

        private EnemyListChecker enemyListChecker;

        [Header ("Enemies")]
        private int enemyWeight = 10;

        private Seed seed;

        private TriggerSpawner trigger;

        private bool IsWaveStarted = false;

        private int tempWeight = 0;

        [SerializeField]
        private UnityEvent OnLevelEnd = null;

        public event Action<int> OnSpawn;

        public int EnemyWeight { get => enemyWeight; set { enemyWeight = value; } }

        public void RandomSpawner ()
        {
            if (currentWave < waves.Length)
            {
                if (!IsWaveStarted)
                {
                    IsWaveStarted = true;

                    EnemyWeight = waves[currentWave].weight;

                    enemyChooser.Init (waves[currentWave].enemies);

                    StartCoroutine (RandomSpawner (EnemyWeight));
                }
                else if (tempWeight <= 0)
                {
                    StopCoroutine (RandomSpawner (tempWeight));
                    IsWaveStarted = false;
                    currentWave++;
                    RandomSpawner ();
                }
            }
            else
                OnLevelEnd?.Invoke ();
        }

        public IEnumerator RandomSpawner (int enemyWeight)
        {
            while (enemyWeight > 0)
            {
                int index = enemyChooser.ChooseEnemy (enemyWeight);
                int currentW = waves[currentWave].enemies[index].weight;
                enemyWeight -= currentW;

                if (enemyWeight < 0)
                    continue;

                tempWeight = enemyWeight;
                SpawnEnemies (index);
                OnSpawn?.Invoke (currentW);
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