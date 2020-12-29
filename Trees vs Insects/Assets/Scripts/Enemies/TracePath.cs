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
        private Move move = null;
        private Node lastNode = null;
        private UpdateOffset pos = null;

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

            pos.UpdateOffsets ();

            StartCoroutine (FollowPath (path));
        }

        private void Awake ()
        {
            move = GetComponent<Move> ();
            pos = GetComponent<UpdateOffset> ();
            reachAncient = GetComponent<ReachAncientTree> ();
        }

        private IEnumerator FollowPath (List<Node> path)
        {
            int i = 0;
            if (lastNode == null)
                lastNode = path[i];
            else if (path[i] == lastNode)
            {
                i++;
            }

            for (; i < path.Count; i++)
            {
                yield return StartCoroutine (move.MoveTo ((Vector2)path[i].worldPosition + pos.Offset));

                lastNode = path[i];
            }
            reachAncient.Reached ();
        }
    }
}