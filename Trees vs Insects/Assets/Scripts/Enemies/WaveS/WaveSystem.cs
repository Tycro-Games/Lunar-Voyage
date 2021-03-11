﻿using System;
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
                while (currentWaveCoroutine.Current != null)
                    yield return null;

                OnNextWave?.Invoke();
                currentWave++;
            }
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
        }

        private void ResetIen()
        {
            currentWaveCoroutine = RandomSpawner();
            StartCoroutine(currentWaveCoroutine);
        }

        private void SkipToNext()
        {
            if (currentWave == waves.Length - 1 && currentW <= 0)
            {
                OnLevelEnd?.Invoke();
            }
            else if (currentW > 0)
            {
                StopCoroutine(currentWaveCoroutine);
                ResetIen();
            }
            else
            {
                StopCoroutine(currentWaveCoroutine);
                ResetIen();
            }
        }

        private void SpawnEnemies(EnemySpawnable spawnable, HashSet<EnemySpawner> enemySpawners)
        {
            EnemySpawner enemySpawner = trigger.ChooseASpawner(enemySpawners.ToArray());
            enemySpawner.Spawn(spawnable.enemyGameObject);
        }

        private void Awake()
        {
            enemyListChecker = GetComponent<EnemyListChecker>();
            trigger = GetComponent<TriggerSpawner>();
            seed = GetComponent<Seed>();
            enemyChooser = GetComponent<EnemyChooser>();
        }

        private void OnDisable()
        {
            enemyListChecker.OnNoEnemies -= SkipToNext;
        }

        private void OnEnable()
        {
            enemyListChecker.OnNoEnemies += SkipToNext;
        }
    }
}