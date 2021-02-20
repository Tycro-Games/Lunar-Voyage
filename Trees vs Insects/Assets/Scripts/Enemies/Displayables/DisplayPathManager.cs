using Bogadanul.Assets.Scripts.Enemies;
using Bogadanul.Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPathManager
{
    public HashSet<Node> nodes = new HashSet<Node> ();

    public void Reset () => nodes = new HashSet<Node> ();

    public void AddPaths (List<Node> path, bool noEnds = false)
    {
        for (int i = 1; i < path.Count - 1; i++)
            nodes.Add (path[i]);
        if (path.Count > 0)
        {
            if (!noEnds)
            {
                nodes.Add (path[0]);
                nodes.Add (path[path.Count - 1]);
            }
        }
    }

    public void RemovePaths (List<Node> path)
    {
        foreach (Node n in path)
            nodes.Remove (n);
    }
}