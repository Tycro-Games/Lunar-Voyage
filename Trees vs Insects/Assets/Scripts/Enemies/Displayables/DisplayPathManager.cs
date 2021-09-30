using Bogadanul.Assets.Scripts.Player;
using System.Collections.Generic;

public class DisplayPathManager
{
    public  HashSet<Node> nodes = new HashSet<Node>();

    public void Reset() => nodes = new HashSet<Node>();

    public void AddPaths(List<Node> path, bool noEnds = false)
    {
        for (int i = 1; i < path.Count - 1; i++)
            nodes.Add(path[i]);
        if (path.Count > 0)
        {
            if (!noEnds)
            {
                nodes.Add(path[0]);
                nodes.Add(path[path.Count - 1]);
            }
        }
    }

    public static List<Node> ReturnPathWithNoHeads(List<Node> path)
    {
        List<Node> nodes = new List<Node>();
        for (int i = 1; i < path.Count - 1; i++)
            nodes.Add(path[i]);
        return nodes;
    }

    public void RemovePaths(List<Node> path)
    {
        foreach (Node n in path)
            nodes.Remove(n);
    }
}