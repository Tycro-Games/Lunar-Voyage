using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class RandomPos : MonoBehaviour
    {
        [HideInInspector]
        public Vector2 offset = Vector2.zero;

        [SerializeField]
        private float range = 1.0f;

        public void Randomize ()
        {
            offset = Random.insideUnitCircle * range * Mathf.Sin (Time.time);
            transform.position = (Vector2)transform.position + offset;
        }

        private void OnDrawGizmosSelected ()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere (transform.position, range);
        }
    }
}