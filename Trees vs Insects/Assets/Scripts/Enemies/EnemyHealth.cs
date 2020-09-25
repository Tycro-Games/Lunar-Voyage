using System;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField]
        private int health = 0;

        public event Action OnDead;

        public void TakeDamage (int dg)
        {
            health -= dg;
            if (health <= 0)
            {
                OnDead?.Invoke ();
            }
        }
    }
}