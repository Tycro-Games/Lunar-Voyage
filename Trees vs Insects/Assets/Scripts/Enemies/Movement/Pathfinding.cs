using Bogadanul.Assets.Scripts.Player;
using Bogadanul.Assets.Scripts.Tree;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Enemies
{
    [RequireComponent(typeof(NodeFinder))]
    public class Pathfinding : MonoBehaviour
    {
        [HideInInspector]
        public Transform seeker, target = null;

        [HideInInspector]
        public Gridmanager grid;

        private TracePathCheck path;
        private List<Node> pathCurrent = new List<Node>();
        private AncientTreeSpaceChecker ancientTree;
        private NodeFinder nodeFind;
        private bool First = false;

        public void Awake()
        {
            nodeFind = GetComponent<NodeFinder>();
            ancientTree = FindObjectOfType<AncientTreeSpaceChecker>();
            seeker = transform;

            path = GetComponent<TracePathCheck>();

            EnemyManager.pathfindings.Add(path, this);
        }

        public int GetDistance(Node nodeA, Node nodeB)
        {
            int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
            int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

            if (dstX > dstY)
                return 14 * dstY + 10 * (dstX - dstY);
            return 14 * dstX + 10 * (dstY - dstX);
        }

        public void Init(Transform Target, Gridmanager grid)
        {
            target = Target;
            this.grid = grid;
        }

        protected List<Node> RetracePath(Node startNode, Node endNode)
        {
            First = true;
            pathCurrent = new List<Node>();

            Node currentNode = endNode;

            while (currentNode != startNode)
            {
                pathCurrent.Add(currentNode);
                currentNode = currentNode.parent;
            }

            pathCurrent.Add(startNode);

            pathCurrent.Reverse();

            return pathCurrent;
        }

        private void Start()
        {
            ancientTree.CheckSpace();
            if (seeker != null && target != null && nodeFind != null)
                FindPath();
        }

        #region checkSpace

        private bool IsCurrentPath()
        {
            foreach (Node n in path.Path)
            {
                if (n.IsWalkable ==false)
                    return false;
            }
            return true;
        }

        public bool HasPath()
        {
            grid.UpdateGrid();
            if (First&& IsCurrentPath())
                return true;
            Node startNode = nodeFind.NodeFromPoint(transform);
            if (startNode == null) return false;
            Node targetNode = ancientTree.currentNodes[0];

            Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
            HashSet<Node> closedSet = new HashSet<Node>();

            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                Node currentNode = openSet.RemoveFirst();
                closedSet.Add(currentNode);

                if (currentNode == targetNode)
                {
                    return true;
                }

                foreach (Node neighbour in grid.GetNeighbours(currentNode))
                {
                    if (!neighbour.IsWalkable || closedSet.Contains(neighbour))
                    {
                        continue;
                    }
                    int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                    if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        neighbour.gCost = newMovementCostToNeighbour;
                        neighbour.hCost = GetDistance(neighbour, targetNode);
                        neighbour.parent = currentNode;

                        if (!openSet.Contains(neighbour))
                            openSet.Add(neighbour);
                        else
                        {
                            openSet.UpdateItem(neighbour);
                        }
                    }
                }
            }
            return false;
        }

        public void FindPath(bool remove=false)
        {
            grid.UpdateGrid();
            if(remove)
            if (First&&IsCurrentPath() )
                return;
            Node startNode = nodeFind.NodeFromPoint(transform);
            if (startNode == null) return;
            Node targetNode = ancientTree.currentNodes[0];

            Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
            HashSet<Node> closedSet = new HashSet<Node>();

            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                Node currentNode = openSet.RemoveFirst();
                closedSet.Add(currentNode);

                if (currentNode == targetNode)
                {

                    path.Path = RetracePath(startNode, targetNode);
                    return;
                }

                foreach (Node neighbour in grid.GetNeighbours(currentNode))
                {
                    if (!neighbour.IsWalkable || closedSet.Contains(neighbour))
                    {
                        continue;
                    }
                    int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                    if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        neighbour.gCost = newMovementCostToNeighbour;
                        neighbour.hCost = GetDistance(neighbour, targetNode);
                        neighbour.parent = currentNode;

                        if (!openSet.Contains(neighbour))
                            openSet.Add(neighbour);
                        else
                        {
                            openSet.UpdateItem(neighbour);
                        }
                    }
                }
            }
            
        }

        #endregion checkSpace
    }
}