using Assets.Scripts.Tree.Projectiles;
using Bogadanul.Assets.Scripts.Enemies;
using System;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    [RequireComponent(typeof(ProjectileMovement))]
    public class ProjectileTarget : ProjectileBase, IProjectileTarget
    {
        private Transform target;

        private bool hasTarget = false;

        private Vector2 dir = Vector2.zero;
        private ProjectileMovement projectileMovement = null;

        public void Init(Transform Target)
        {
            projectileMovement = GetComponent<ProjectileMovement>();
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
                projectileMovement.MoveToTarget(target, speed);
                CheckSpace();
            }
            else
            {
                projectileMovement.MoveToTarget(dir, speed);
            }
        }
    }
}