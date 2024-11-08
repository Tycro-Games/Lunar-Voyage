﻿using Assets.Scripts.UI;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField]
        private int health = 0;

        public event Action OnDead;

        [SerializeField]
        private UnityEvent onDead;

        [SerializeField]
        private UnityEvent onHit;

        public event Action<int> OnDamage;

        private WaveSystem wave = null;
        public int Health { get => health; set => health = value; }

        public void TakeDamage(int dg)
        {
            Health -= dg;
            if (Health <= 0)
            {
                Dead();
            }
            else
            {
                onHit?.Invoke();
                OnDamage?.Invoke(dg);
            }
        }

        public void Dead()
        {
            EnemyList.List.Remove(gameObject);
            bool Islast = EnemyList.CheckEnemies();
            if (Islast && wave.End)
            {
                GetterSeedDisplayer getter = FindObjectOfType<GetterSeedDisplayer>();

              GameObject obj=  Instantiate(getter.LevelEndSeedDisplayable.collectable, transform.position, Quaternion.identity);
                obj.GetComponent<SpriteRenderer>().sprite = getter.LevelEndSeedDisplayable.icon;
            }
            OnDead?.Invoke();
            onDead?.Invoke();
            Destroy(gameObject);
        }

        private void Start()
        {
            wave = GameObject.FindGameObjectWithTag("WaveSystem").GetComponent<WaveSystem>();
            EnemyList.List.Add(gameObject);
        }
    }
}