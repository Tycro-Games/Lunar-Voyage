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

        [SerializeField]
        private float duration = 1.0f;

        private void Start()
        {
            speedTime = 0;
        }

        public void MoveToTarget(Transform target, float speed)
        {
            Vector2 pos = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed * speedCurve.Evaluate(TimeManagement()));
            Quaternion rot = Quaternion.LookRotation(Vector3.forward, (target.position - transform.position).normalized);
            transform.SetPositionAndRotation(pos, rot);
        }

        private float TimeManagement()
        {
            speedTime += Time.deltaTime;
            return speedTime / duration;
        }

        public void MoveToTarget(Vector3 dir, float speed)
        {
            transform.position = Vector2.MoveTowards(transform.position, transform.position + dir, Time.deltaTime * speed * speedCurve.Evaluate(TimeManagement()));
        }
    }
}