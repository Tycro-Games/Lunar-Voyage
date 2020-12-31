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

    public static void Reset ()
    {
        nodes = new HashSet<Node> ();
    }

    public static void AddPaths (List<Node> path)
    {
        foreach (Node n in path)
            nodes.Add (n);

        OnChange?.Invoke ();
    }

    public static IEnumerator AddPathsTimed (List<Node> path, float time)
    {
        foreach (Node n in path)
            nodes.Add (n);

        OnChange?.Invoke ();
        yield return new WaitForSeconds (time);
        RemovePaths (path);
    }

    public static void RemovePaths (List<Node> path)
    {
        foreach (Node n in path)
            nodes.Remove (n);
        OnChange?.Invoke ();
    }
}