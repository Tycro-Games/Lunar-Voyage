using Bogadanul.Assets.Scripts.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Bogadanul.Assets.Scripts.Utility
{
    public static class UtilityRecon
    {
        public static List<Node> GetLines(Node node, int range, Gridmanager gridmanager, bool diagonal = false)
        {
            List<Node> line = new List<Node>();
            int xGrid = node.gridX;
            int yGrid = node.gridY;
            int minX = Mathf.Clamp(xGrid - range, 0, gridmanager.gridSizeX);
            int minY = Mathf.Clamp(yGrid - range, 0, gridmanager.gridSizeY - 1);

            int maxX = Mathf.Clamp(xGrid + range, 0, gridmanager.gridSizeX);
            int maxY = Mathf.Clamp(yGrid + range, 0, gridmanager.gridSizeY - 1);

            for (int x = minX; x <= maxX; x++)
            {
                if (x != xGrid)
                    line.Add(gridmanager.grid[x, yGrid]);
            }
            for (int y = minY; y <= maxY; y++)
            {
                if (y != yGrid)
                    line.Add(gridmanager.grid[xGrid, y]);
            }

            if (diagonal)
            {
                for (int x = xGrid + 1, y = yGrid + 1; x <= maxX && y <= maxY; x++, y++)
                    line.Add(gridmanager.grid[x, y]);
                for (int x = xGrid + 1, y = yGrid - 1; x <= maxX&& y >= minY; x++, y--)
                    line.Add(gridmanager.grid[x, y]);
                for (int x = xGrid - 1, y = yGrid - 1; x >= minX && y >= minY; x--, y--)
                    line.Add(gridmanager.grid[x, y]);
                for (int x = xGrid - 1, y = yGrid + 1; x >= minX && y <= maxY; x--, y++)
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