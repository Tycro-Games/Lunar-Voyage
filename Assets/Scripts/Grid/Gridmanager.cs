﻿using Bogadanul.Assets.Scripts.Enemies;
using Bogadanul.Assets.Scripts.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Player
{
    public class Gridmanager : MonoBehaviour
    {
        public static Gridmanager gridmanager;
        public static Dictionary<Node, GameObject> Nodes = new Dictionary<Node, GameObject> ();
        public Vector2 gridWorldSize;

        public float nodeRadius;

        public List<Node> path;

        public LayerMask unwalkableMask;
        public LayerMask ocupiedMask;

        [HideInInspector]
        public int gridSizeX, gridSizeY;

        public Node[,] grid;

        [SerializeField]
        private Vector3 offset = Vector3.zero;

        [SerializeField]
        private Transform collParent = null;

        [SerializeField]
        private GameObject nodeCol = null;

        private float nodeDiameter;

        [SerializeField]
        private bool noDiagonal = false;

        public int MaxSize
        {
            get
            {
                return gridSizeX * gridSizeY;
            }
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

                    if (noDiagonal)
                        if (Mathf.Abs (x + y) == 2 || x + y == 0)
                            continue;

                    int checkX = node.gridX + x;
                    int checkY = node.gridY + y;

                    if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                    {
                        neighbours.Add (grid[checkX, checkY]);
                    }
                }
            }

            return neighbours;
        }

        public Node NodeFromWorldPoint (Vector2 worldPosition)
        {
            float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
            float percentY = (worldPosition.y + gridWorldSize.y / 2) / gridWorldSize.y;
            percentX = Mathf.Clamp01 (percentX);
            percentY = Mathf.Clamp01 (percentY);

            int x = Mathf.RoundToInt ((gridSizeX - 1) * percentX);
            int y = Mathf.RoundToInt ((gridSizeY - 1) * percentY);

            return grid[x, y];
        }

        public void UpdateGrid ()
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    grid[x, y].IsWalkable = !Physics.CheckSphere (grid[x, y].worldPosition, nodeRadius, unwalkableMask);
                }
            }
        }

        private void Awake ()
        {
            EnemyManager.grid = this;
            Nodes = new Dictionary<Node, GameObject> ();
            gridmanager = this;
            nodeDiameter = nodeRadius * 2;
            gridSizeX = Mathf.RoundToInt (gridWorldSize.x / nodeDiameter);
            gridSizeY = Mathf.RoundToInt (gridWorldSize.y / nodeDiameter);
            CreateGrid ();
        }

        private void CreateGrid ()
        {
            grid = new Node[gridSizeX, gridSizeY];
            Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y / 2 + offset;

            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.up * (y * nodeDiameter + nodeRadius);

                    bool walkable = !Physics.CheckSphere (worldPoint, nodeRadius, unwalkableMask);

                    grid[x, y] = new Node (walkable, worldPoint, x, y);

                    Nodes.Add (grid[x, y], SpawnCols (grid[x, y]));
                }
            }
        }

        private GameObject SpawnCols (Node node)
        {
            GameObject col = Instantiate (nodeCol, node.worldPosition, Quaternion.identity, collParent);

            NodeInstance instance = col.GetComponent<NodeInstance> ();
            instance.Init (node);
            return col;
        }

        private void OnDrawGizmos ()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireCube (transform.position + offset, new Vector3 (gridWorldSize.x, gridWorldSize.y, 0));

            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    if (!grid[x, y].IsWalkable)
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawCube (grid[x, y].worldPosition, new Vector2 (nodeDiameter, nodeDiameter));
                    }
                    else
                    {
                        Gizmos.color = Color.white;
                        Gizmos.DrawWireCube (grid[x, y].worldPosition, new Vector2 (nodeDiameter, nodeDiameter));
                    }
                }
            }
        }
    }
}