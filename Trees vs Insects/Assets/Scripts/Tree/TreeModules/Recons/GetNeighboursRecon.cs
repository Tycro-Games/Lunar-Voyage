using Bogadanul.Assets.Scripts.Player;
using Bogadanul.Assets.Scripts.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class GetNeighboursRecon : BaseRecon, ITreeRecon
    {
        private BoxCollider[] colliders = new BoxCollider[32];
        private Gridmanager gridmanager;

        [SerializeField]
        private Vector3 radius = Vector3.zero;

        private Color GizCol = Color.white;

        public BoxCollider CheckForEnemies()
        {
            int count = Physics.OverlapBoxNonAlloc(transform.position, radius / 2, colliders, Quaternion.identity, enemies);
            if (count > 0)
            {
                BoxCollider col = colliders[0];

                float currentDist = transform.Dist(col.transform.position);
                foreach (BoxCollider c in colliders)
                {
                    if (c == null)
                        continue;

                    float Dist = transform.Dist(c.transform.position);
                    if (Dist < currentDist)
                    {
                        col = c;
                        currentDist = Dist;
                    }
                }
                return col;
            }
            return null;
        }

        public List<Node> GetNodeRange(Node pos)
        {
            return UtilityRecon.GetNeighbours(pos, Gridmanager.gridmanager);
        }

        private void Awake()
        {
            GizCol = Random.ColorHSV();
            GetRefs();
          
          
        }
        private void Start()
        {
            if (nodes.Count == 0)
                nodes = GetNodeRange(nodeFinder.NodeFromPoint(transform));
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, new Vector2(radius.x, radius.y));
            Gizmos.color = GizCol;
            if (nodes != null)
                foreach (Node n in nodes)
                {
                    Gizmos.DrawCube(n.worldPosition, new Vector2(1, 1));
                }
        }
    }
}