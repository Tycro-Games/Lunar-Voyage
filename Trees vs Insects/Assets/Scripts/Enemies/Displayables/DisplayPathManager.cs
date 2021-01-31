using Bogadanul.Assets.Scripts.Enemies;
using Bogadanul.Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DisplayPathManager
{
    public static HashSet<Node> nodes = new HashSet<Node> ();

    public static event Action OnChange = null;

    public static void RemovePaths (List<Node> path)
    {
        foreach (Node n in path)
            nodes.Remove (n);
        OnChange?.Invoke ();
    }
    public static void ActivateDisplay()
    {
        
        OnChange?.Invoke();
    }
    public static void Reset ()
    {
        nodes = new HashSet<Node> ();
    }

    public static void AddPaths (List<Node> path)
    {
        path = PathNoEnds (path);
        foreach (Node n in path)
            nodes.Add (n);
        OnChange?.Invoke ();
    }

    public static List<Node> PathNoEnds (List<Node> Path)
    {
        List<Node> p = Path;
        if (Path.Count > 1)
        {
            p.Remove (Path[0]);
            p.Remove (Path[Path.Count - 1]);
        }
        return p;
    }
}