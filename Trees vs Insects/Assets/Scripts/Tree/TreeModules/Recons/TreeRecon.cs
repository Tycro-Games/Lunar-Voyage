using Bogadanul.Assets.Scripts.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Tree
{
    public class TreeRecon : MonoBehaviour, ITreeRecon
    {
        private NodeFinder nodeFinder = null;
        private BoxCollider[] colliders = new BoxCollider[32];
        private Gridmanager gridmanager;

        [SerializeField]
        private LayerMask enemies = 0;

        [SerializeField]
        private Vector3 radius = Vector3.zero;

        private Node currentNode = null;
        private List<Node> Neighbours = null;
        private Color GizCol = Color.white;

        public BoxCollider CheckSorounding ()
        {
            int count = Physics.OverlapBoxNonAlloc (transform.position, radius, colliders, Quaternion.identity, enemies);
            if (count > 0)
            {
                BoxCollider col = colliders[0];

                float currentDist = dist (col.transform.position);
                foreach (BoxCollider c in colliders)
                {
                    if (c == null)
                        continue;

                    float Dist = dist (c.transform.position);
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

        public bool CheckDist (BoxCollider col)
        {
            Node target = nodeFinder.NodeFromPoint (col.transform);
            if (Neighbours.Contains (target))
            {
                return true;
            }
            return false;
        }

        public List<Node> GetNeighbours (Node node)
        {
            List<Node> neighbours = new List<Node> ();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    int checkX = node.gridX + x;
                    int checkY = node.gridY + y;
                    if (checkX >= 0 && checkX < gridmanager.gridSizeX && checkY >= 0 && checkY < gridmanager.gridSizeY)
                    {
                        neighbours.Add (gridmanager.grid[checkX, checkY]);
                    }
                }
            }

            return neighbours;
        }

        private void Awake ()
        {
            GizCol = Random.ColorHSV ();
        }

        private void Start ()
        {
            gridmanager = FindObjectOfType<Gridmanager> ();
            nodeFinder = GetComponent<NodeFinder> ();

            currentNode = nodeFinder.NodeFromPoint (transform);
            Neighbours = GetNeighbours (currentNode);
        }

        private float dist (Vector3 col)
        {
            Vector2 dist = transform.position - col;
            return dist.sqrMagnitude;
        }

        private void OnDrawGizmosSelected ()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube (transform.position, new Vector2 (radius.x, radius.y));
            Gizmos.color = GizCol;
            if (Neighbours != null)
                foreach (Node n in Neighbours)
                {
                    Gizmos.DrawCube (n.worldPosition, new Vector2 (1, 1));
                }
        }
    }
}