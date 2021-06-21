using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tree.Projectiles
{
    public class ProjectileMovement : MonoBehaviour
    {
        [SerializeField]
        private AnimationCurve speedCurve = null;

        private float speedTime = 0;

        private void Start()
        {
            speedTime = 0;
        }

        public void MoveToTarget(Transform target, float speed)
        {
            speedTime += Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed * speedCurve.Evaluate(speedTime));
            transform.rotation = Quaternion.LookRotation(Vector3.forward, (target.position - transform.position).normalized);
        }

        public void MoveToTarget(Vector3 dir, float speed)
        {
            speedTime += Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, transform.position + dir, Time.deltaTime * speed * speedCurve.Evaluate(speedTime));
        }
    }
}