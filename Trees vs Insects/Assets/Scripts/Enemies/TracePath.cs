using Bogadanul.Assets.Scripts.Player;
using Bogadanul.Assets.Scripts.Tree;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    public class TracePath : TracePathCheck
    {
        [SerializeField]
        private float unitsPerSec = 1.0f;

        private ReachAncientTree reachAncient = null;

        public override List<Node> SetPath
        {
            set
            {
                path = value;
                StartPath ();
            }
        }

        public void StartPath ()
        {
            StopAllCoroutines ();
            StartCoroutine (FollowPath (path));
        }

        private void Start ()
        {
            reachAncient = GetComponent<ReachAncientTree> ();
        }

        private Vector3 Dir (Vector3 thingTolookAt)
        {
            Vector2 dir = (thingTolookAt - transform.position).normalized;
            return dir;
        }

        private IEnumerator FollowPath (List<Node> path)
        {
            int i = 0;
            while (i < path.Count)
            {
                yield return StartCoroutine (Move (path[i].worldPosition));

                i++;
            }
            reachAncient.Reached ();
        }

        private IEnumerator Move (Vector3 node)
        {
            while (transform.position != node)
            {
                transform.position = Vector3.MoveTowards (transform.position, node, unitsPerSec * Time.deltaTime);

                Debug.DrawLine (transform.position, transform.position + Dir (node));
                yield return null;
            }
        }
    }
}