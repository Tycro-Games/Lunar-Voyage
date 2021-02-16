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
        private DisplayRange display;

        public bool CheckDist (BoxCollider col)
        {
            Node target = nodeFinder.NodeFromPoint (col.transform);
            if (nodes.Contains (target))
            {
                return true;
            }
            return false;
        }

        protected void GetRefs ()
        {
            nodeFinder = GetComponent<NodeFinder> ();
            display = FindObjectOfType<DisplayRange> ();
            nodes = display.nodes;
            display.Reset ();
        }
    }
}