using System.Collections;
using UnityEngine;
using Bogadanul.Assets.Scripts.Utility;
using Assets.Scripts.Enemies.Movement;
using Assets.Scripts.Enemies.Scriptable;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class Move : MonoBehaviour
    {
        [SerializeField]
        private MovementSpeeds movement = null;

        private float unitsPerSec = 1.0f;

        private FlipSprite sprite;
        public float UnitsPerSec { get => movement.unitsPerSec; set => movement.unitsPerSec = value; }

        public void Reset()
        {
            StopAllCoroutines();
        }

        private void Awake()
        {
            unitsPerSec += Random.Range(movement.min, movement.max);
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