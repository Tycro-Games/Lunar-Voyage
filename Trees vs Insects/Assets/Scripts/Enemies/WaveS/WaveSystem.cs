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
        [Header("Waves")]
        public Wave[] waves = null;

        public HashSet<EnemySpawner> currenSelection = new HashSet<EnemySpawner>();
        private int currentWave = 0;

        private EnemyChooser enemyChooser;

        private EnemyListChecker enemyListChecker;

        [Header("Enemies")]
        private int enemyWeight = 10;

        private Seed seed;

        private TriggerSpawner trigger;

        [SerializeField]
        private UnityEvent OnLevelEnd = null;

        [SerializeField]
        private UnityEvent OnNextWave = null;

        private IEnumerator currentWaveCoroutine = null;

        private int currentW = 0;

        public event Action<int> OnSpawn;

        public int EnemyWeight { get => enemyWeight; set { enemyWeight = value; } }
        private bool waveEnd = false;
        private bool End = false;

        public void StartWave()
        {
            StartCoroutine(WaveCounter());
        }

        public IEnumerator WaveCounter()
        {
            while (currentWave < waves.Length)
            {
                EnemyWeight = waves[currentWave].weight;

                enemyChooser.Init(waves[currentWave].enemies);

                currentW = EnemyWeight;
                ResetIen();
                while (currentWaveCoroutine.Current != null && !waveEnd)
                {
                    yield return null;
                }

                OnNextWave?.Invoke();
                currentWave++;
                waveEnd = false;
            }
            End = true;
        }

        public IEnumerator RandomSpawner()
        {
            currenSelection = trigger.RandomListOfSpawner(waves[currentWave].CountSpawners);
            OnNextWave?.Invoke();
            while (currentW > 0)
            {
                EnemySpawnable enemy = enemyChooser.ChooseEnemy(currentW);
                int current = enemy.weight;
                currentW -= current;

                SpawnEnemies(enemy, currenSelection);
                OnSpawn?.Invoke(current);
                yield return new WaitForSeconds(waves[currentWave].durationBetweenEnemies);
            }
            waveEnd = true;
        }

        private void ResetIen()
        {
            if (currentWaveCoroutine != null)
                StopCoroutine(currentWaveCoroutine);
            currentWaveCoroutine = RandomSpawner();
            StartCoroutine(currentWaveCoroutine);
        }

        private void Update()
        {
            if (End)
            {
                if (EnemyList.List.Count == 0)
                {
                    End = false;
                }
            }
        }

        public void EndTheGame()
        {
            OnLevelEnd?.Invoke();
        }

        private void SkipToNext()
        {
            if (currentW > 0 && currentWave != waves.Length)
                ResetIen();
        }

        private void SpawnEnemies(EnemySpawnable spawnable, HashSet<EnemySpawner> enemySpawners)
        {
            EnemySpawner enemySpawner = trigger.ChooseASpawner(enemySpawners.ToArray());
            enemySpawner.Spawn(spawnable.enemyGameObject);
        }

        private void Awake()
        {
            trigger = GetComponent<TriggerSpawner>();
            seed = GetComponent<Seed>();
            enemyChooser = GetComponent<EnemyChooser>();
        }

        private void OnDisable()
        {
            EndLevel.EndGame -= EndTheGame;
            EnemyListChecker.OnNoEnemies -= SkipToNext;
        }

        private void OnEnable()
        {
            EndLevel.EndGame += EndTheGame;
            EnemyListChecker.OnNoEnemies += SkipToNext;
        }
    }
}