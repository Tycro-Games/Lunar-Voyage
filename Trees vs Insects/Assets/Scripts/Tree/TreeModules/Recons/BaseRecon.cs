using Bogadanul.Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public abstract class BaseRecon : MonoBehaviour
    {
        [SerializeField]
        protected LayerMask enemies = 0;

        protected NodeFinder nodeFinder = null;
        protected List<Node> nodes = new List<Node> ();

        public bool CheckDist (BoxCollider col)
        {
            Node target = nodeFinder.NodeFromPoint (col.transform);
            if (nodes.Contains (target))
            {
                return true;
            }
            return false;
        }

        public float dist (Vector3 col)
        {
            Vector2 dist = transform.position - col;
            return dist.sqrMagnitude;
        }

        protected void GetRefs ()
        {
            nodeFinder = GetComponent<NodeFinder> ();
            DisplayRange display = FindObjectOfType<DisplayRange> ();
            nodes = display.nodes;
            display.Reset ();
        }
    }
}