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
            EnemyList.CheckEnemies();

            OnDead?.Invoke();
            Destroy(gameObject);
        }

        private void Start()
        {
            EnemyList.List.Add(gameObject);
        }
    }
}