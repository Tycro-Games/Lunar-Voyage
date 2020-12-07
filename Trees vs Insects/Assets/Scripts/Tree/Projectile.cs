using Bogadanul.Assets.Scripts.Enemies;
using System;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        [SerializeField]
        private int damage = 1;

        private EnemyAI enemyAI;

        [SerializeField]
        private float speed = 0;

        private Transform target;

        public event Action OnDead;

        public void Init (Transform Target)
        {
            target = Target;
            enemyAI = target.GetComponent<EnemyAI> ();
        }

        private void CheckSpace ()
        {
            if (transform.position == target.position)
            {
                enemyAI.TakeDamage (damage);
                DestroyProjectile ();
            }
        }

        private void DestroyProjectile ()
        {
            OnDead?.Invoke ();
            Destroy (gameObject);
        }

        private void MoveToTarget ()
        {
            transform.position = Vector2.MoveTowards (transform.position, target.position, Time.deltaTime * speed);
            transform.rotation = Quaternion.LookRotation (Vector3.forward, (target.position - transform.position).normalized);
        }

        private void Update ()
        {
            if (target == null)
            {
                DestroyProjectile ();
                return;
            }
            MoveToTarget ();
            CheckSpace ();
        }
    }
}