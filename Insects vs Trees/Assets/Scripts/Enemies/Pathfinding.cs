using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pathfinding : MonoBehaviour
{
    protected TracePathCheck path;
    protected Transform seeker, target = null;
    protected Grid grid;

    protected List<Node> pathCurrent = new List<Node>();
    public void Awake()
    {
        seeker = transform;

        path = GetComponent<TracePathCheck>();

        EnemyManager.pathfindings.Add(path, this);
    }
    public void Init(Transform Target, Grid grid)
    {
        target = Target;
        this.grid = grid;
    }
    public void Start()
    {
        if (seeker != null && target != null)
            FindPath();
    }

    #region  checkSpace
    public bool FindPath()
    {
        bool hasPath = false;

        grid.UpdateGrid();



        Node startNode = grid.NodeFromWorldPoint(seeker.position);
        Node targetNode = grid.NodeFromWorldPoint(target.position);

        Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet.RemoveFirst();
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                hasPath = true;
                RetracePath(startNode, targetNode);
                return hasPath;
            }

            foreach (Node neighbour in grid.GetNeighbours(currentNode))
            {
                if (!neighbour.walkable || closedSet.Contains(neighbour))
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
        return hasPath;
    }
    #endregion
    protected void RetracePath(Node startNode, Node endNode)
    {
        pathCurrent = new List<Node>();
        pathCurrent.Add(grid.NodeFromWorldPoint(target.position));
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            pathCurrent.Add(currentNode);
            currentNode = currentNode.parent;
        }

        pathCurrent.Reverse();

        path.SetPath = pathCurrent;

    }
    public int GetDistance(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }
    private void OnDrawGizmos()
    {
        if (path != null)
        {
            foreach (Node n in path.SetPath)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(n.worldPosition, Vector3.one * 1.25f);
            }
        }
    }
}
