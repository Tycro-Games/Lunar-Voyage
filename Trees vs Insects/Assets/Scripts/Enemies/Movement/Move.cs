using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class Move : MonoBehaviour
    {
        [SerializeField]
        private float unitsPerSec = 1.0f;

        public IEnumerator MoveTo (Vector3 node)
        {
            Quaternion rot = Quaternion.LookRotation (Vector3.forward, Dir (node));

            Debug.DrawLine (transform.position, transform.position + Dir (node));
            while (transform.position != node)
            {
                transform.position = Vector3.MoveTowards (transform.position, node, unitsPerSec * Time.deltaTime);

                yield return null;
            }
        }

        private Vector3 Dir (Vector3 thingTolookAt)
        {
            return (Vector2)(thingTolookAt - transform.position).normalized;
        }
    }
}