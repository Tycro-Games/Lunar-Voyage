using Bogadanul.Assets.Scripts.Enemies;
using System.Collections;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class ProjectileNoTarget : ProjectileBase, IProjectileNoTarget
    {
        private Vector3 dir;

        [SerializeField]
        private LayerMask enemies = 0;

        [SerializeField]
        private float radius = 2;

        [SerializeField]
        private float maxDist = 0.25f;

        public void Init (Vector2 Dir)
        {
            dir = Dir;
        }

        private void CheckSpace ()
        {
            RaycastHit[] colliders = new RaycastHit[1];
            Ray ray = new Ray (transform.position, dir);
            int count = Physics.SphereCastNonAlloc (ray, radius, colliders, maxDist, enemies);
            if (count > 0)
            {
                colliders[0].collider.GetComponent<EnemyAI> ().TakeDamage (damage);

                DestroyProjectile ();
            }
        }

        private void MoveToTarget ()
        {
            transform.position = Vector2.MoveTowards (transform.position, transform.position + dir, Time.deltaTime * speed);
            CheckSpace ();
        }

        private void Update ()
        {
            MoveToTarget ();
        }

        private void OnDrawGizmosSelected ()
        {
            Gizmos.DrawWireSphere (transform.position, radius);
            Gizmos.color = Color.green;
            Gizmos.DrawLine (transform.position, Vector2.right * maxDist);
        }
    }
}