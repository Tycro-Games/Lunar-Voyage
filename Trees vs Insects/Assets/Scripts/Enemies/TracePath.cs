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
        private ReachAncientTree reachAncient = null;
        private Move move;

        public override List<Node> Path
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
            move = GetComponent<Move> ();
            reachAncient = GetComponent<ReachAncientTree> ();
        }

        private IEnumerator FollowPath (List<Node> path)
        {
            for (int i = 0; i < path.Count; i++)
            {
                yield return StartCoroutine (move.MoveTo (path[i].worldPosition));
            }
            reachAncient.Reached ();
        }
    }
}