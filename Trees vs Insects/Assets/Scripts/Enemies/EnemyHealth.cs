using System;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField]
        private int health = 0;

        public event Action OnDead;

        public int Health { get => health; set => health = value; }

        public void TakeDamage (int dg)
        {
            Health -= dg;
            if (Health <= 0)
            {
                Dead ();
            }
        }

        public void Dead ()
        {
            Destroy (gameObject);
            OnDead?.Invoke ();
        }
    }
}