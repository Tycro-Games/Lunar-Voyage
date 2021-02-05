using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class WaveSystem : MonoBehaviour
    {
        [Header ("Waves")]
        public Wave[] waves = null;

        public HashSet<EnemySpawner> currenSelection = new HashSet<EnemySpawner> ();
        private int currentWave = 0;

        private EnemyChooser enemyChooser;

        private EnemyListChecker enemyListChecker;

        [Header ("Enemies")]
        private int enemyWeight = 10;

        private Seed seed;

        private TriggerSpawner trigger;

        [SerializeField]
        private UnityEvent OnLevelEnd = null;

        [SerializeField]
        private UnityEvent OnNextWave = null;

        private IEnumerator current = null;

        private int currentW = 0;

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

                currentW = EnemyWeight;
                ResetIen ();
                while (current != null)
                    yield return null;

                OnNextWave?.Invoke ();
                currentWave++;
            }
        }

        public IEnumerator RandomSpawner ()
        {
            currenSelection = trigger.RandomListOfSpawner (waves[currentWave].CountSpawners);
            OnNextWave?.Invoke ();
            while (currentW > 0)
            {
                int index = enemyChooser.ChooseEnemy (currentW);
                int current = waves[currentWave].enemies[index].weight;
                currentW -= current;

                SpawnEnemies (index, currenSelection);
                OnSpawn?.Invoke (current);
                yield return new WaitForSeconds (waves[currentWave].durationBetweenEnemies);
            }
        }

        private void ResetIen ()
        {
            current = RandomSpawner ();
            StartCoroutine (current);
        }

        private void SkipToNext ()
        {
            if (currentWave == waves.Length - 1 && currentW <= 0)
            {
                OnLevelEnd?.Invoke ();
            }
            else if (current != null && currentW > 0)
            {
                StopCoroutine (current);
                if (currentW > 0)
                    ResetIen ();
            }
            else
                current = null;
        }

        private void SpawnEnemies (int index, HashSet<EnemySpawner> enemySpawners)
        {
            GameObject enemy = waves[currentWave].enemies[index].enemyGameObject;
            EnemySpawner enemySpawner = trigger.ChooseASpawner (enemySpawners.ToArray ());
            enemySpawner.Spawn (enemy);
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