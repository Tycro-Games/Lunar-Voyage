using Bogadanul.Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class AncientTreeSpaceChecker : MonoBehaviour
    {
        public List<Node> currentNodes = new List<Node> ();

        [SerializeField]
        private LayerMask cellsLayer = 0;

        public void CheckSpace ()
        {
            currentNodes = new List<Node> ();
            Collider[] cols = new Collider[8];
            int count = Physics.OverlapBoxNonAlloc (transform.position, Vector2.zero, cols, Quaternion.identity, cellsLayer);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    currentNodes.Add (cols[i].gameObject.GetComponent<NodeInstance> ().node);
                }
            }
        }

        private void OnDrawGizmos ()
        {
            if (currentNodes.Count != 0)
            {
                Gizmos.color = Color.green;
                foreach (Node currentNode in currentNodes)
                    Gizmos.DrawWireCube (currentNode.worldPosition, Vector2.one * 2);
            }
        }
    }
}