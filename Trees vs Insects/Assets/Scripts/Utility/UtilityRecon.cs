using Bogadanul.Assets.Scripts.Player;
using Bogadanul.Assets.Scripts.Tree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Utility
{
    public static class UtilityRecon
    {
        public static List<Node> GetLines(Node node, Gridmanager gridmanager, bool diagonal = false)
        {
            List<Node> line = new List<Node>();
            int xGrid = node.gridX;
            int yGrid = node.gridY;
            for (int x = xGrid + 1; x < gridmanager.gridSizeX; x++)
                line.Add(gridmanager.grid[x, yGrid]);

            for (int y = yGrid + 1; y < gridmanager.gridSizeY; y++)
                line.Add(gridmanager.grid[xGrid, y]);

            for (int x = xGrid - 1; x >= 0; x--)
                line.Add(gridmanager.grid[x, yGrid]);

            for (int y = yGrid - 1; y >= 0; y--)
                line.Add(gridmanager.grid[xGrid, y]);
            if (diagonal)
            {
                for (int x = xGrid + 1, y = yGrid + 1; x < gridmanager.gridSizeX && y < gridmanager.gridSizeY; x++, y++)
                    line.Add(gridmanager.grid[x, y]);
                for (int x = xGrid + 1, y = yGrid - 1; x < gridmanager.gridSizeX && y >= 0; x++, y--)
                    line.Add(gridmanager.grid[x, y]);
                for (int x = xGrid - 1, y = yGrid - 1; x >= 0 && y >= 0; x--, y--)
                    line.Add(gridmanager.grid[x, y]);
                for (int x = xGrid - 1, y = yGrid + 1; x >= 0 && y < gridmanager.gridSizeY; x--, y++)
                    line.Add(gridmanager.grid[x, y]);
            }

            return line;
        }

        public static List<Node> GetNeighbours(Node node, Gridmanager gridmanager)
        {
            List<Node> neighbours = new List<Node>();

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
                        neighbours.Add(gridmanager.grid[checkX, checkY]);
                    }
                }
            }

            return neighbours;
        }

        public static float Dist(this Transform transform, Vector3 col)
        {
            Vector2 dist = transform.position - col;
            return dist.sqrMagnitude;
        }
    }
}