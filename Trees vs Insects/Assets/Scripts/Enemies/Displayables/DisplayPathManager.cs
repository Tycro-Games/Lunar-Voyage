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
        if (noEnds)
            path = PathNoEnds (path);
        foreach (Node n in path)
            nodes.Add (n);
    }

    public List<Node> PathNoEnds (List<Node> Path)
    {
        List<Node> p = Path;
        if (Path.Count > 1)
        {
            p.Remove (Path[0]);
            p.Remove (Path[Path.Count - 1]);
        }
        return p;
    }

    public void RemovePaths (List<Node> path)
    {
        foreach (Node n in path)
            nodes.Remove (n);
    }
}