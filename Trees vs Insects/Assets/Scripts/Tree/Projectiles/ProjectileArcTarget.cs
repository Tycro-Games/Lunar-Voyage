using Bogadanul.Assets.Scripts.Enemies;
using Bogadanul.Assets.Scripts.Tree;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Tree.Projectiles
{
    public class ProjectileArcTarget : ProjectileBase, IProjectileTarget
    {
        public AnimationCurve curve;
        private Transform target = null;

        private Vector3 start;

        [SerializeField]
        private float duration = 1.0f;

        private IEnumerator Curve()
        {
            float time = 0f;

            Vector2 end = target.position; // lead the target a bit to account for travel time, your math will vary

            while (time < duration)
            {
                time += Time.deltaTime;

                float linearT = time / duration;
                float heightT = curve.Evaluate(linearT);

                float height = Mathf.Lerp(0f, 3.0f, heightT); // change 3 to however tall you want the arc to be

                transform.position = Vector2.Lerp(start, end, linearT) + new Vector2(0f, height);

                yield return null;
            }

            DestroyProjectile();
            // impact
        }

        public void Init(Transform Target)
        {
            enemyAI = Target.GetComponent<IEnemyAI>();
            target = Target;
            start = transform.position;

            StartCoroutine(Curve());
        }
    }
}