using Bogadanul.Assets.Scripts.Enemies;
using System;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class ProjectileTarget : ProjectileBase, IProjectileTarget
    {
        private Transform target;

        private bool hasTarget = false;

        private Vector2 dir = Vector2.zero;

        public void Init(Transform Target)
        {
            hasTarget = true;
            target = Target;
            enemyAI = target.GetComponent<IEnemyAI>();
        }

        private void CheckSpace()
        {
            if (transform.position == target.position)
            {
                enemyAI.TakeDamage(damage);
                DestroyProjectile();
            }
        }

        private void MoveToTarget()
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, (target.position - transform.position).normalized);
        }

        private void MoveToTarget(Vector3 dir)
        {
            transform.position = Vector2.MoveTowards(transform.position, transform.position + dir, Time.deltaTime * speed);
        }

        private void Update()
        {
            if (hasTarget && target == null)
            {
                dir = transform.up;
                hasTarget = false;
                DestroyProjectile(20);
            }
            if (hasTarget)
            {
                MoveToTarget();
                CheckSpace();
            }
            else
            {
                MoveToTarget(dir);
            }
        }
    }
}