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

    

        private int currentWave = 0;

        private EnemyChooser enemyChooser;

        private EnemyListChecker enemyListChecker;

        [Header ("Enemies")]
        private int enemyWeight = 10;

        private Seed seed;

        private TriggerSpawner trigger;

        [SerializeField]
        private UnityEvent OnLevelEnd = null;

        public event Action<int> OnSpawn;

        public int EnemyWeight { get => enemyWeight; set { enemyWeight = value; } }

        public void StartWave ()
        {
            StartCoroutine (WaveCounter ());
        }

        public IEnumerator WaveCounter ()
        {
            while (currentWave < waves.Length)
            {
                EnemyWeight = waves[currentWave].weight;

                enemyChooser.Init (waves[currentWave].enemies);

                yield return StartCoroutine (RandomSpawner (EnemyWeight));

                currentWave++;
            }
        }

        public IEnumerator RandomSpawner (int enemyWeight)
        {
            while (enemyWeight > 0)
            {
                int index = enemyChooser.ChooseEnemy (enemyWeight);
                int currentW = waves[currentWave].enemies[index].weight;
                enemyWeight -= currentW;

                SpawnEnemies (index);
                OnSpawn?.Invoke (currentW);
                yield return new WaitForSeconds (waves[currentWave].durationBetweenEnemies);
            }
        }

        private void SkipToNext ()
        {
            if (currentWave == waves.Length)
            {
                OnLevelEnd?.Invoke ();
            }
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
            enemyListChecker.OnNoEnemies -= SkipToNext;
        }

        private void OnEnable ()
        {
            enemyListChecker.OnNoEnemies += SkipToNext;
        }
    }
}