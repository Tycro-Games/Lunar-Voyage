using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (TracePath))]
public class Pathfinding : MonoBehaviour
{


    TracePath path;

    private Transform seeker, target;
    Grid grid;

    public static bool hasPath = false;




    private void Awake ()
    {
        path = GetComponent<TracePath> ();
    }
    private void Start ()
    {
        TreePlacer.OnPlaceTree += FindPath;

        grid = Grid.currentGrid;

        seeker = transform;
        target = GameObject.FindGameObjectWithTag ("Target").transform;

        FindPath ();

    }
    private void OnDisable ()
    {
        TreePlacer.OnPlaceTree -= FindPath;
    }
    public void FindPath ()
    {
        hasPath = false;
        Node startNode = grid.NodeFromWorldPoint (seeker.position);
        Node targetNode = grid.NodeFromWorldPoint (target.position);

        Heap<Node> openSet = new Heap<Node> (grid.MaxSize);
        HashSet<Node> closedSet = new HashSet<Node> ();
        openSet.Add (startNode);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet.RemoveFirst ();
            closedSet.Add (currentNode);

            if (currentNode == targetNode)
            {
                hasPath = true;
                RetracePath (startNode, targetNode);
                return;
            }

            foreach (Node neighbour in grid.GetNeighbours (currentNode))
            {
                if (!neighbour.walkable || closedSet.Contains (neighbour))
                {
                    continue;
                }
                int newMovementCostToNeighbour = currentNode.gCost + GetDistance (currentNode, neighbour);
                if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains (neighbour))
                {
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = GetDistance (neighbour, targetNode);
                    neighbour.parent = currentNode;

                    if (!openSet.Contains (neighbour))
                        openSet.Add (neighbour);
                    else
                    {
                        openSet.UpdateItem (neighbour);
                    }
                }
            }
        }


    }

    void RetracePath (Node startNode, Node endNode)
    {
        List<Node> path = new List<Node> ();
        path.Add (grid.NodeFromWorldPoint (target.position));
        Node currentNode = endNode;



        while (currentNode != startNode)
        {
            path.Add (currentNode);
            currentNode = currentNode.parent;
        }



        path.Reverse ();

        this.path.SetPath = path;

    }

    int GetDistance (Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs (nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs (nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }
}