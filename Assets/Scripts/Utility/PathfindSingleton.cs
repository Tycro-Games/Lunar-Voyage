using Bogadanul.Assets.Scripts.Player;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public static class PathfindSingleton 
    {
        //public static bool HasPath(Node start,Node Target)
        //{

        //    Node startNode = start;
        //    if (startNode == null) return false;
        //    Node targetNode = ancientTree.currentNodes[0];

        //    Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
        //    HashSet<Node> closedSet = new HashSet<Node>();

        //    openSet.Add(startNode);

        //    while (openSet.Count > 0)
        //    {
        //        Node currentNode = openSet.RemoveFirst();
        //        closedSet.Add(currentNode);

        //        if (currentNode == targetNode)
        //        {
        //            return true;
        //        }

        //        foreach (Node neighbour in grid.GetNeighbours(currentNode))
        //        {
        //            if (!neighbour.IsWalkable || closedSet.Contains(neighbour) || neighbour == n)
        //            {
        //                continue;
        //            }
        //            int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
        //            if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
        //            {
        //                neighbour.gCost = newMovementCostToNeighbour;
        //                neighbour.hCost = GetDistance(neighbour, targetNode);
        //                neighbour.parent = currentNode;

        //                if (!openSet.Contains(neighbour))
        //                    openSet.Add(neighbour);
        //                else
        //                {
        //                    openSet.UpdateItem(neighbour);
        //                }
        //            }
        //        }
        //    }
        //    return false;
        //}
    }
}