using Bogadanul.Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class RandomPos : MonoBehaviour
    {
        private UpdateOffset[] SubChilds = null;
        private Vector2 Offset = Vector2.zero;

        [SerializeField]
        private float range = 1.0f;

        [SerializeField]
        private float step = .25f;

        [SerializeField]
        private float multiplier = 1.0f;

        public void SetRanPos ()

        {
            float r = Random.Range (1, 10);
            foreach (UpdateOffset offset in SubChilds)
            {
                offset.StartPos (Offset + new Vector2 (Mathf.Sin (r), Mathf.Cos (r)) * multiplier);

                r = r + step;
            }
        }

        private void Randomize ()
        {
            Offset = (Random.insideUnitCircle * range);
        }

        private void Awake ()
        {
            SubChilds = GetComponentsInChildren<UpdateOffset> ();
            Randomize ();
        }

        private void OnDrawGizmosSelected ()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere (transform.position, range+multiplier);
        }
    }
}