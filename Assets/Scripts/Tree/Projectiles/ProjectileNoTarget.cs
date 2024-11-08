﻿using Assets.Scripts.Tree.Projectiles;
using Bogadanul.Assets.Scripts.Enemies;
using System.Collections;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    [RequireComponent(typeof(ProjectileMovement))]
    public class ProjectileNoTarget : ProjectileBase, IProjectileNoTarget
    {
        private Vector3 dir;

        [SerializeField]
        private LayerMask enemies = 0;

        [SerializeField]
        private float radius = 2;

        [SerializeField]
        private float maxDist = 0.25f;

        private ProjectileMovement projectileMovement;

        public void Init(Vector2 Dir)
        {
            dir = Dir;
            projectileMovement = GetComponent<ProjectileMovement>();
        }

        private void CheckSpace()
        {
            RaycastHit[] colliders = new RaycastHit[1];
            Ray ray = new Ray(transform.position, dir);
            int count = Physics.SphereCastNonAlloc(ray, radius, colliders, maxDist, enemies);
            if (count > 0)
            {
                colliders[0].collider.GetComponent<IEnemyAI>().TakeDamage(damage);

                DestroyProjectile();
            }
        }

        private void Update()
        {
            projectileMovement.MoveToTarget(dir, speed);
            CheckSpace();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, radius);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * maxDist);
        }
    }
}