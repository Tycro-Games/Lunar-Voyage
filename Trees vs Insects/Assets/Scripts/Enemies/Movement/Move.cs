using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bogadanul.Assets.Scripts.Utility;
using Assets.Scripts.Enemies.Movement;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class Move : MonoBehaviour
    {
        [SerializeField]
        private float unitsPerSec = 1.0f;

        [SerializeField]
        private float randomRange = 0.0f;

        private FlipSprite sprite;
        public float UnitsPerSec { get => unitsPerSec; set => unitsPerSec = value; }

        public void Reset()
        {
            StopAllCoroutines();
        }

        private void Awake()
        {
            unitsPerSec = RandomStuff.RandomNumber(unitsPerSec, randomRange);
            sprite = GetComponentInChildren<FlipSprite>();
        }

        public IEnumerator MoveTo(Vector3 node)
        {
            sprite.ChangeDirection(transform.position, node);
            while (transform.position != node)
            {
                transform.position = Vector3.MoveTowards(transform.position, node, UnitsPerSec * Time.deltaTime);

                yield return null;
            }
        }

        private Vector3 Dir(Vector3 thingTolookAt)
        {
            return (Vector2)(thingTolookAt - transform.position).normalized;
        }
    }
}