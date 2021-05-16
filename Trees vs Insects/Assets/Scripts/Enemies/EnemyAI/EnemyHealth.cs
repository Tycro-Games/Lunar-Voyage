using Assets.Scripts.UI;
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

                Instantiate(getter.LevelEndSeedDisplayable.collectable, transform.position, Quaternion.identity);
            }
            OnDead?.Invoke();
            Destroy(gameObject);
        }

        private void Start()
        {
            wave = FindObjectOfType<WaveSystem>();
            EnemyList.List.Add(gameObject);
        }
    }
}