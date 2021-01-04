using Bogadanul.Assets.Scripts.Player;
using Bogadanul.Assets.Scripts.Tree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Utility
{
    public static class UtilityRecon
    {
        public static addDir SetDirFromAncient (Vector2 transform, Transform tree, addDir direction)
        {
            Vector2 dir = (transform - (Vector2)tree.position).normalized;

            if (Mathf.Abs (dir.x) != Mathf.Abs (dir.y))
            {
                direction = new addDir (dir);
            }

            return direction;
        }

        public static List<Node> GetLine (Node node, addDir coord, Gridmanager gridmanager)
        {
            if (coord.x == 0 && coord.y == 0)
            {
                Debug.LogError ("InfiniteLoop");
                return null;
            }
            List<Node> line = new List<Node> ();

            int xGrid = node.gridX;
            int yGrid = node.gridY;

            while (xGrid >= 0 && xGrid < gridmanager.gridSizeX && yGrid >= 0 && yGrid < gridmanager.gridSizeY)
            {
                line.Add (gridmanager.grid[xGrid, yGrid]);
                xGrid += coord.x;
                yGrid += coord.y;
            }
            return line;
        }

        public static List<Node> GetNeighbours (Node node, Gridmanager gridmanager)
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
    }
}