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
        public bool IsActive = true;
        private ReachAncientTree reachAncient = null;
        private Move move = null;
        private Node lastNode = null;
        private UpdateOffset pos = null;
        private NodeFinder nodeFinder = null;

        public override List<Node> Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
                if (IsActive)
                    StartPath ();
            }
        }

        public void StartPath ()
        {
            StopAllCoroutines ();
            move.Reset ();
            StartCoroutine (FollowPath (path));
        }

        private void Awake ()
        {
            move = GetComponent<Move> ();
            pos = GetComponent<UpdateOffset> ();
            reachAncient = GetComponent<ReachAncientTree> ();
            nodeFinder = GetComponent<NodeFinder> ();
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
                yield return StartCoroutine (move.MoveTo (path[i].worldPosition));
                lastNode = path[i];
            }
            Debug.LogError ("End path");
        }
    }
}